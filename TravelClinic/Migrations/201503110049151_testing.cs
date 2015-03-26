namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing : DbMigration
    {
        public override void Up()
        {
           
            
            CreateTable(
                "dbo.Patient_Vaccination",
                c => new
                    {
                        AdministeredID = c.Int(nullable: false, identity: true),
                        VaccineID = c.Int(nullable: false),
                        Refugee_Num = c.Int(nullable: false),
                        Patient_Num = c.Int(nullable: false),
                        Employee_Num = c.Int(nullable: false),
                        Price_Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Site_Administered = c.String(),
                        Date_Administered = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AdministeredID)
                .ForeignKey("dbo.Vaccines", t => t.VaccineID, cascadeDelete: true)
                .Index(t => t.VaccineID);
            
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient_Vaccination", "VaccineID", "dbo.Vaccines");
            
          
            DropTable("dbo.Patient_Vaccination");
           
       
        }
    }
}
