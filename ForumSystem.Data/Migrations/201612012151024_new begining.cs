namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newbegining : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortDescription = c.String(),
                        CreatedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Themes", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Themes", "CategoryId");
            AddForeignKey("dbo.Themes", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Themes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Themes", new[] { "CategoryId" });
            DropColumn("dbo.Themes", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
