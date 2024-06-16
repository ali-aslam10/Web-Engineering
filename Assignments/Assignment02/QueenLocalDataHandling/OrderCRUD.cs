using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QueenLocalDataHandling
{
    static class ConnectionString  //just for to make connection string as global variable to overcome overhead to declare everytime
    {
        public static string connectionstr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QueensDB;Integrated Security=True;";
    }
    class OrderCRUD
    {
        public void insertOrder(Order order)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.connectionstr);
            try
            {
                connection.Open();

                string query = "insert into Orders values('"+order.OrderId+"','"+order.CustomerCNIC+"','"+order.CustomerName+"','"+order.CustomerPhone+"','"+order.CustomerAddress+"','"+order.ProductID+"','"+order.ProductPrice+"','"+order.ProductSize+"')";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("\nOrder inserted Successfully..");
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error: " + ex.Message);
                System.Environment.Exit(0);
            }

            finally
            {
                // Ensure the connection is closed
                connection.Close();
            }

        }
        public void getAllOrders()
        {
            SqlConnection connection = new SqlConnection(ConnectionString.connectionstr);
            try
            {
                connection.Open();

                string query = "select * from Orders ";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    Console.WriteLine("No data found..!");
                    return;
                }
                while (dr.Read())
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Order Id: " + dr[0] + "\nCustomer CNIC: " + dr[1] + "\nCustomer Name: " + dr[2] + "\nCustomer Phone: " + dr[3] + "\nCustomer Address: " + dr[4]);
                    Console.WriteLine("Product ID: " + dr[5] + "\nProduct Price: " + dr[6] + "\nProduct Size: " + dr[7]);
                    Console.WriteLine("-------------------------------");
                }
                 dr.Close();

            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error: " + ex.Message);
                System.Environment.Exit(0);
            }

            finally
            {
                // Ensure the connection is closed
                connection.Close();
            }
        }
        public void updateAddress(string phone)
        {
            string address;
            Console.Write("Enter new Address: ");
            address = Console.ReadLine();
            SqlConnection connection = new SqlConnection(ConnectionString.connectionstr);
            try
            {
                connection.Open();
                string query = "update  Orders set CustomerAddress='" + address + "'  where CustomerPhone='" + phone + "'";
                SqlCommand cmd = new SqlCommand(query, connection);
                int count = cmd.ExecuteNonQuery();
                if (count == 0) 
                {
                    Console.WriteLine("Request Denied..!\nPhone no. : " + phone + " does not exist");
                    return;
                }
                Console.WriteLine("Address updated successfully..!");
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error: " + ex.Message);
                System.Environment.Exit(0);

            }
            finally
            {
                // Ensure the connection is closed
                connection.Close();
            }
        }
        public void deleteOrder(int Id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.connectionstr);
            try
            {
                connection.Open();
                string query = "delete  from Orders  where OrderId='" + Id + "'";
                SqlCommand cmd = new SqlCommand(query, connection);
                int count = cmd.ExecuteNonQuery();
                if (count == 0)  
                {
                    Console.WriteLine("Request denied..!\nID: " + Id + " does not exist");
                    return;
                }
                Console.WriteLine("Order deleted successfully..!");
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error: " + ex.Message);
                System.Environment.Exit(0);

            }
            finally
            {
                // Ensure the connection is closed
                connection.Close();
            }
        }

        //Task 2
        public void updateOrderAddress(string phone)
        {
            string address;
            Console.Write("Enter new Address: ");
            address = Console.ReadLine();
            SqlConnection connection = new SqlConnection(ConnectionString.connectionstr);
            try
            {
                connection.Open();
                string query = "update  Orders set CustomerAddress=@add  where CustomerPhone=@ph";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlParameter addressparam = new SqlParameter("add", address);
                SqlParameter phoneparam = new SqlParameter("ph", phone);
                cmd.Parameters.Add(phoneparam);
                cmd.Parameters.Add(addressparam);
                //cmd.Parameters.Add(phoneparam);
                int count = cmd.ExecuteNonQuery();
                if (count == 0)
                {
                    Console.WriteLine("Request Denied..!\nPhone no. : " + phone + " does not exist");
                    return;
                }
                Console.WriteLine("Address updated successfully..!");
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error: " + ex.Message);
                System.Environment.Exit(0);

            }
            finally
            {
                // Ensure the connection is closed
                connection.Close();
            }
        }
    }
}
