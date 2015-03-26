namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entityupdate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patient_Vaccination", "Employee_Num", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patient_Vaccination", "Employee_Num", c => c.Int(nullable: false));
        }
    }
}
