using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto.Controllers.Api
{
    public class PaymentMethodController : ApiController
    {

        private ApplicationDbContext _context;

        public PaymentMethodController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/paymentmethod
        public IEnumerable<PaymentMethod> GetPaymentMethods()
        {

            return _context.PaymentMethod.ToList();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //}

        // GET /api/paymentmethod/1
        public PaymentMethod GetPaymentMethod(int id)
        {
            var payment = _context.PaymentMethod.SingleOrDefault(c => c.Id == id);

            if (payment == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return payment;
        }

        // POST /api/paymentmethod
        [HttpPost]
        public PaymentMethod CreatePaymentMethod(PaymentMethod paymentMethod)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.PaymentMethod.Add(paymentMethod);
            _context.SaveChanges();

            return paymentMethod;
        }
        // PUT /api/paymentmethod/1
        [HttpPut]
        public void UpdatePaymentMethod(int id, PaymentMethod paymentMethod)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var paymentInDb = _context.PaymentMethod.SingleOrDefault(c => c.Id == id);
            if (paymentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            paymentInDb.Name = paymentMethod.Name;
            _context.SaveChanges();

        }

        // Delete /api/paymentmethod/1
        [HttpDelete]
        public void DeletePaymentMethod(int id)
        {
            var paymentInDb = _context.PaymentMethod.SingleOrDefault(c => c.Id == id);
            if (paymentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.PaymentMethod.Remove(paymentInDb);
            _context.SaveChanges();

        }
    }
}
