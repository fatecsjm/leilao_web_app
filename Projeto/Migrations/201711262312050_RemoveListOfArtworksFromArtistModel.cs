namespace Projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveListOfArtworksFromArtistModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Bids", "AuctionState_Id");
            DropForeignKey("dbo.Bids", "AuctionState_Id", "dbo.AuctionStates");
            //DropColumn("dbo.Bids", "AuctionState_Id");
        }
        
        public override void Down()
        {
        }
    }
}
