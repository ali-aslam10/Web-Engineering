using Microsoft.Data.SqlClient;

namespace Giggle_Garments_MVC.Models.Repositories
{
    public class CartRepository
    {
        string connectionstr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = GiggleGarmentsDB; Integrated Security = True;";
        public List<CartItem> cartItems = new List<CartItem>();
        public void add(CartItem c)
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "insert into CartItem (CartId,ProdId,Name,Size,Quantity,Price,Image) values(@cartid,@prodid,@name,@size,@quantity,@price,@image)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@cartid", c.CartId);
            cmd.Parameters.AddWithValue("@prodid", c.ProdId);
            cmd.Parameters.AddWithValue("@name", c.Name);
            cmd.Parameters.AddWithValue("@size", c.Size);
            cmd.Parameters.AddWithValue("@quantity", c.Quantity);
            cmd.Parameters.AddWithValue("@price", c.Price);
            cmd.Parameters.AddWithValue("@image", c.Image);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<CartItem> getCart(string id)
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "select * from CartItem where CartId='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cartItems.Add(new CartItem
                {
                    Id = dr["Id"].ToString(),
                    CartId = dr["CartId"].ToString(),
                    ProdId = Convert.ToInt32(dr["ProdId"]),
                    Name = dr["Name"].ToString(),
                    Size = dr["Size"].ToString(),
                    Quantity = Convert.ToInt32(dr["Quantity"]),
                    Price = Convert.ToDecimal(dr["Price"]),
                    Image = dr["Image"].ToString()
                });
            }
            dr.Close();
            return cartItems;
        }
        public void removeCart(string id)
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "Delete from CartItem where CartId='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }
        public void removefromCart(int Id)
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "Delete from CartItem where Id='" + Id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }
        public int getquantity(int Id)
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "Select Quantity from CartItem where Id='" + Id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            return Convert.ToInt32(dr["Quantity"]);
        }
        public bool isupdate(string cartid, int prodid, int qty, string size)
        {
            SqlConnection con = new SqlConnection(connectionstr);
            con.Open();
            string query = "update CartItem set Quantity=Quantity+@qty where CartId='" + cartid + "' AND ProdId='" + prodid + "'AND Size='" + size + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("qty", qty);

            int c = cmd.ExecuteNonQuery();
            con.Close();
            if (c == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }

}
