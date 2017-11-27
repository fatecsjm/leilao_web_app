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
            var artWorks = _context.ArtWork.ToList().Select(Mapper.Map<ArtWork, ArtWorkDto>);
                //.Include(m => m.Price)
                //.Include(m => m.Artist)
                //.Include(m => m.Finality)
                //.Include(m => m.Category);
                
            //return Json(artWorks.ToList().Select(Mapper.Map<ArtWork, ArtWorkDto>));
            return Json(artWorks);
        }

        public IHttpActionResult GetArtWork(int id)
        {// GET /api/artwork/1
            var artwork = _context.ArtWork.SingleOrDefault(c => c.Id == id);

            if (artwork == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            ArtWorkDto art = Mapper.Map<ArtWork, ArtWorkDto>(artwork);
            //return Ok(Mapper.Map<ArtWork, ArtWorkDto>(artwork));
            return Json(art);
        }

        //para criar obra tem que ser admin
        //[Authorize]
        //[Authorize(Roles = "Rambo")]
        [HttpPost]
        public IHttpActionResult CreateArtWork(ArtWorkDto artworkDto)
        {
            //if (!ModelState.IsValid)
            //    //throw new HttpResponseException(HttpStatusCode.BadRequest);
            //    return BadRequest();
            var artwork = Mapper.Map<ArtWorkDto, ArtWork>(artworkDto);
            _context.ArtWork.Add(artwork);
            _context.SaveChanges();

            //return paymentMethodDto;
            //return Created(new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority)), paymentMethodDto.Id);
            //return Created(new Uri(@"http://localhost:49642/paymentMethod"), paymentMethodDto.Id);
            //return Redirect(Url.Content("~/"));
            return Created(new Uri(Request.RequestUri + "/" + artwork.Id), artwork);
        }



    }
}
