using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Web_Assignment_3
{
    static class ConnectionString
    {
        public static string connectiostr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = QueenShopDB; Integrated Security = True;";
    }

    class Program
    {
        static void displayOrder(ref Order order)
        {
            Console.WriteLine("\n\n\t\t\t\t\t\tOrder detailS:\n");

            Console.Write($"Order Id:{order.OrderId}\nProduct Code:{order.ProductCode}\nProduct Name:{order.ProductName}\nProduct Size:{order.ProductSize}\nProduct Quantity:{order.ProductQuantity}\nPrice:{order.Price}\nCustomer Name:{order.CustomerName}\nCustomer Address:{order.CustomerAddress}\nCustomer Contact:{order.CustomerContact}\n");
            Console.WriteLine("\nNote Your Order Id.It will help you\nif you want to update order");
        }
        static void getOrderInfo(ref Order order)
        {
            order.OrderId = order.OrderId + 1;
            Console.WriteLine("Enter Order info");
            Console.Write("Product Code:");
            order.ProductCode = Console.ReadLine();
            Console.WriteLine("Select Product size:\n1.Large\n2.Medium\n3.Small");
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
                   order.ProductSize = "Large";
                    break;
                case 2:
                    order.ProductSize = "Medium";
                    break;
                case 3:
                    order.ProductSize = "Small";
                    break;
            }
            Console.Write("Product Quantity:");
            order.ProductQuantity = int.Parse(Console.ReadLine());
            Console.Write("Customer Name:");
            order.CustomerName = Console.ReadLine();
            Console.Write("Customer Address:");
            order.CustomerAddress = Console.ReadLine();
            Console.Write("Customer Contact:");
            order.CustomerContact = Console.ReadLine();
        }
        static void Main(string[] args)
        {
            DataTable ourproducts = new DataTable();
            Order order = new Order();
            orderCRUD ordercrud = new orderCRUD();
            SqlConnection con = new SqlConnection(ConnectionString.connectiostr);
            string query = "select * from Products";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ourproducts);
            ourproducts.PrimaryKey = new DataColumn[] { ourproducts.Columns["ProductCode"] };
            Console.WriteLine("\n\t\t\t\t\t\tWelcome to Queen Shop\n");
            Console.WriteLine("Select Option\n1.Create Order\n2.Update Order\n");
            Console.Write("Choice:");
            int ch;
            ch = int.Parse(Console.ReadLine());
            while(ch<0 || ch > 2)
            {
                Console.Write("Invalid choice..!Select again.\nChoice:");
                ch = int.Parse(Console.ReadLine());
            }
            if (ch == 1)
            {
                Console.WriteLine("\n\t\t\t\t\t\t    Our Products\n");
                Console.WriteLine("Product Code\tProduct Name\t    Price");
                con.Close();
                foreach (DataRow r in ourproducts.Rows)
                {
                    Console.WriteLine(r[0] + "\t" + r[1].ToString() + "$" + r[2].ToString());
                }
                getOrderInfo(ref order);
                DataRow row = ourproducts.Rows.Find(order.ProductCode);
                if (row == null)
                {
                    Console.WriteLine("\nOOps..Sorry Selected product not available.");

                }
                else
                {
                    order.ProductName = row[1].ToString();
                    order.Price = Convert.ToInt32(row[2]) * order.ProductQuantity;
                    ordercrud.createOrder(order);
                    displayOrder(ref order);
                    Console.WriteLine("\nOrder Palced Successfully\n");
                    Console.WriteLine("\n\t\t\t\t\t\tThanks for visiting Queen Shop\n");

                }
            }
            else
            {
                Console.Write("Enter Order Id:");
                int id = int.Parse(Console.ReadLine());
                bool flag=ordercrud.updateOrder(id);
                if (flag)    //update successfully
                {
                    Console.WriteLine("Order update Successfully..!");
                    Console.Write("Do you want to place a new order..\n1.Yes\n2.No\nChoice:");

                    ch = int.Parse(Console.ReadLine());
                    while (ch < 0 || ch > 2)
                    {
                        Console.Write("Invalid choice..!Select again.\nChoice:");
                        ch = int.Parse(Console.ReadLine());
                    }
                    if (ch == 1)
                    {
                        Console.WriteLine("\n\t\t\t\t\t\t    Our Products\n");
                        Console.WriteLine("Product Code\tProduct Name\t    Price");
                        con.Close();
                        foreach (DataRow r in ourproducts.Rows)
                        {
                            Console.WriteLine(r[0] + "\t" + r[1].ToString() + "$" + r[2].ToString());
                        }
                        getOrderInfo(ref order);
                        DataRow row = ourproducts.Rows.Find(order.ProductCode);
                        if (row == null)
                        {
                            Console.WriteLine("\nOOps..Sorry Selected product not available.");

                        }
                        else
                        {
                            order.ProductName = row[1].ToString();
                            Console.WriteLine($"Name-------------:{order.ProductName}");
                            order.Price = Convert.ToInt32(row[2]) * order.ProductQuantity;
                            ordercrud.placeOrder(order);
                            displayOrder(ref order);
                            Console.WriteLine("\nOrder Palced Successfully\n");
                            Console.WriteLine("\n\t\t\t\t\t\tThanks for visiting Queen Shop\n");

                        }
                    }
                    ordercrud.commit();
                }

            }

           

        }
    }
}
