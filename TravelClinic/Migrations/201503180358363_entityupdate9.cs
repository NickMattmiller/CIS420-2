namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entityupdate9 : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.Patient_Vaccination", "UserName", c => c.String(maxLength: 128));
            CreateIndex("dbo.Patient_Vaccination", "UserName");
            AddForeignKey("dbo.Patient_Vaccination", "UserName", "dbo.EditUserViewModels", "UserName");
            DropColumn("dbo.Patient_Vaccination", "Employee_Num");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patient_Vaccination", "Employee_Num", c => c.String());
            DropForeignKey("dbo.Patient_Vaccination", "UserName", "dbo.EditUserViewModels");
            DropIndex("dbo.Patient_Vaccination", new[] { "UserName" });
            DropColumn("dbo.Patient_Vaccination", "UserName");
            DropTable("dbo.EditUserViewModels");
        }
    }
}
