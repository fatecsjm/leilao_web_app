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
    public class ArtWorkController : ApiController
    {
        private ApplicationDbContext _context;

        public ArtWorkController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/artwork
        public IHttpActionResult GetArtWorks()
        {
            
                var artWorks = _context.ArtWork.ToList();
                //.Include(m => m.Price)
                //.Include(m => m.Artist)
                //.Include(m => m.Finality)
                //.Include(m => m.Category);
                
            //return Json(artWorks.ToList().Select(Mapper.Map<ArtWork, ArtWorkDto>));
            return Json(artWorks.ToList());
        }

        public IHttpActionResult GetArtWork(int id)
        {// GET /api/artwork/1
            var artwork = _context.ArtWork.SingleOrDefault(c => c.Id == id);

            if (artwork == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            //return Ok(Mapper.Map<ArtWork, ArtWorkDto>(artwork));
            return Json(artwork);
        }
    }
}
