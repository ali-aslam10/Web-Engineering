using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Web_Assignment_3
{
    class Order
    {
        
        private  int orderId;
        private string productCode;
        private string productName;
        private string productSize;
        private int productQuantity;
        private decimal price;
        private string customerName;
        private string customerAddress;
        private string customerContact;
        private int  generateId()
        {
            string query = "SELECT COUNT(*) FROM Orders";
            SqlConnection connection = new SqlConnection(ConnectionString.connectiostr);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int recordCount = (int)command.ExecuteScalar();
            return recordCount;
        }
        public Order()
        {
            orderId = generateId();
            productCode = default;
            productName = default;
            productSize = default;
            price = default;
            customerName = default;
            customerAddress = default;
            customerContact = default;

           

        }
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public string ProductSize
        {
            get { return productSize; }
            set { productSize = value; }
        }
        
        public int ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; }
        }


        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public string CustomerAddress
        {
            get { return customerAddress; }
            set { customerAddress = value; }
        }

        public string CustomerContact
        {
            get { return customerContact; }
            set { customerContact = value; }
        }



    }
}
