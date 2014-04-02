namespace FullStopDotNet2014.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTextResources : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TextResources",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Culture = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                    })
                .PrimaryKey(t => new { t.Name, t.Culture });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TextResources");
        }
    }
}
