namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifthcreate : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VaccineNDCGroups",
                c => new
                    {
                        Barcode_NDC = c.Long(nullable: false),
                        VaccineCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Barcode_NDC);
            
        }
    }
}
