namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eightcreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vaccines", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vaccines", "Description");
        }
    }
}
