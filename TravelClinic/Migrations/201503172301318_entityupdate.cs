namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entityupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RefugeeVaccines", "Refugee_RefugeeId", "dbo.Refugees");
            DropForeignKey("dbo.RefugeeVaccines", "Vaccine_Id", "dbo.Vaccines");
            DropIndex("dbo.RefugeeVaccines", new[] { "Refugee_RefugeeId" });
            DropIndex("dbo.RefugeeVaccines", new[] { "Vaccine_Id" });
            AddColumn("dbo.Patient_Vaccination", "RefugeeId", c => c.Int(nullable: true));
            CreateIndex("dbo.Patient_Vaccination", "RefugeeId");
            AddForeignKey("dbo.Patient_Vaccination", "RefugeeId", "dbo.Refugees", "RefugeeId", cascadeDelete: true);
            DropColumn("dbo.Patient_Vaccination", "Refugee_Num");
            DropTable("dbo.RefugeeVaccines");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RefugeeVaccines",
                c => new
                    {
                        Refugee_RefugeeId = c.Int(nullable: false),
                        Vaccine_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Refugee_RefugeeId, t.Vaccine_Id });
            
            AddColumn("dbo.Patient_Vaccination", "Refugee_Num", c => c.Int(nullable: false));
            DropForeignKey("dbo.Patient_Vaccination", "RefugeeId", "dbo.Refugees");
            DropIndex("dbo.Patient_Vaccination", new[] { "RefugeeId" });
            DropColumn("dbo.Patient_Vaccination", "RefugeeId");
            CreateIndex("dbo.RefugeeVaccines", "Vaccine_Id");
            CreateIndex("dbo.RefugeeVaccines", "Refugee_RefugeeId");
            AddForeignKey("dbo.RefugeeVaccines", "Vaccine_Id", "dbo.Vaccines", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RefugeeVaccines", "Refugee_RefugeeId", "dbo.Refugees", "RefugeeId", cascadeDelete: true);
        }
    }
}
