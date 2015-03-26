namespace asp.netmvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class grantcreate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrantManagerModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Grant_Name = c.String(nullable: false),
                        Grant_Description = c.String(nullable: false),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GrantManagerModels");
        }
    }
}
