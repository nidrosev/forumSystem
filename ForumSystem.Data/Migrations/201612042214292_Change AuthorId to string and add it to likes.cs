namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAuthorIdtostringandaddittolikes : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropColumn("dbo.Comments", "AuthorId");
            RenameColumn(table: "dbo.Comments", name: "Author_Id", newName: "AuthorId");
            AddColumn("dbo.Likes", "AuthorId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Comments", "AuthorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "AuthorId");
            CreateIndex("dbo.Likes", "AuthorId");
            AddForeignKey("dbo.Likes", "AuthorId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Likes", new[] { "AuthorId" });
            DropIndex("dbo.Comments", new[] { "AuthorId" });
            AlterColumn("dbo.Comments", "AuthorId", c => c.Int(nullable: false));
            DropColumn("dbo.Likes", "AuthorId");
            RenameColumn(table: "dbo.Comments", name: "AuthorId", newName: "Author_Id");
            AddColumn("dbo.Comments", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "Author_Id");
        }
    }
}
