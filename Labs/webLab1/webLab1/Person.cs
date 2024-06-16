using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace webLab1
{
    class Person
    {
        public string Name { get; set; }  //name property
        
        public int Age { get; set; }  //age property

        public List<string> Email { get; set; } = new List<string>();//Email property 

        public void AddEmails(params string[] mailarray)  //pram using function
        {
            foreach (string i in mailarray)
                Email.Add(i);
        }
        public override string ToString()  //override function
        {
            string data = "Names: "+Name+" Age: "+ Age+ " Emails ";
            foreach (string i in Email)
                data += i+" ";
            return data;
            

        }
        public void SaveToFile()
        {
            FileStream fin = new FileStream("data.txt", FileMode.Append);
            StreamWriter sr = new StreamWriter(fin);
            string data = "Names: " + Name + " Age: " + Age + " Emails ";
            foreach (string i in Email)
                data += i + " ";
            sr.WriteLine(data);
            sr.Close();
            fin.Close();

        }

    }
}
