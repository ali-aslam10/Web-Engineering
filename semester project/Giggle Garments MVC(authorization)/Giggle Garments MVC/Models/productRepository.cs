using System;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Microsoft.Data.SqlClient;
namespace Giggle_Garments_MVC.Models
{
    
    public class productRepository
    {
        string connectionstr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = GiggleGarmentsDB; Integrated Security = True;";
        public List<Product> products = new List<Product>();
        public void add(Product p)
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "insert into Product (Name,Description,price,CategoryId,Imagepath) values(@name,@desc,@pr,@categoyId,@image)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("name", p.name);
            cmd.Parameters.AddWithValue("desc", p.description);
            cmd.Parameters.AddWithValue("pr", p.price);
            cmd.Parameters.AddWithValue("categoyId", p.category_Id);
            cmd.Parameters.AddWithValue("image",p.imagePath);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update()
        {


        }
        public List<Product> getAll()
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "select * from Product";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                products.Add(new Product
                {
                    prod_Id = Convert.ToInt32(dr["ProductId"]),
                    name = dr["Name"].ToString(),
                    description = dr["Description"].ToString(),
                    price = Convert.ToDecimal(dr["Price"]),
                    category_Id = Convert.ToInt32(dr["CategoryId"]),
                    imagePath = dr["Imagepath"].ToString()
                }); 
            }
            dr.Close();
            return products;
        }
        public Product getbyId(int id)
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "select * from Product where ProductId='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            Product p=new Product();
            while (dr.Read())
            {

                p.prod_Id = Convert.ToInt32(dr["ProductId"]);
                p.name = dr["Name"].ToString();
                p.description = dr["Description"].ToString();
                p.price = Convert.ToDecimal(dr["Price"]);
                p.category_Id = Convert.ToInt32(dr["CategoryId"]);
                p.imagePath = dr["Imagepath"].ToString();
                
            }
            dr.Close();
            return p;
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
                    prod_Id = Convert.ToInt32(dr["ProductId"]),
                    name = dr["Name"].ToString(),
                    description = dr["Description"].ToString(),
                    price = Convert.ToDecimal(dr["Price"]),
                    category_Id = Convert.ToInt32(dr["CategoryId"]),
                    imagePath = dr["Imagepath"].ToString()
                });

            }
            dr.Close();
            return products;
        }
        public void UpdateProduct(Product p)
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "update Product set Name=@name,Description=@desc,Price=@pr,CategoryId=@categoyId where ProductId='" + p.prod_Id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("name", p.name);
            cmd.Parameters.AddWithValue("desc", p.description);
            cmd.Parameters.AddWithValue("pr", p.price);
            cmd.Parameters.AddWithValue("categoyId", p.category_Id);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void removeProduct(int id)
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            //First delete Stock
            string query = "Delete from Stock where ProductId='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            //Now Delete Product
            query = "Delete from Product where ProductId='" + id + "'";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();


        }

    }
       
        
    
}
