namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class norefbar2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patient_Vaccination", "Patient_Num");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patient_Vaccination", "Patient_Num", c => c.Int(nullable: false));
        }
    }
}
