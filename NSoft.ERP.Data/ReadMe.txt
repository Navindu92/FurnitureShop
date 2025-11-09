Migration Enable
-------------------
enable-migrations -ContextTypeName ERPDBContext -MigrationsDirectory Migrations1
enable-migrations -ContextTypeName ERPDBContext2 -MigrationsDirectory Migrations2

Add Migration
-------------------
add-migration Initial -ConfigurationTypeName NSoft.ERP.Data.Migrations1.Configuration
add-migration Initial -ConfigurationTypeName NSoft.ERP.Data.Migrations2.Configuration

Update Database
-------------------
update-database -configuration NSoft.ERP.Data.Migrations1.Configuration -Verbose -force