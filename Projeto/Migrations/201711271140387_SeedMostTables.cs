namespace Projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMostTables : DbMigration
    {
        public override void Up()
        {
            Sql(@"
insert into PaymentMethods values
('ctt'),('multibanco'),('paypal'),('credito')
go

insert into Finalities values
('vender'),('leiloar'),('expor')
go

insert into AuctionStates values
('emEspera'),('aDecorrer'),('terminado'),('suspenso'),('cancelado')
go

insert into States values
('aguardaPagamento'),('emProcessamento'),('finalizada')
go

insert into Artists values
('antonio'),
('joana')
go

insert into categories values
('pintura'),('escultura'),('fotografia')
go

INSERT INTO [dbo].[ArtWorks] ([Artist_Id], [Finality_Id], [Category_Id], [Title], [CreationDate], [Description], [Image] )
VALUES
(1,1,1,'pintura1','2007-01-01','pintura de uma galinha para vender - art1',null),
(1,2,1,'pintura2','2006-01-01','pintura de uma galinha para leiloar - art1',null),
(1,1,2,'escultura1','2005-01-01','escultura de uma galinha para vender - art1','mypath'),
(1,2,2,'escultura1','2004-01-01','escultura de uma galinha para leiloar - art1','mypath2'),
(2,1,1,'pintura1','2004-01-01','pintura de uma galinha para vender - art2','mypath3'),
(2,2,1,'pintura2','2005-01-01','pintura de uma galinha para leiloar - art2',null),
(2,1,2,'escultura1','2006-01-01','escultura de uma galinha para vender - art2',null),
(2,2,2,'escultura1','2007-01-01','escultura de uma galinha para leiloar - art2','mypath4')
go

INSERT INTO [dbo].[Addresses] ([ApplicationUser_Id], [Line1], [Line2], [AddressNumber], [ZipCode], [Date])
VALUES
(1,'rua da alegria','lisboa','1','1000','2016-09-09 09:09:09'),
(1,'rua da amargura','lisboa','1','1000','2016-09-09 10:09:09'),
(1,'praça do camarão','porto','1','2000','2017-09-09 10:09:09'),
(2,'praça do azulejo','porto','1','2000','2017-09-09 10:09:19'),
(3,'rua amarela','porto','2000','1','2015-09-09 10:09:19'),
(3,'rua amarela','beja','4000','1','2016-09-09 10:09:19'),
(4,'rua amarela','beja','4000','1','2014-09-09 10:09:19')

INSERT INTO [dbo].[Auctions] ([ArtWork_Id], [AuctionState_Id], [InitialDate], [EndDate], [MinValue] )
VALUES
(1,5,'2015-01-01 10:12:09','2015-01-02 10:12:09',50.90),
(2,1,'2018-01-01 10:12:09','2018-01-02 10:12:09',50.90),
(4,2,'2015-01-01 10:12:09','2018-01-02 10:12:09',50.90),
(8,3,'2015-01-01 10:12:09','2016-01-02 10:12:09',50.90)
go

INSERT INTO [dbo].[Bids] ([ApplicationUser_Id],[Auction_Id],[DateHour], [value])
VALUES
(2,3,'2015-01-11 10:12:09:123 ',100),
(3,3,'2015-01-12 10:12:09:123 ',110),
(2,3,'2015-02-12 10:12:09:123 ',200),
(4,3,'2015-03-12 10:12:09:123 ',220),
(3,3,'2015-04-12 10:12:09:123 ',330),
(2,4,'2015-01-11 10:12:11:123 ',100),
(3,4,'2015-01-12 10:12:11:123 ',110),
(2,4,'2015-02-12 10:12:11:123 ',200),
(4,4,'2015-03-12 10:12:11:123 ',220),
(3,4,'2015-04-12 10:12:11:123 ',330),
(2,4,'2016-04-12 10:12:08:100 ',330),
(4,4,'2016-04-12 10:12:08:200 ',330.01)
go


");
        }
        
        public override void Down()
        {
        }
    }
}
