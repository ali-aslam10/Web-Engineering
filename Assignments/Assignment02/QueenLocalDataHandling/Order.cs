using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QueenLocalDataHandling
{
    class Order
    {
        private int orderId;
        private string customerCnic;
        private string customerName;
        private string customerPhone;
        private string customerAddress;
        private string productId;
        private decimal productPrice;
        private string productSize;
        private int generateOrderId()
        {
            /*
             Approach: Get last assigned ID, simply increament it by 1 to make new unique ID
            */

            SqlConnection connection = new SqlConnection(ConnectionString.connectionstr);
            try
            {
                connection.Open();

                string query = "select top 1 OrderId  from Orders order by OrderId DESC";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                    return 1; //first record
                dr.Read();  //move pointer 

                int id = Convert.ToInt32(dr[0]) + 1;
                dr.Close();
                return id;


            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error: " + ex.Message);
                System.Environment.Exit(0);
                return -1;
            }

            finally
            {
                // Ensure the connection is closed
                connection.Close();
            }


        }
        public Order()
        {
            orderId = generateOrderId();
            customerCnic = string.Empty;
            customerName = string.Empty;
            customerPhone = string.Empty;
            customerAddress = string.Empty;
            productId = string.Empty;
            productPrice = -1;
            productSize = string.Empty;
        }
        public int OrderId
        {
            get { return orderId; }
            
        }
        public string CustomerCNIC
        {
            get { return customerCnic; }
            set { customerCnic = value; }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public string CustomerPhone
        {
            get { return customerPhone; }
            set { customerPhone = value; }
        }
        public string CustomerAddress
        {
            get { return customerAddress; }
            set { customerAddress = value; }
        }
        public string ProductID
        {
            get { return productId; }
            set { productId = value; }
        }
        public decimal ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; }
        }
        public string ProductSize
        {
            get { return productSize; }
            set { productSize = value; }
        }

    }
}
