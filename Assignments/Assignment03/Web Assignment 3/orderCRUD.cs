using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Web_Assignment_3
{
    class orderCRUD
    {
       
        private SqlDataAdapter da;
        private int customerid;
        DataTable ourOrders;
        
        private int generateId()
        {
            string query = "SELECT COUNT(*) FROM Customers";
            SqlConnection connection = new SqlConnection(ConnectionString.connectiostr);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int recordCount = (int)command.ExecuteScalar();
            return recordCount;
        }
        
        public orderCRUD()
        {
           
            customerid = generateId();   //id for customer
            da = new SqlDataAdapter();
            ourOrders = new DataTable();
           
        }
        public void createOrder(Order order)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectiostr);
            string q1 = "insert into Orders values(@id,@pcode,@pname,@psize,@pquantity,@price,@cusname,@cusaddress,@cuscontact)";
            con.Open();
            SqlCommand cmd = new SqlCommand(q1, con);
            cmd.Parameters.AddWithValue("id",order.OrderId);
            cmd.Parameters.AddWithValue("pcode", order.ProductCode);
            cmd.Parameters.AddWithValue("pname", order.ProductName);
            cmd.Parameters.AddWithValue("psize", order.ProductSize);
            cmd.Parameters.AddWithValue("pquantity", order.ProductQuantity);
            cmd.Parameters.AddWithValue("price", order.Price);
            cmd.Parameters.AddWithValue("cusname", order.CustomerName);
            cmd.Parameters.AddWithValue("cusaddress", order.CustomerAddress);
            cmd.Parameters.AddWithValue("cuscontact", order.CustomerContact);
            
            cmd.ExecuteNonQuery();
            
            string cus_ID= "Cus-" + (++customerid).ToString();
            q1 = "insert into Customers values(@id,@cusname,@cusaddress,@cuscontact)";
            cmd = new SqlCommand(q1, con);
            cmd.Parameters.AddWithValue("id", cus_ID);
            cmd.Parameters.AddWithValue("cusname", order.CustomerName);
            cmd.Parameters.AddWithValue("cusaddress", order.CustomerAddress);
            cmd.Parameters.AddWithValue("cuscontact", order.CustomerContact);
            cmd.ExecuteNonQuery();
            con.Close();
         
        }
        public bool updateOrder(int id)
        {
            
            SqlConnection con = new SqlConnection(ConnectionString.connectiostr);
            string updatequery = "update Orders set ProductSize=@psize,ProductQuantity=@pquantity,Price=@pr where OrderId=@id";
            SqlCommand updatecmd = new SqlCommand(updatequery, con);
            updatecmd.Parameters.Add("psize", SqlDbType.NChar, 10, "ProductSize");
            updatecmd.Parameters.Add("pquantity", SqlDbType.Int, 0, "ProductQuantity");
            updatecmd.Parameters.Add("pr", SqlDbType.Float, 53, "Price");
            updatecmd.Parameters.Add("id", SqlDbType.Int, 0, "OrderId");
            string delquery = "Delete from Orders where OrderId=@id";
            SqlCommand delcmd = new SqlCommand(delquery, con);
            delcmd.Parameters.Add("id", SqlDbType.Int, 0, "OrderId");

            string q1 = "select * from Orders where OrderId=@id";
            SqlCommand cmd = new SqlCommand(q1, con);
            cmd.Parameters.AddWithValue("id", id);
            da.SelectCommand = cmd;
            int count=da.Fill(ourOrders);
            if(count==0)
            {
                Console.WriteLine($"No Order Id: {id} found...!");
                return false;
            }
            ourOrders.PrimaryKey = new DataColumn[] { ourOrders.Columns["OrderId"] };
            DataRow row = ourOrders.Rows.Find(id);
            Console.WriteLine("\n\n\t\t\t\t\t\tOrder detailS:\n");

            Console.Write($"Order Id:{row[0]}\nProduct Code:{row[1]}\nProduct Name:{row[2]}\nProduct Size:{row[3]}\nProduct Quantity:{row[4]}\nPrice:{row[5]}\nCustomer Name:{row[6]}\nCustomer Address:{row[7]}\nCustomer Contact:{row[8]}\n");
            
            Console.WriteLine("\nSelect what you want:\n1.Change Product Quantity\n2.Change Product Size\n3.Delete Order");
            Console.Write("Choice:");
            int ch = int.Parse(Console.ReadLine());
            while(ch<0||ch>3)
            {
                Console.WriteLine("Invalid Choice...! Select again.");
                Console.Write("Choice:");
                ch = int.Parse(Console.ReadLine());
            }
            if(ch==1)
            {
                int quantity = Convert.ToInt32(row[4]);
                decimal price = Convert.ToDecimal(row[5]);
                decimal unitprice=price/quantity;
                Console.Write("Select New Quantity:");
                quantity = int.Parse(Console.ReadLine());
                price = unitprice * quantity;
                row[4] = quantity;
                row[5]= price;
                Console.WriteLine("\n\n\t\t\t\t\t\tUpdated Order detailS:\n");

                Console.Write($"Order Id:{row[0]}\nProduct Code:{row[1]}\nProduct Name:{row[2]}\nProduct Size:{row[3]}\nProduct Quantity:{row[4]}\nPrice:{row[5]}\nCustomer Name:{row[6]}\nCustomer Address:{row[7]}\nCustomer Contact:{row[8]}\n");

                da.UpdateCommand = updatecmd;
            }
            else if(ch==2)
            {
                Console.WriteLine("Select size:\n1.Large\n2.Medium\n3.Small");
                int sizechoice;
                Console.Write("Choice:");
                sizechoice = int.Parse(Console.ReadLine());
                while (sizechoice < 0 || sizechoice > 3)
                {
                    Console.WriteLine("Invalid Choice...! Select again.");
                    Console.Write("Choice:");
                    sizechoice = int.Parse(Console.ReadLine());
                }
                
                switch (sizechoice)
                {
                    case 1:
                        row[3] = "Large";
                        break;
                    case 2:
                        row[3] = "Medium";
                        break;
                    case 3:
                        row[3] = "Small";
                        break;
                }
                Console.WriteLine("\n\n\t\t\t\t\t\tUpdated Order detailS:\n");

                Console.Write($"Order Id:{row[0]}\nProduct Code:{row[1]}\nProduct Name:{row[2]}\nProduct Size:{row[3]}\nProduct Quantity:{row[4]}\nPrice:{row[5]}\nCustomer Name:{row[6]}\nCustomer Address:{row[7]}\nCustomer Contact:{row[8]}\n");
                da.UpdateCommand = updatecmd;
            }
            else
            {
                row.Delete();
                da.DeleteCommand = delcmd;
            }
            return true;
        }
        public void placeOrder(Order order)
        {
            string insertquery = "insert into Orders values(@id,@pcode,@pname,@psize,@pquantity,@price,@cusname,@cusaddress,@cuscontact)";
            SqlConnection con = new SqlConnection(ConnectionString.connectiostr);
            SqlCommand insertcmd = new SqlCommand(insertquery, con);
            insertcmd.Parameters.Add("id", SqlDbType.Int, 0, "OrderId");
            insertcmd.Parameters.Add("pcode", SqlDbType.NChar, 10, "ProductCode");
            insertcmd.Parameters.Add("pname", SqlDbType.NChar, 20, "ProdctName");
            insertcmd.Parameters.Add("psize", SqlDbType.NChar, 10, "ProductSize");
            insertcmd.Parameters.Add("pquantity", SqlDbType.Int, 0, "ProductQuantity");
            insertcmd.Parameters.Add("price", SqlDbType.Float, 53, "Price");
            insertcmd.Parameters.Add("cusname", SqlDbType.NChar, 30, "CustomerName");
            insertcmd.Parameters.Add("cusaddress", SqlDbType.NChar, 150, "CustomerAddress");
            insertcmd.Parameters.Add("cuscontact", SqlDbType.NChar, 15, "CustomerContact");
            DataRow newrow = ourOrders.NewRow();
            newrow[0] = order.OrderId + 1;
            newrow[1] = order.ProductCode;
            newrow[2] = order.ProductName;
            Console.WriteLine($"New  Row{newrow[2]}");
            newrow[3] = order.ProductSize;
            newrow[4] = order.ProductQuantity;
            newrow[5] = order.Price;
            newrow[6] = order.CustomerName;
            newrow[7] = order.CustomerAddress;
            newrow[8] = order.CustomerContact;
            ourOrders.Rows.Add(newrow);
            da.InsertCommand = insertcmd;

        }
        public void commit()
        {
            da.Update(ourOrders);
        }


    }
}
