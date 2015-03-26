namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stocks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vaccines", "Administered", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vaccines", "Administered");
        }
    }
}
