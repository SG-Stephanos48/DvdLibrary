using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using DvdLibrary.Data.EF;
using DvdLibrary.Data.Factories;
using DvdLibrary.Models.Tables;

namespace DvdLibrary.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Dvds1Controller : ApiController
    {
        private DvdLibraryEntities db = new DvdLibraryEntities();

        // GET: api/Dvds1
        [HttpGet, Route("api/Dvds1/")]
        public IHttpActionResult GetDvds()
        {
            List<Dvd> list = new List<Dvd>();
            list = DvdRepositoryFactory.GetRepository().GetAll();
            return Ok(list);
            //return db.Dvds;
        }
        
        // GET: api/Dvds1/5
        [ResponseType(typeof(Dvd))]
        [HttpGet, Route("api/Dvds1/{dvdId}")]
        public IHttpActionResult GetById(int dvdId)
        {
            Dvd dvd = DvdRepositoryFactory.GetRepository().GetById(dvdId);
            if (dvd == null)
            {
                return NotFound();
            }

            return Ok(dvd);
        }
        
        // PUT: api/Dvds1/5
        [ResponseType(typeof(void))]
        [HttpPut, Route("api/Dvds1/Update")]
        public IHttpActionResult PutDvd(Dvd dvd)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dvd dvd1 = DvdRepositoryFactory.GetRepository().GetById(dvd.DvdId);

            if (dvd1 == null)
            {
                return NotFound();
            }

            dvd1.Title = dvd.Title;
            dvd1.RealeaseYear = dvd.RealeaseYear;
            dvd1.Director = dvd.Director;
            dvd1.Rating = dvd.Rating;
            dvd1.Notes = dvd.Notes;

            DvdRepositoryFactory.GetRepository().Update(dvd1);

            return Ok(dvd1);

        }

        // POST: api/Dvds1
        [ResponseType(typeof(Dvd))]
        [HttpPost, Route("api/Dvds1/PostDvd")]
        public IHttpActionResult PostDvd(Dvd dvd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DvdRepositoryFactory.GetRepository().Insert(dvd);
            //db.SaveChanges();

            return Ok();
            //return Created($"api/Dvds1/{dvd.DvdId})", dvd);
            //return null;
            //return CreatedAtRoute("DefaultApi", new { id = dvd.DvdId }, dvd);
        }

        // DELETE: api/Dvds1/5
        [ResponseType(typeof(Dvd))]
        [HttpDelete, Route("api/Dvds1/{dvdId}")]
        public IHttpActionResult DeleteDvd(int dvdId)
        {
            Dvd dvd = DvdRepositoryFactory.GetRepository().GetById(dvdId);

            if (dvd == null)
            {

                return NotFound();

            }

            DvdRepositoryFactory.GetRepository().Delete(dvdId);
            return Ok();
            /*Dvd dvd = db.Dvds.Find(id);
            if (dvd == null)
            {
                return NotFound();
            }

            db.Dvds.Remove(dvd);
            db.SaveChanges();

            return Ok(dvd);
            */
        }

        // GET: api/Dvds1
        [HttpGet, Route("api/Dvds1/Title/{searchItem}")]
        public IHttpActionResult GetTitleSearch(string searchItem)
        {
            List<Dvd> list = new List<Dvd>();
            list = DvdRepositoryFactory.GetRepository().GetTitleSearch(searchItem);
            return Ok(list);
            //return db.Dvds;
        }

        // GET: api/Dvds1
        [HttpGet, Route("api/Dvds1/Year/{searchItem}")]
        public IHttpActionResult GetYearSearch(string searchItem)
        {
            List<Dvd> list = new List<Dvd>();
            list = DvdRepositoryFactory.GetRepository().GetYearSearch(searchItem);
            return Ok(list);
            //return db.Dvds;
        }

        // GET: api/Dvds1
        [HttpGet, Route("api/Dvds1/Director/{searchItem}")]
        public IHttpActionResult GetDirectorSearch(string searchItem)
        {
            List<Dvd> list = new List<Dvd>();
            list = DvdRepositoryFactory.GetRepository().GetDirectorSearch(searchItem);
            return Ok(list);
            //return db.Dvds;
        }

        // GET: api/Dvds1
        [HttpGet, Route("api/Dvds1/Rating/{searchItem}")]
        public IHttpActionResult GetRatingSearch(string searchItem)
        {
            List<Dvd> list = new List<Dvd>();
            list = DvdRepositoryFactory.GetRepository().GetRatingSearch(searchItem);
            return Ok(list);
            //return db.Dvds;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DvdExists(int id)
        {
            return db.Dvds.Count(e => e.DvdId == id) > 0;
        }
    }
}