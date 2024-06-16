using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLab2
{
    class MathHelper
    {
        public void swapIntegers(ref int a,ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public void divideWithRemainder(double dividend,double divisor,out double qoutient,out double remainder )
        {
            
            qoutient = dividend / divisor;
            remainder = dividend % divisor;
        }

    }
}
