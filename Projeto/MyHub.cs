using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Projeto.Dtos;
using System.Data.SqlClient;
using System.Data;

namespace Projeto
{
    
    public class MyHub : Hub
    {

        public void Welcome()
        {
            Clients.Caller.showWelcomeMessage();
        }

        public string DadosDoLeilao()
        {
            return "";
        }

        public void ActualizaBidsNoCliente(NewBid newBid)
        {

            //BidDto bidDto = new BidDto();
            //bidDto.Value = decimal.Parse(newBid.Value.ToString());
            newBid.DateHour = DateTime.Now;
            newBid.ApplicationUser = Context.User.Identity.GetUserId();
            //string str = Context.User.Identity.GetUserId();
            if (VerifyBid(newBid))
            {
                InsertNewBid(newBid);
                Clients.All.updateBids(newBid);
                Clients.Caller.bidMessage("a sua bid foi registada");
                Clients.All.updateBids(newBid);
            }
            else
            {
                Clients.Caller.bidMessage("erro: a sua bid não foi registada");
            }



        }


        public void Announce(string message)
        {/*
            if(VerifyBid(message))
            //Announce é o nome da função no lado do cliente. 
            //Todos os clientes
            Clients.All.c_announce(message);
            else
            {
                Clients.Caller.showBidError();
            }
            //Um cliente
            //Clients.Caller.DisplayDateTime();
            */
        }

        private bool VerifyBid(NewBid bid)
        {
            if (VerificarBidMaisAlta(bid.Value, bid.Auction, bid.ApplicationUser))
                return true;
            else
                return false;
        }

        private bool VerificarBidMaisAlta(decimal val, int aucId, string userId)
        {
            try
            {


            SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=VisualArtDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader myReader;

            cmd.CommandText = "SELECT TOP 1 * FROM Bids where Auction_Id = " + aucId.ToString() + " Order BY DateHour Desc";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();

                myReader = cmd.ExecuteReader();

            int id = 0;
            DateTime date;
            decimal valor;
            string user = "";
            int auctionId = 0;
 

                while (myReader.Read())
                {
                    id = myReader.GetInt32(0);
                    date = myReader.GetDateTime(1);
                    valor = myReader.GetDecimal(2);
                    user = myReader.GetString(3);
                    auctionId = myReader.GetInt32(4);
                }
            con.Close();
            if (id != 0 && user != userId)
                return true;
            else
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private bool InsertNewBid(NewBid bid)
        {
            SqlConnection con = new SqlConnection();

            SqlConnectionStringBuilder bldr = new SqlConnectionStringBuilder();
            bldr.DataSource = @"(LocalDb)\MSSQLLocalDB";
            bldr.InitialCatalog = "VisualArtDb";
            //bldr.UserID = "sa";
            //bldr.Password = "sa";

            con.ConnectionString = bldr.ConnectionString;

            using (SqlCommand command = con.CreateCommand())
            {
                command.CommandText = "INSERT INTO[dbo].[Bids]([DateHour], [value], [ApplicationUser_Id], [Auction_Id]) VALUES(@DateHour, CAST(@value AS Decimal(18, 2)), @u, @auction)";

                command.Parameters.AddWithValue("@DateHour", bid.DateHour);
                command.Parameters.AddWithValue("@value", bid.Value);
                command.Parameters.AddWithValue("@u", bid.ApplicationUser);
                command.Parameters.AddWithValue("@auction", bid.Auction);

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }

    public class NewBid
    {
        public DateTime? DateHour { get; set; }
        public string ApplicationUser { get; set; }
        public int Auction { get; set; }
        public Decimal Value { get; set; }

        public NewBid()
        {

        }

    }
}