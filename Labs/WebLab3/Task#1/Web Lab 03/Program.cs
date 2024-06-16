using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Web_Lab_03
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable product = new DataTable();
            DataColumn productId = new DataColumn("productId", typeof(int));
            DataColumn name = new DataColumn("Name", typeof(string));
            DataColumn desc = new DataColumn("Desc", typeof(string));
            DataColumn price = new DataColumn("Price", typeof(double));
            productId.AutoIncrement = true;
            productId.AutoIncrementSeed = 1;
            productId.AutoIncrementStep = 1;
            product.Columns.Add(productId);
            product.Columns.Add(name);
            product.Columns.Add(desc);
            product.Columns.Add(price);
            product.PrimaryKey = new DataColumn[] { productId };
            DataRow productR1 = product.NewRow();
            productR1[1] = "Bag";
            productR1[2] = "School Bag";
            productR1[3] = 600;

            DataRow productR2 = product.NewRow();
            productR2[1] = "Bag";
            productR2[2] = "Laptop Bag";
            productR2[3] = 1200;

            DataRow productR3 = product.NewRow();
            productR3[1] = "Shirt";
            productR3[2] = "T-shirt";
            productR3[3] = 700;

            DataRow productR4 = product.NewRow();
            productR4[1] = "Shoes";
            productR4[2] = "Men shoes";
            productR4[3] = 1500;

            DataRow productR5 = product.NewRow();
            productR5[1] = "Shoes";
            productR5[2] = "School Shoes";
            productR5[3] = 1000;

            DataRow productR6 = product.NewRow();
            productR6[1] = "Bottle";
            productR6[2] = "Water Bottle";
            productR6[3] = 500;

            product.Rows.Add(productR1);
            product.Rows.Add(productR2);
            product.Rows.Add(productR3);
            product.Rows.Add(productR4);
            product.Rows.Add(productR5);
            product.Rows.Add(productR6);

            DataTable order = new DataTable();
            DataColumn orderId = new DataColumn("OrderId", typeof(int));
            DataColumn createdAt = new DataColumn("CreatedAt", typeof(DateTime));
            orderId.AutoIncrement = true;
            orderId.AutoIncrementSeed = 1;
            orderId.AutoIncrementStep = 1;
            order.Columns.Add(orderId);
            order.Columns.Add(createdAt);
            order.PrimaryKey = new DataColumn[] { orderId };


            DataTable productOrder = new DataTable();
            DataColumn orderid = new DataColumn("OrderId", typeof(int));
            DataColumn productid = new DataColumn("ProductId", typeof(int));
            productOrder.Columns.Add(orderid);
            productOrder.Columns.Add(productid);
            productOrder.PrimaryKey = new DataColumn[] { orderid,productid };


            DataRow orderR1 = order.NewRow();
            orderR1[1] = "5/11/2020 2:40AM";
            DataRow productorderR1 = productOrder.NewRow();
            productorderR1[0] = 1;
            productorderR1[1] = 2;

            DataRow orderR2 = order.NewRow();
            orderR2[1] = "10/11/2022 2:40AM";
            DataRow productorderR2 = productOrder.NewRow();
            productorderR2[0] = 2;
            productorderR2[1] = 2;

            DataRow orderR3 = order.NewRow();
            orderR3[1] = "10/11/2023 2:40AM";
            DataRow productorderR3 = productOrder.NewRow();
            productorderR3[0] = 3;
            productorderR3[1] = 3;

            DataRow productorderR4 = productOrder.NewRow();
            productorderR4[0] = 3;
            productorderR4[1] = 4;


            order.Rows.Add(orderR1);
            order.Rows.Add(orderR2);
            order.Rows.Add(orderR3);

            productOrder.Rows.Add(productorderR1);
            productOrder.Rows.Add(productorderR2);
            productOrder.Rows.Add(productorderR3);
            productOrder.Rows.Add(productorderR4);


            DataSet ds = new DataSet();
            ds.Tables.Add(product);
            ds.Tables.Add(order);
            ds.Tables.Add(productOrder);

            DataRelation rel1 = new DataRelation("ProductOrderProduct", product.Columns["productId"], productOrder.Columns["ProductId"]);
            DataRelation rel2 = new DataRelation("ProductOrderOrder", order.Columns["OrderId"], productOrder.Columns["OrderId"]);

            ds.Relations.Add(rel1);
            ds.Relations.Add(rel2);


            DataRow prod = product.Rows.Find(2);
            Console.WriteLine($"Product ID:{prod[0]} Name: {prod[1]} Descriptoion: {prod[2]} Price: {prod[3]}");

            DataRow[] prodOrder = productOrder.Select("OrderId=3");

            Console.WriteLine($"\nProduct in Order ID:{3}");
            foreach(DataRow orderRow in prodOrder)
            {
                int prodId = Convert.ToInt32( orderRow[1]);
                DataRow products = product.Rows.Find(prodId);
                Console.WriteLine($"Product ID:{products[0]} Name: {products[1]} Descriptoion: {products[2]} Price: {products[3]}");

            }

            DataRow[] ordersList = order.Select("CreatedAt > '10 / 11 /2020'");

            Console.WriteLine($"\nOrders after 10 / 11 / 2020 2:40AM");
            foreach (DataRow orderRow in ordersList)
            {
                
                Console.WriteLine($"Order ID:{orderRow[0]},{orderRow[1]}");

            }










        }
    }
}
