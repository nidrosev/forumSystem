namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryIdupdatetobenull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Themes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Themes", new[] { "CategoryId" });
            AlterColumn("dbo.Themes", "CategoryId", c => c.Int());
            CreateIndex("dbo.Themes", "CategoryId");
            AddForeignKey("dbo.Themes", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Themes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Themes", new[] { "CategoryId" });
            AlterColumn("dbo.Themes", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Themes", "CategoryId");
            AddForeignKey("dbo.Themes", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
