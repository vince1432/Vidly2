namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;
    
    public partial class movies : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rentals", name: "Movie_Id", newName: "Movies_Id");
            RenameIndex(table: "dbo.Rentals", name: "IX_Movie_Id", newName: "IX_Movies_Id");
            AddColumn("dbo.Movies", "Available", c => c.Byte(nullable: false));
            Sql("Update Movie SET Available =Stock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Available");
            RenameIndex(table: "dbo.Rentals", name: "IX_Movies_Id", newName: "IX_Movie_Id");
            RenameColumn(table: "dbo.Rentals", name: "Movies_Id", newName: "Movie_Id");
        }
    }
}
