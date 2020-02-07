namespace orderAppSampleV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialOrderRecord : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Orders (Id, ItemId, Date, TableId, UserId, Quantity)" +
                " VALUES (1, 11, 7/2/2020, 1, 1, 3);");
        }
        
        public override void Down()
        {
        }
    }
}
