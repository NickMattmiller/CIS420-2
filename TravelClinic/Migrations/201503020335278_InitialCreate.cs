namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NDC_Lookup",
                c => new
                    {
                        Barcode_NDC = c.Long(nullable: false),
                        QRCode = c.String(),
                        Route = c.String(),
                        Brand_Name = c.String(),
                        Code_CVX = c.Int(nullable: false),
                        Description_CVX = c.String(),
                        Description_Generic = c.String(),
                        Package_Name = c.String(),
                        Package_Type = c.String(),
                        Date_Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Barcode_NDC);
            
            CreateTable(
                "dbo.Vaccines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Barcode_NDC = c.Long(nullable: false),
                        Dose = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date_Added = c.DateTime(nullable: false),
                        Date_Expire = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NDC_Lookup", t => t.Barcode_NDC, cascadeDelete: true)
                .Index(t => t.Barcode_NDC);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vaccines", "Barcode_NDC", "dbo.NDC_Lookup");
            DropIndex("dbo.Vaccines", new[] { "Barcode_NDC" });
            DropTable("dbo.Vaccines");
            DropTable("dbo.NDC_Lookup");
        }
    }
}
