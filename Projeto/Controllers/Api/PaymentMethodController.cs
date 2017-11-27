using AutoMapper;
using Projeto.Dtos;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto.Controllers.Api
{
    [Authorize]
    public class PaymentMethodController : ApiController
    {
        private ApplicationDbContext _context;

        public PaymentMethodController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/paymentmethod
        public IHttpActionResult GetPaymentMethods()
        {
            var paymentDtos = _context.PaymentMethod.ToList().Select(Mapper.Map<PaymentMethod, PaymentMethodDto>);
            return Ok(paymentDtos);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //}

        public IHttpActionResult GetPaymentMethod(int id)
        {// GET /api/paymentmethod/1
            var payment = _context.PaymentMethod.SingleOrDefault(c => c.Id == id);

            if (payment == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            //return Mapper.Map<PaymentMethod, PaymentMethodDto>(payment);
            //return Ok(Mapper.Map<PaymentMethod, PaymentMethodDto>(payment));
            return Json(payment);

        }

        // POST /api/paymentmethod
        [HttpPost]
        public IHttpActionResult CreatePaymentMethod(PaymentMethodDto paymentMethodDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            var paymentMethod = Mapper.Map<PaymentMethodDto, PaymentMethod>(paymentMethodDto);
            _context.PaymentMethod.Add(paymentMethod);
            _context.SaveChanges();

            paymentMethodDto.Id = paymentMethod.Id;

            //return paymentMethodDto;
            //return Created(new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority)), paymentMethodDto.Id);
            //return Created(new Uri(@"http://localhost:49642/paymentMethod"), paymentMethodDto.Id);
            //return Redirect(Url.Content("~/"));
            return Created(new Uri(Request.RequestUri + "/" + paymentMethod.Id), paymentMethodDto);
        }
        
        // PUT /api/paymentmethod/1
        [HttpPut]
        public IHttpActionResult UpdatePaymentMethod(int id, PaymentMethodDto paymentMethodDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var paymentInDb = _context.PaymentMethod.SingleOrDefault(c => c.Id == id);
            if (paymentInDb == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            Mapper.Map<PaymentMethodDto, PaymentMethod>(paymentMethodDto, paymentInDb);
            //Because of mapper we don't need the following lines
            //I'll keep them here for reference
            //paymentInDb.Name = paymentMethodDto.Name;
            _context.SaveChanges();

            return Ok();
        }

        // Delete /api/paymentmethod/1
        [HttpDelete]
        public IHttpActionResult DeletePaymentMethod(int id)
        {
            var paymentInDb = _context.PaymentMethod.SingleOrDefault(c => c.Id == id);
            if (paymentInDb == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            _context.PaymentMethod.Remove(paymentInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
