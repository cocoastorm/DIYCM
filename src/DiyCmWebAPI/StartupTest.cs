using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Data.Entity;
using DiyCmDataModel.Construction;

namespace DiyCmWebAPI
{
    public class StartupTest
    {
        private IApplicationEnvironment _appEnv;
        public StartupTest(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            _appEnv = appEnv;
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build().ReloadOnChanged("appsettings.json");
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();
            services.AddSwaggerGen();

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()));

            var connection = Configuration["Data:DefaultConnection:SQLiteConnectionString"];
            connection = connection.Replace("=", "=" + _appEnv.ApplicationBasePath + "/");
            services.AddEntityFramework()
              .AddSqlite()
              .AddDbContext<DiyCmContext>(options => options.UseSqlite(connection));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseSwaggerGen();
            app.UseSwaggerUi();

            app.UseMvc();

            using (var serviceScope = app.ApplicationServices
              .GetRequiredService<IServiceScopeFactory>()
              .CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DiyCmContext>();

                //normally seeding would take place here
            }

        }

        // Entry point for the application.
        //public static void Main(string[] args) => WebApplication.Run<StartupTest>(args);
    }
}
