using DvdLibrary.Data.ADO;
using DvdLibrary.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Tests.integrationTests
{
    [TestFixture]
    public class AdoTests
    {

        [SetUp]
        public void Init ()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DvdLibrarySampleData";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadDvds()
        {
            var repo = new DvdsRepositoryADO();

            var dvds = repo.GetAll();

            Assert.AreEqual(3, dvds.Count);

        }

        [Test]
        public void CanLoadDvd()
        {
            var repo = new DvdsRepositoryADO();

            var dvd = repo.GetById(2);

            Assert.IsNotNull(dvd);
            Assert.IsTrue(dvd.DvdId == 2);
        }

        [Test]
        public void CanAddDvd()
        {
            Dvd dvdToAdd = new Dvd();
            var repo = new DvdsRepositoryADO();

            dvdToAdd.Title = "Back to Future";
            dvdToAdd.RealeaseYear = "1986";
            dvdToAdd.Director = "Quniton Tarantino";
            dvdToAdd.Rating = "PG-13";
            dvdToAdd.Notes = "Scientifically Inaccurate";

            repo.Insert(dvdToAdd);
        }

        [Test]
        public void CanUpdateDvd()
        {
            Dvd dvdToUpdate = new Dvd();
            var repo = new DvdsRepositoryADO();

            dvdToUpdate.Title = "Back to the Future";
            dvdToUpdate.RealeaseYear = "1986";
            dvdToUpdate.Director = "Quniton Tarantino";
            dvdToUpdate.Rating = "PG-13";
            dvdToUpdate.Notes = "Scientifically Inaccurate";

            repo.Insert(dvdToUpdate);

            dvdToUpdate.Title = "Back to the Future II";
            dvdToUpdate.RealeaseYear = "1989";
            dvdToUpdate.Director = "Quniton Tarantino";
            dvdToUpdate.Rating = "PG-13";
            dvdToUpdate.Notes = "Scientifically Even More Inaccurate";

            repo.Update(dvdToUpdate);

            var updatedDvd = repo.GetById(5);

            Assert.AreEqual("Back to the Future II", updatedDvd.Title);
        }

        [Test]
        public void CanDeleteDvd()
        {
            Dvd dvdToAdd = new Dvd();
            var repo = new DvdsRepositoryADO();

            dvdToAdd.Title = "Back to Future";
            dvdToAdd.RealeaseYear = "1986";
            dvdToAdd.Director = "Quniton Tarantino";
            dvdToAdd.Rating = "PG-13";
            dvdToAdd.Notes = "Scientifically Inaccurate";

            repo.Insert(dvdToAdd);

            var loaded = repo.GetById(2);
            Assert.IsNotNull(loaded);

            repo.Delete(2);
            loaded = repo.GetById(2);

            Assert.IsNull(loaded);
        }

    }
}
