using DvdLibrary.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.Interfaces
{
    public interface IDvdsRepository
    {

        List<Dvd> GetAll();
        Dvd GetById(int dvdId);
        void Insert(Dvd dvd);
        void Update(Dvd dvd);
        void Delete(int dvdId);
        List<Dvd> GetTitleSearch(string searchItem);
        List<Dvd> GetYearSearch(string searchItem);
        List<Dvd> GetDirectorSearch(string searchItem);
        List<Dvd> GetRatingSearch(string searchItem);
    }
}
