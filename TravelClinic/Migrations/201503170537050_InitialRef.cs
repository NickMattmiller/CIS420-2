namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialRef : DbMigration
    {
        public override void Up()
        {
           
            
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Solution = c.String(),
                        Submitted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
          
            
          
            
           
          
            
            CreateTable(
                "dbo.Refugees",
                c => new
                    {
                        RefugeeId = c.Int(nullable: false, identity: true),
                        Patient_BarCode = c.Long(nullable: false),
                        Date_Added = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Laungage = c.String(),
                        OriginCountry = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.RefugeeId);
            
            CreateTable(
                "dbo.RefugeeVaccines",
                c => new
                    {
                        Refugee_RefugeeId = c.Int(nullable: false),
                        Vaccine_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Refugee_RefugeeId, t.Vaccine_Id })
                .ForeignKey("dbo.Refugees", t => t.Refugee_RefugeeId, cascadeDelete: true)
                .ForeignKey("dbo.Vaccines", t => t.Vaccine_Id, cascadeDelete: true)
                .Index(t => t.Refugee_RefugeeId)
                .Index(t => t.Vaccine_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RefugeeVaccines", "Vaccine_Id", "dbo.Vaccines");
            DropForeignKey("dbo.RefugeeVaccines", "Refugee_RefugeeId", "dbo.Refugees");
            DropIndex("dbo.RefugeeVaccines", new[] { "Vaccine_Id" });
            DropIndex("dbo.RefugeeVaccines", new[] { "Refugee_RefugeeId" });
            DropTable("dbo.RefugeeVaccines");
            DropTable("dbo.Refugees");
           
            DropTable("dbo.FAQs");
        }
    }
}
