using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class PaymentMethodController : Controller
    {
        private ApplicationDbContext _context;

        public PaymentMethodController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: PaymentMethod
        public ActionResult Index()
        {
            var paymentsMethods = _context.PaymentMethod.ToList();
            return View(paymentsMethods);
        }

        public ActionResult New()
        {
            var payment = new PaymentMethod();
            return View("PaymentMethodForm", payment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PaymentMethod paymentMethod)
        {
            if (!ModelState.IsValid)
            {
                return View("PaymentMethodForm");
            }


            if (paymentMethod.Id == 0)
                _context.PaymentMethod.Add(paymentMethod);
            else
            {
                var paymentMethodInDb = _context.PaymentMethod.Single(c => c.Id == paymentMethod.Id);
                paymentMethodInDb.Name = paymentMethod.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "paymentMethod");
        }

        //[Route("PaymentMethods/Edit/{id:regex(\\d{2}):range(1,1000)}")]
        public ActionResult Edit(int id)
        {
            var payment = _context.PaymentMethod.SingleOrDefault(p => p.Id == id);

            if (payment == null)
                return HttpNotFound();

            return View("PaymentMethodForm", payment);
        }




    }
}