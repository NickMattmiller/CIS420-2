namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entityup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patient_Vaccination", "Barcode_NDC", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patient_Vaccination", "Barcode_NDC");
        }
    }
}
