namespace Filmy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValueToNumberAvailable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
        }
    }
}
