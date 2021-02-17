using DvdLibrary.Data.Interfaces;
using DvdLibrary.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.EF
{
    public class DvdsRepositoryEF : IDvdsRepository
    {
        /*private readonly DataContext _context;
        public DvdsRepositoryEF(DataContext context)
        {
            _context = context;
        }*/

        private DvdLibraryEntities db = new DvdLibraryEntities();

        public void Delete(int dvdId)
        {
            var dvd = db.Dvds.FirstOrDefault(c => c.DvdId == dvdId);
            db.Dvds.Remove(dvd);
            db.SaveChanges();
        }

        public List<Dvd> GetAll()
        {
            var dvds = db.Dvds.ToList();
            return dvds;
        }

        public Dvd GetById(int dvdId)
        {
            var dvd = db.Dvds.FirstOrDefault(c => c.DvdId == dvdId);
            return dvd;
        }

        public List<Dvd> GetDirectorSearch(string searchItem)
        {
            var dvds = db.Dvds.Where(c=>c.Director == searchItem).ToList();
            return dvds;
        }

        public List<Dvd> GetRatingSearch(string searchItem)
        {
            var dvds = db.Dvds.Where(c => c.Rating == searchItem).ToList();
            return dvds;
        }

        public List<Dvd> GetTitleSearch(string searchItem)
        {
            var dvds = db.Dvds.Where(c => c.Title == searchItem).ToList();
            return dvds;
        }

        public List<Dvd> GetYearSearch(string searchItem)
        {
            var dvds = db.Dvds.Where(c => c.RealeaseYear == searchItem).ToList();
            return dvds;
        }

        public void Insert(Dvd dvd)
        {

            dvd.DvdId = db.Dvds.Max(x => x.DvdId) + 1;
            db.Dvds.Add(dvd);
            db.SaveChanges();

        }

        public void Update(Dvd dvd)
        {
            Dvd dvdnew = new Dvd();

            dvdnew = db.Dvds.FirstOrDefault(c => c.DvdId == dvd.DvdId);

            dvdnew.DvdId = dvd.DvdId;
            dvdnew.Title = dvd.Title;
            dvdnew.RealeaseYear = dvd.RealeaseYear;
            dvdnew.Director = dvd.Director;
            dvdnew.Rating = dvd.Rating;
            dvdnew.Notes = dvd.Notes;

            db.SaveChanges();

        }

    }
}
