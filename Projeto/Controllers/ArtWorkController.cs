using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class ArtWorkController : Controller
    {
        private ApplicationDbContext _context;

        public ArtWorkController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: ArtWork
        public ActionResult Index()
        {
            //var paymentsMethods = _context.ArtWork.ToList();
            //return View(paymentsMethods);
            return View();
        }

        public ActionResult New()
        {
            //var payment = new ArtWork();
            //payment.id =0
            //return View("ArtWorkForm", payment);
            return View("NewArtWorkForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ArtWork artWork)
        {
            if (!ModelState.IsValid)
            {
                return View("NewArtWorkForm");
            }


            if (artWork.Id == 0)
                _context.ArtWork.Add(artWork);
            else
            {
                var ArtWorkInDb = _context.ArtWork.Single(c => c.Id == artWork.Id);
                ArtWorkInDb.Title = artWork.Title;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "ArtWork");
        }

        //[Route("ArtWorks/Edit/{id:regex(\\d{2}):range(1,1000)}")]
        public ActionResult Edit(int id)
        {
            /*var payment = _context.ArtWork.SingleOrDefault(p => p.Id == id);

            if (payment == null)
                return HttpNotFound();

            return View("ArtWorkForm", payment);
            */
            ViewBag.payId = id;
            return View("EditArtWorkForm");
        }




    }
}