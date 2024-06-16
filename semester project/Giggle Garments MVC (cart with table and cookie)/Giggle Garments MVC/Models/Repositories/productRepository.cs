using System;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Microsoft.Data.SqlClient;
using NuGet.Common;
namespace Giggle_Garments_MVC.Models.Repositories
{

    public class productRepository
    {
        
        IRepository<Product> _repository = new GenericRepository<Product>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = GiggleGarmentsDB; Integrated Security = True;");
        
        string connectionstr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = GiggleGarmentsDB; Integrated Security = True;";
        public List<Product> products = new List<Product>();
        public void Add(Product p)
        {
            
            _repository.Add(p);
        }

        public IEnumerable<Product> GetAll()
        {
            
            return _repository.GetAll();
        }
        public Product GetById(int id)
        {
          
            return _repository.GetById(id);
        }

        public List<Product> getbycategoryId(int id)
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "select * from Product where CategoryId='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            Product p = new Product();
            while (dr.Read())
            {

                products.Add(new Product
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Price = Convert.ToDecimal(dr["Price"]),
                    CategoryId = Convert.ToInt32(dr["CategoryId"]),
                    ImagePath = dr["Imagepath"].ToString()
                });

            }
            dr.Close();
            return products;
        }

        public List<Product> getNewIn()
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "select top 12 * from Product  order by Id desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                products.Add(new Product
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Price = Convert.ToDecimal(dr["Price"]),
                    CategoryId = Convert.ToInt32(dr["CategoryId"]),
                    ImagePath = dr["Imagepath"].ToString()
                });
            }
            dr.Close();
            return products;
        }
        public void Update(Product p)
        {

            _repository.Update(p);

        }
        public void Delete(int id)
        {
            //First delete Stock
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open(); 
            string query = "Delete from Stock where Id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();

            _repository.Delete(id);


        }

    }



}
