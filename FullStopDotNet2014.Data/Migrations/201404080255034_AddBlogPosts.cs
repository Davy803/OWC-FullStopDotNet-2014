namespace FullStopDotNet2014.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogPosts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        Slug = c.String(),
                        Body = c.String(),
                        UserId = c.String(maxLength: 128),
                        PublishDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPosts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.BlogPosts", new[] { "UserId" });
            DropTable("dbo.BlogPosts");
        }
    }
}
