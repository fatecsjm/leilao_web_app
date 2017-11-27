namespace Projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherUpdate : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Bids");
            DropPrimaryKey("dbo.Prices");
            //AddColumn("dbo.Bids", "Id", c => c.Int(nullable: false, identity: true));
            //AddColumn("dbo.Bids", "DateHour", c => c.DateTime(nullable: false));
            //AddColumn("dbo.Prices", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Bids", "Id");
            AddPrimaryKey("dbo.Prices", "Id");
            //DropColumn("dbo.Bids", "date_hour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bids", "date_hour", c => c.DateTime(nullable: false));
            DropPrimaryKey("dbo.Prices");
            DropPrimaryKey("dbo.Bids");
            DropColumn("dbo.Prices", "Id");
            DropColumn("dbo.Bids", "DateHour");
            DropColumn("dbo.Bids", "Id");
            AddPrimaryKey("dbo.Prices", "DateHour");
            AddPrimaryKey("dbo.Bids", "date_hour");
        }
    }
}
