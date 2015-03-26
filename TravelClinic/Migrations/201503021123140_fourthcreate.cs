namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourthcreate : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.VaccineNDCGroups");
            AlterColumn("dbo.VaccineNDCGroups", "Barcode_NDC", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.VaccineNDCGroups", "Barcode_NDC");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.VaccineNDCGroups");
            AlterColumn("dbo.VaccineNDCGroups", "Barcode_NDC", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.VaccineNDCGroups", "Barcode_NDC");
        }
    }
}
