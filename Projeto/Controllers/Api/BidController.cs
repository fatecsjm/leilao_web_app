using AutoMapper;
using Microsoft.AspNet.Identity;
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
    public class BidController : ApiController
    {
        private ApplicationDbContext _context;

        public BidController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Bid
        public IHttpActionResult GetBids(int id)
        {
            var bids = _context.Bid.Where(d => d.Auction.Id == id).ToList().Select(Mapper.Map<Bid, BidDto>);
                //.Include(m => m.Price)
                //.Include(m => m.Artist)
                //.Include(m => m.Finality)
                //.Include(m => m.Category);
                
            //return Json(Bids.ToList().Select(Mapper.Map<Bid, BidDto>));
            return Json(bids);
        }

        //tem que ser user registado para criar uma bid

        //Post /api/bid/
        [Authorize]
        [HttpPost]
        public IHttpActionResult CreateBid(BidDto bidDto)
        {
            bidDto.DateHour = DateTime.Now;
            bidDto.ApplicationUser = new ApplicationUserDto();
            bidDto.ApplicationUser.Id = User.Identity.GetUserId();
            bidDto.ApplicationUser.UserName = User.Identity.Name;
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            var bid = Mapper.Map<BidDto, Bid>(bidDto);
            _context.Bid.Add(bid);
            _context.SaveChanges();

            bidDto.Id = bid.Id;

            //return paymentMethodDto;
            //return Created(new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority)), paymentMethodDto.Id);
            //return Created(new Uri(@"http://localhost:49642/paymentMethod"), paymentMethodDto.Id);
            //return Redirect(Url.Content("~/"));
            return Created(new Uri(Request.RequestUri + "/" + bid.Id), bidDto);

        }
    }
}
