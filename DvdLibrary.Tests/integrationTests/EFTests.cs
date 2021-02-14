using DvdLibrary.Data.EF;
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
    public class EFTests
    {

        [SetUp]
        public void Init()
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
            var repo = new DvdsRepositoryEF();

            var dvds = repo.GetAll();

            Assert.AreEqual(3, dvds.Count);

        }

    }
}
