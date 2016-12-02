namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddfieldUpdatedOn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "UpdatedOn", c => c.DateTime());
            AddColumn("dbo.Themes", "UpdatedOn", c => c.DateTime());
            AddColumn("dbo.Comments", "UpdatedOn", c => c.DateTime());
            AddColumn("dbo.Likes", "UpdatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Likes", "UpdatedOn");
            DropColumn("dbo.Comments", "UpdatedOn");
            DropColumn("dbo.Themes", "UpdatedOn");
            DropColumn("dbo.Categories", "UpdatedOn");
        }
    }
}
