namespace NSoft.ERP.Data.Migrations1
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FormInfo",
                c => new
                    {
                        FormInfoID = c.Long(nullable: false, identity: true),
                        FormName = c.String(maxLength: 20),
                        FormText = c.String(maxLength: 20),
                        Prefix = c.String(maxLength: 5),
                        CodeLength = c.Int(nullable: false),
                        FormType = c.Int(nullable: false),
                        ModuleType = c.Int(nullable: false),
                        DocumentID = c.Long(nullable: false),
                        IsAutoGenerate = c.Boolean(nullable: false),
                        IsDepend = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FormInfoID);
            
            CreateTable(
                "dbo.GroupOfCompany",
                c => new
                    {
                        GroupOfCompanyID = c.Int(nullable: false, identity: true),
                        GroupOfCompanyCode = c.String(),
                        GroupOfCompanyName = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GroupOfCompanyID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationID = c.Long(nullable: false, identity: true),
                        LocationCode = c.String(maxLength: 10),
                        LocationName = c.String(maxLength: 20),
                        Address = c.String(maxLength: 50),
                        IsStock = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsHeadOffice = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.NumberSetup",
                c => new
                    {
                        NumberSetupID = c.Long(nullable: false, identity: true),
                        NumberSetupCode = c.String(maxLength: 10),
                        NumberSetupName = c.String(maxLength: 20),
                        DocumentID = c.Long(nullable: false),
                        SerialNo = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NumberSetupID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Long(nullable: false, identity: true),
                        Username = c.String(maxLength: 20),
                        Password = c.String(maxLength: 20),
                        FullName = c.String(maxLength: 50),
                        UserGroupID = c.Long(nullable: false),
                        IsDeveloper = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserGroup",
                c => new
                    {
                        UserGroupID = c.Long(nullable: false, identity: true),
                        UserGroupCode = c.String(maxLength: 20),
                        UserGroupName = c.String(maxLength: 20),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserGroupID);
            
            CreateTable(
                "dbo.UserPrivileges",
                c => new
                    {
                        UserPrivilegesID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(nullable: false),
                        FormInfoID = c.Long(nullable: false),
                        IsAccess = c.Boolean(nullable: false),
                        IsSave = c.Boolean(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserPrivilegesID);
            
            CreateTable(
                "dbo.UserPrivilegesLocation",
                c => new
                    {
                        UserPrivilegesLocationID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(nullable: false),
                        LocationID = c.Long(nullable: false),
                        IsAllow = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserPrivilegesLocationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserPrivilegesLocation");
            DropTable("dbo.UserPrivileges");
            DropTable("dbo.UserGroup");
            DropTable("dbo.User");
            DropTable("dbo.NumberSetup");
            DropTable("dbo.Location");
            DropTable("dbo.GroupOfCompany");
            DropTable("dbo.FormInfo");
        }
    }
}
