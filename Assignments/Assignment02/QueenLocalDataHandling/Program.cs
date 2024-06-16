using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace QueenLocalDataHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            int ch;
            try
            {
                do
                {
                    Console.WriteLine("Select option");
                    Console.WriteLine("1. Insert Order\n2. Update Address\n3. Delete Order\n4. Get all Orders\n5. Quit");
                    Console.Write("Enter Choice: ");
                    ch = int.Parse(Console.ReadLine());
                    while (ch < 0 || ch > 5)
                    {
                        Console.Write("Invalid Choice..Select Again\nChoice: ");
                        ch = int.Parse(Console.ReadLine());
                    }
                    OrderCRUD orderCRUD = new OrderCRUD();
                    switch (ch)
                    {
                        case 1:
                            Order order = new Order();
                            Console.WriteLine("Enter Data:");
                            Console.Write("Customer CNIC: ");
                            order.CustomerCNIC = Console.ReadLine();
                            
                            //CNIC validation
                            string cnicPatteren = @"^\d{5}-\d{7}-\d{1}$";
                            while (!Regex.IsMatch(order.CustomerCNIC, cnicPatteren))
                            {
                                Console.Write("Invalid CNIC..!Enter again\nCNIC: ");
                                order.CustomerCNIC = Console.ReadLine();
                            }
                            Console.Write("Customer Name: ");
                            order.CustomerName = Console.ReadLine();
                            Console.Write("Customer Phone Number: ");
                            order.CustomerPhone = Console.ReadLine();

                            //Phone no validation
                            string phonePatteren = @"^\d{4}-?\d{7}$";
                            while (!Regex.IsMatch(order.CustomerPhone, phonePatteren))
                            {
                                Console.Write("Invalid Phone number..!Enter again\nPhone: ");
                                order.CustomerPhone = Console.ReadLine();
                            }
                            Console.Write("Customer Address: ");
                            order.CustomerAddress = Console.ReadLine();
                            Console.Write("Product Id: ");
                            order.ProductID = Console.ReadLine();
                            Console.Write("Product Price: ");
                            order.ProductPrice = Convert.ToDecimal(Console.ReadLine());
                            Console.Write("Product Size: ");
                            order.ProductSize = Console.ReadLine();

                            orderCRUD.insertOrder(order);
                            break;
                        case 2:
                            Console.Write("Enter Customer Phone Number\nPhone: ");
                            string phone = Console.ReadLine();
                            //Phone no validation
                            phonePatteren = @"^\d{4}-?\d{7}$";
                            while (!Regex.IsMatch(phone, phonePatteren))
                            {
                                Console.Write("Invalid Phone number..!Enter again\nPhone: ");
                                phone = Console.ReadLine();
                            }
                            orderCRUD.updateOrderAddress(phone);
                            break;
                        case 3:
                            Console.Write("Enter Order ID\nID: ");
                            int id = int.Parse(Console.ReadLine());
                            orderCRUD.deleteOrder(id);
                            break;
                        case 4:
                            orderCRUD.getAllOrders();
                            break;

                    }

                } while (ch != 5);
           }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error: " + ex.Message);
                System.Environment.Exit(0);
            }
        }
    }
}
