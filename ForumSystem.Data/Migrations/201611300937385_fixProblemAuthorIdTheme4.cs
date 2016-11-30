namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixProblemAuthorIdTheme4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Themes", name: "Author_Id", newName: "AuthorId");
            RenameIndex(table: "dbo.Themes", name: "IX_Author_Id", newName: "IX_AuthorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Themes", name: "IX_AuthorId", newName: "IX_Author_Id");
            RenameColumn(table: "dbo.Themes", name: "AuthorId", newName: "Author_Id");
        }
    }
}
