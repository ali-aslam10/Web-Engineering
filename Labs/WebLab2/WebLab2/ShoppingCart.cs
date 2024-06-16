using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLab2
{
    class ShoppingCart
    {
        public double calculateTotalPrice(List<double> itemPrices,double discount=0)
        {
            double sum = 0;
            foreach(double i in itemPrices)
            {
                sum += i;
            }
            return sum - (discount / 100 * sum);
        }
    }
}
