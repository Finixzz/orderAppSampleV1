namespace orderAppSampleV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTables : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Tables ON");
            Sql("INSERT INTO Tables(TableId) VALUES (1);");
            Sql("INSERT INTO Tables(TableId) VALUES (2);");
            Sql("INSERT INTO Tables(TableId) VALUES (3);");
            Sql("INSERT INTO Tables(TableId) VALUES (4);");
            Sql("INSERT INTO Tables(TableId) VALUES (5);");

        }

        public override void Down()
        {
        }
    }
}
