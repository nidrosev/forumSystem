namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixProblemAuthorIdTheme2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Themes", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Themes", new[] { "Author_Id" });
            DropColumn("dbo.Themes", "Author_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Themes", "Author_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Themes", "Author_Id");
            AddForeignKey("dbo.Themes", "Author_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
