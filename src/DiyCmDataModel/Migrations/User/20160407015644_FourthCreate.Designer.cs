using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DiyCmDataModel.User;

namespace DiyCmDataModel.Migrations.User
{
    [DbContext(typeof(UserContext))]
    [Migration("20160407015644_FourthCreate")]
    partial class FourthCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("DiyCmDataModel.User.User", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 16);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 16);

                    b.HasKey("userid");
                });
        }
    }
}
