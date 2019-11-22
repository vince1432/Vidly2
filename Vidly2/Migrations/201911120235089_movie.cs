namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movie : DbMigration
    {
        public override void Up()
        {
            Sql("Update Movies SET Available =Stock");
        }
        
        public override void Down()
        {
        }
    }
}
