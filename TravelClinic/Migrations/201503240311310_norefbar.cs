namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class norefbar : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Refugees", "Patient_BarCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Refugees", "Patient_BarCode", c => c.Long(nullable: false));
        }
    }
}
