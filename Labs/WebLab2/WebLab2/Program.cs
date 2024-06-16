using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLab2
{

    class Program
    {
        static void PassByValueAndReference(int x, ref int y)
        {
            
            x+=10;
            y+=10;
            
        }
        static void Main(string[] args)
        {

            int ch;
            do
            {
                Console.WriteLine("Which Task you want to evaluate\nSelect option:");
                Console.Write("1. Task#1\n2. Task#2\n3. Task#3\n4. Task#4\n5. Task#5\n6. Task#6\n7. Task#7\n8. Quit\n");
                Console.Write("Choice: ");
                ch = int.Parse(Console.ReadLine());
                while(ch<0||ch>8)
                {
                    Console.Write("Invalid Choice..!Enter again\nChoice: ");
                    ch = int.Parse(Console.ReadLine());
                }
                switch (ch)
                {
                    case 1:
                        List<double> prices = new List<double>() { 10, 20, 50, 35 };
                        Console.WriteLine("Lets assume we have following list of prices");
                        foreach (double i in prices)
                        {
                            Console.Write(i+" ");
                        }
                        ShoppingCart cart = new ShoppingCart();
                        Console.WriteLine($"\nSum of prices without discount is: {cart.calculateTotalPrice(prices)}");
                        Console.WriteLine($"\nSum of prices with 5% discount is: {cart.calculateTotalPrice(prices,5)}");
                        break;
                    case 2:
                        int x = 10;
                        int y = 20;
                        MathHelper mathHelper = new MathHelper();
                        Console.WriteLine($"Before callig swap function\nx={x} and y={y}");
                        mathHelper.swapIntegers(ref x, ref y);
                        Console.WriteLine($"After callig swap function\nx={x} and y={y}");
                        x = 17;
                        y = 5;
                        Console.WriteLine($"Lets assume dividend is: {x} and divisor is: {y}");
                        mathHelper.divideWithRemainder(x, y, out double qoutient, out double remainder);
                        Console.WriteLine($" After dividig\nQoutient is: {qoutient} and remainder is: {remainder}");
                        break;
                    case 3:
                        x = 10;
                        y = 20;
                        Console.WriteLine($"Before callig PassByValueAndReference function\nx={x} and y={y}");
                        PassByValueAndReference(x, ref y);
                        Console.WriteLine($"After callig PassByValueAndReference function\nx={x} and y={y}");
                        break;
                    case 4:
                        MultiPlayerGame game = new MultiPlayerGame();
                        Console.WriteLine($"Number of players: {game.getPlayerCount()}");
                        Console.WriteLine("lets add 2 players");
                        game.addPlayer();
                        game.addPlayer();
                        Console.WriteLine($"Number of players: {game.getPlayerCount()}");
                        Console.WriteLine("lets remove 1 player");
                        game.removePlayer();
                        Console.WriteLine($"Number of players: {game.getPlayerCount()}");
                        break;
                    case 5:
                        double radius;
                        Console.Write("Enter radius\nRadius:");
                        radius = Convert.ToDouble(Console.ReadLine());
                        GeometricShape shape = new GeometricShape();
                        Console.WriteLine($"Area:{shape.calculateArea(radius)}\nCircumference:{shape.calculateCircumference(radius)}");
                        break;
                    case 6:
                        double length;
                        double width;
                        Console.Write("Enter Values\nLength:");
                        length = Convert.ToDouble(Console.ReadLine());
                        Console.Write("width:");
                        width = Convert.ToDouble(Console.ReadLine());
                        shape = new GeometricShape();
                        var properties = shape.calculateRectangleProperties(length, width);
                        Console.WriteLine($"Area: {properties.area} Perimeter: {properties.perimeter}");
                        break;
                    case 7:

                        var var1 = 12;
                        var var2 = "Ali";
                        Console.WriteLine($"Content of var1: {var1} and its type is {var1.GetType()}\nContent of var2: {var2} and its type is {var2.GetType()}");
                        dynamic dynamicVar;
                        dynamicVar = 13.5;
                        Console.WriteLine($"Content of dynamic variable is: {dynamicVar} and its type is {dynamicVar.GetType()}");
                        dynamicVar = "Aslam";
                        Console.WriteLine($"Now Content of dynamic variable is: {dynamicVar} and its type is {dynamicVar.GetType()}");
                        dynamicVar = 21;
                        Console.WriteLine($"Now Content of dynamic variable is: {dynamicVar} and its type is {dynamicVar.GetType()}");
                        break;

                }

            } while (ch != 8);
        }
    }
}
