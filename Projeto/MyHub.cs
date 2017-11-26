using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public void actualizaBidsNoCliente(string cliente, string bid)
        {
            List<string> list = new List<string>();
            list.Add(DateTime.Now.ToString());
            list.Add(bid);
            list.Add(cliente);
            Clients.All.updateBids(list);
        }


        public void Announce(string message)
        {
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
        }

        private bool VerifyBid(string bid)
        {
            if (bid == "123")
                return true;
            else
                return false;
        }
    }
}