using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LabXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement xmlDoc = XElement.Load("books.xml");
            IEnumerable<XElement> book = xmlDoc.Elements("book");

            var books =
                from e in book
                where (e.Element("genre").Value == "Fantasy" && float.Parse(e.Element("price").Value) > 10) 
                orderby e.Element("price").Value descending
                select e;

            foreach (var item in books)
            {
                    Console.WriteLine("=================================================");
                    Console.WriteLine("Title        : " + item.Element("title").Value);
                    Console.WriteLine("--------------");
                    Console.WriteLine("Author       : " + item.Element("author").Value);
                    Console.WriteLine("Genre        : " + item.Element("genre").Value);
                    Console.WriteLine("Price        : " + item.Element("price").Value);
                    Console.WriteLine("Publish Date : " + item.Element("publish_date").Value);
                    Console.WriteLine("Description  : " + item.Element("description").Value);
            }
            Console.ReadKey();
        }
    }
}
