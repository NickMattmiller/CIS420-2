namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appdbb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patient_Vaccination", "UserName", "dbo.EditUserViewModels");
            CreateTable(
                "dbo.LoginViewModels",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        RememberMe = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            AddForeignKey("dbo.Patient_Vaccination", "UserName", "dbo.LoginViewModels", "UserName");
            DropTable("dbo.EditUserViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EditUserViewModels",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            DropForeignKey("dbo.Patient_Vaccination", "UserName", "dbo.LoginViewModels");
            DropTable("dbo.LoginViewModels");
            AddForeignKey("dbo.Patient_Vaccination", "UserName", "dbo.EditUserViewModels", "UserName");
        }
    }
}
