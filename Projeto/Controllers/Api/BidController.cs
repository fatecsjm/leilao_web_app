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
        //[Authorize]
        //Post /api/bid/{id da auction}
    }
}
