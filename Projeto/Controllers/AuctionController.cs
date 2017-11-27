using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class AuctionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View("NewAuctionForm");
        }

    }
}
