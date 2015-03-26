namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class twod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vaccines", "Two_Dim_Barcode", c => c.String());
            AddColumn("dbo.Vaccines", "Unit_Use_Barcode_NDC", c => c.String());
            AddColumn("dbo.Vaccines", "Lot_Number", c => c.String());
            AddColumn("dbo.Vaccines", "Brand_Name", c => c.String());
            AddColumn("dbo.Vaccines", "Package_Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vaccines", "Package_Name");
            DropColumn("dbo.Vaccines", "Brand_Name");
            DropColumn("dbo.Vaccines", "Lot_Number");
            DropColumn("dbo.Vaccines", "Unit_Use_Barcode_NDC");
            DropColumn("dbo.Vaccines", "Two_Dim_Barcode");
        }
    }
}
