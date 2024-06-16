using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace webLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person { Name = "Aslam", Age = 18, Email = ["bsef21m078@pucit.edu.pk"] };  //initialize person obj
            Person person = new Person();
            person.Name = "ali";
            person.Age = 18;
            person.AddEmails("bsef21m024@pucit.edu.pk", "ali@gmail.com");

            person.SaveToFile();
            Console.ReadKey();
        }
    }
}
