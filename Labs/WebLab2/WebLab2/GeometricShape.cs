using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLab2
{
    class GeometricShape
    {
        private const double pi = 3.14159;
        public double calculateArea(double radius)
        {
            return radius *radius *pi ;
        }
        public double calculateCircumference(double radius)
        {
            return 2 * pi * radius;
        }
        public (double area,double perimeter) calculateRectangleProperties(double length,double width)
        {
            double area = length * width;
            return  (area, 2 * area);
        }
    }
}
