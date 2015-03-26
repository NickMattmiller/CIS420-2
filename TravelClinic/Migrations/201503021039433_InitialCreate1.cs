namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VaccineNDCGroups",
                c => new
                    {
                        Barcode_NDC = c.Long(nullable: false, identity: true),
                        VaccineCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Barcode_NDC);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VaccineNDCGroups");
        }
    }
}
