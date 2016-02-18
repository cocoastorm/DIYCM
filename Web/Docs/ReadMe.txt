Enable-Migrations -ContextProject WebDataModel -ContextTypeName DIYCMContext -MigrationsDirectory Migrations\DIYCMMigrations

add-migration -ConfigurationTypeName Web.Migrations.DIYCMMigrations.Configuration "InitialCreate"

update-database -ConfigurationTypeName Web.Migrations.DIYCMMigrations.Configuration
