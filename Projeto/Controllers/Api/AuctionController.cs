using AutoMapper;
using Projeto.Dtos;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Projeto.Controllers.Api
{
    public class AuctionController : ApiController
    {
        private ApplicationDbContext _context;

        public AuctionController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/Auction
        public IHttpActionResult GetAuctions()
        {
            var auctions = _context.Auction.ToList().Select(Mapper.Map<Auction, AuctionDto>);

            return Json(auctions);
        }

        public IHttpActionResult GetAuction(int id)
        {// GET /api/Auction/1
            var auction = _context.Auction.SingleOrDefault(c => c.Id == id);

            if (auction == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            //return Mapper.Map<Auction, Auction>(auction);
            //return Ok(Mapper.Map<Auction, Auction>(auction));
            AuctionDto auct = Mapper.Map<Auction, AuctionDto>(auction);
            return Json(auct);

        }

        // POST /api/Auction
        [HttpPost]
        //para criar auction tem que ser admin
        //[Authorize]
        public IHttpActionResult CreateAuction(Auction Auction)
        {
            return Created(new Uri(Request.RequestUri + "/" + Auction.Id), Auction);
        }
        
    }
}
