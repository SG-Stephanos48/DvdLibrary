using DvdLibrary.Data.Interfaces;
using DvdLibrary.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.ADO
{
    public class DvdsRepositoryADO : IDvdsRepository
    {
        public void Delete(int dvdId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("DvdsDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public List<Dvd> GetAll()
        {
            List<Dvd> dvds = new List<Dvd>();

            using(var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = dr["RealeaseYear"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public Dvd GetById(int dvdId)
        {
            Dvd dvd = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new Dvd(); 

                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.RealeaseYear = dr["RealeaseYear"].ToString();
                        dvd.Director = dr["Director"].ToString();
                        dvd.Rating = dr["Rating"].ToString();
                        dvd.Notes = dr["Notes"].ToString();

                        /*if (dr["ImageFileName"]) != DBNull.Value)
                                listing.ImageFileName = dr["ImageFileName"].ToString();*/
                        
                    }
                }
            }
            return dvd;
        }

        public void Insert(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DvdId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                /* 
                  	@Title nvarchar(128),
	                @RealeaseYear nvarchar(50),
	                @Director nvarchar(50),
	                @Rating nvarchar(50),
	                @Notes nvarchar(100)
                 * 
                 */

                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@RealeaseYear", dvd.RealeaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();

                dvd.DvdId = (int)param.Value;
            }
        }

        public void Update(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@RealeaseYear", dvd.RealeaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public List<Dvd> GetTitleSearch(string searchItem)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectTitle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@searchItem", searchItem);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = dr["RealeaseYear"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetYearSearch(string searchItem)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectYear", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@searchItem", searchItem);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = dr["RealeaseYear"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetDirectorSearch(string searchItem)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@searchItem", searchItem);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = dr["RealeaseYear"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetRatingSearch(string searchItem)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectRating", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@searchItem", searchItem);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = dr["RealeaseYear"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }
    }
}
