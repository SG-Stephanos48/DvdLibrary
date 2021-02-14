using DvdLibrary.Data.Interfaces;
using DvdLibrary.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.Mock
{
    public class DvdsRepositoryMock : IDvdsRepository
    {

        public static List<Dvd> _dvds = new List<Dvd>
        {
            new Dvd
            {
                DvdId = 1,
                Title = "The Goonies",
                RealeaseYear = "1985",
                Director = "Helen English",
                Rating = "PG-13",
                Notes = ""
            },
            new Dvd
            {
                DvdId = 2,
                Title = "Ghostbusters",
                RealeaseYear = "1984",
                Director = "Shiba The Great",
                Rating = "PG-13",
                Notes = ""
            },
            new Dvd
            {
                DvdId = 3,
                Title = "The Matrix",
                RealeaseYear = "1997",
                Director = "Persephone English",
                Rating = "R",
                Notes = "beware the sequels"
            }

        };
        
        public void Delete(int dvdId)
        {
            _dvds.RemoveAll(m => m.DvdId == dvdId);
        }

        public List<Dvd> GetAll()
        {
            return _dvds;
        }

        public Dvd GetById(int dvdId)
        {
            return _dvds.FirstOrDefault(m => m.DvdId == dvdId);
        }

        public List<Dvd> GetDirectorSearch(string searchItem)
        {
            return _dvds.Where<Dvd>(c => c.Director == searchItem).ToList();
        }

        public List<Dvd> GetRatingSearch(string searchItem)
        {
            return _dvds.Where<Dvd>(c => c.Rating == searchItem).ToList();
        }

        public List<Dvd> GetTitleSearch(string searchItem)
        {
            return _dvds.Where<Dvd>(c => c.Title == searchItem).ToList();
        }

        public List<Dvd> GetYearSearch(string searchItem)
        {
            return _dvds.Where<Dvd>(c => c.RealeaseYear == searchItem).ToList();
        }

        public void Insert(Dvd dvd)
        {
            dvd.DvdId = _dvds.Max(x => x.DvdId) + 1;
            _dvds.Add(dvd);
        }

        public void Update(Dvd dvd)
        {
            var found = _dvds.FirstOrDefault(m => m.DvdId == dvd.DvdId);

            if (found != null)
                found = dvd;
        }
    }
}
