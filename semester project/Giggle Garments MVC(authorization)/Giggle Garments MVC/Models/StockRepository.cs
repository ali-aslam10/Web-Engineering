using Microsoft.Data.SqlClient;
using System.Data;

namespace Giggle_Garments_MVC.Models
{
    public class StockRepository
    {
        string connectionstr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = GiggleGarmentsDB; Integrated Security = True;";
        List<Stock> stocks = new List<Stock>();
        public void add(Stock s)
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "insert into Stock (M0_3,M3_6,M6_9,M9_12,M24_36,Y3_4,Y4_5,Y5_6,Y6_7,Y7_8,Y8_9,Y9_10) values(@m0_3,@m3_6,@m6_9,@m9_12,@m24_36,@y3_4,@y4_5,@y5_6,@y6_7,@y7_8,@y8_9,@y9_10)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@m0_3", s._0to3M.HasValue ? s._0to3M.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@m3_6", s._3to6M.HasValue ? s._3to6M.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@m6_9", s._6to9M.HasValue ? s._6to9M.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@m9_12", s._9to12M.HasValue ? s._9to12M.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@m24_36", s._24to36M.HasValue ? s._24to36M.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@y3_4", s._3to4Y.HasValue ? s._3to4Y.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@y4_5", s._4to5Y.HasValue ? s._4to5Y.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@y5_6", s._5to6Y.HasValue ? s._5to6Y.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@y6_7", s._6to7Y.HasValue ? s._6to7Y.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@y7_8", s._7to8Y.HasValue ? s._7to8Y.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@y8_9", s._8to9Y.HasValue ? s._8to9Y.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@y9_10", s._9to10Y.HasValue ? s._9to10Y.Value : DBNull.Value);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update(Stock s)
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "Update Stock set M0_3=@m0_3,M3_6=@m3_6,M6_9=@m6_9,M9_12=@m9_12,M24_36=@m24_36,Y3_4=@y3_4,Y4_5=@y4_5,Y5_6=@y5_6,Y6_7=@y6_7,Y7_8=@y7_8,Y8_9=@y8_9,Y9_10=@y9_10 where ProductId='" + s.prod_Id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@m0_3", s._0to3M.HasValue ? s._0to3M.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@m3_6", s._3to6M.HasValue ? s._3to6M.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@m6_9", s._6to9M.HasValue ? s._6to9M.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@m9_12", s._9to12M.HasValue ? s._9to12M.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@m24_36", s._24to36M.HasValue ? s._24to36M.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@y3_4", s._3to4Y.HasValue ? s._3to4Y.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@y4_5", s._4to5Y.HasValue ? s._4to5Y.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@y5_6", s._5to6Y.HasValue ? s._5to6Y.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@y6_7", s._6to7Y.HasValue ? s._6to7Y.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@y7_8", s._7to8Y.HasValue ? s._7to8Y.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@y8_9", s._8to9Y.HasValue ? s._8to9Y.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@y9_10", s._9to10Y.HasValue ? s._9to10Y.Value : DBNull.Value);
            cmd.ExecuteNonQuery();
            con.Close();


        }
        public List<Stock> getAll()
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "select * from Stock";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                stocks.Add(new Stock
                {
                    prod_Id = Convert.ToInt32(dr["ProductId"]), // Assuming ProductId is not nullable
                    _0to3M = dr["M0_3"] is DBNull ?  null: (int)dr["M0_3"],  // Check if null handling is needed
                    _3to6M = dr["M3_6"] is DBNull ? null : (int)dr["M3_6"],
                    _6to9M = dr["M6_9"] is DBNull ? null : (int)dr["M6_9"] ,
                    _9to12M = dr["M9_12"] is DBNull ? null : (int)dr["M9_12"],
                    _24to36M = dr["M24_36"] is DBNull ? null : (int)dr["M24_36"],
                    _3to4Y = dr["Y3_4"] is DBNull ? null : (int)dr["Y3_4"],
                    _4to5Y = dr["Y4_5"] is DBNull ? null : (int)dr["Y4_5"],
                    _5to6Y = dr["Y5_6"] is DBNull ? null : (int)dr["Y5_6"],
                    _6to7Y = dr["Y6_7"] is DBNull ? null : (int)dr["Y6_7"],
                    _7to8Y = dr["Y7_8"] is DBNull ? null : (int)dr["Y7_8"],
                    _8to9Y = dr["Y8_9"] is DBNull ? null : (int)dr["Y8_9"],
                    _9to10Y = dr["Y9_10"] is DBNull ? null : (int)dr["Y9_10"],
                });
            }
            dr.Close();
            return stocks;
        }
        public Stock getbyId(int id)
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "select * from Stock";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            Stock s = new Stock();
            while (dr.Read())
            {

                s.prod_Id = Convert.ToInt32(dr["ProductId"]); // Assuming ProductId is not nullable
                s._0to3M = dr["M0_3"] is DBNull ? null : (int)dr["M0_3"];  // Check if null handling is needed
                s._3to6M = dr["M3_6"] is DBNull ? null : (int)dr["M3_6"];
                s._6to9M = dr["M6_9"] is DBNull ? null : (int)dr["M6_9"];
                s._9to12M = dr["M9_12"] is DBNull ? null : (int)dr["M9_12"];
                s._24to36M = dr["M24_36"] is DBNull ? null : (int)dr["M24_36"];
                s._3to4Y = dr["Y3_4"] is DBNull ? null : (int)dr["Y3_4"];
                s._4to5Y = dr["Y4_5"] is DBNull ? null : (int)dr["Y4_5"];
                s._5to6Y = dr["Y5_6"] is DBNull ? null : (int)dr["Y5_6"];
                s._6to7Y = dr["Y6_7"] is DBNull ? null : (int)dr["Y6_7"];
                s._7to8Y = dr["Y7_8"] is DBNull ? null : (int)dr["Y7_8"];
                s._8to9Y = dr["Y8_9"] is DBNull ? null : (int)dr["Y8_9"];
                s._9to10Y = dr["Y9_10"] is DBNull ? null : (int)dr["Y9_10"];
                
            }
            dr.Close();
            return s;
        }


    }
}
