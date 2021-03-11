using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
 

class Program
{
    static void Main(string[] args)
    {
        XElement xmlDoc = XElement.Load("books.xml");
        IEnumerable<XElement> xmlData = xmlDoc.Elements("book");

        var allBooks =
            from e in xmlData
            select e;

        var fantasyBooks =
            from e in xmlData
            where (e.Element("genre").Value == "Fantasy")
            select e;

        var expensiveBooks =
            from e in xmlData
            where ((float.Parse(e.Element("price").Value)) > 10)
            orderby e.Element("price").Value descending
            select e;

        var oldBooks =
            xmlData.Any(e => e.Element("publish_date").Value.Contains("2001"));

        PrintHeader("All Books");
        PrintBooks(allBooks);

        PrintHeader("Fantasy Books");
        PrintBooks(fantasyBooks);

        PrintHeader("Books above $10");
        PrintBooks(expensiveBooks);

        PrintHeader("Books from 2001");
        PrintBooks(expensiveBooks);

        void PrintHeader(string content)
        {
            Console.WriteLine("\n ---------------------------");
            Console.WriteLine($"   *** {content} *** ");
            Console.WriteLine(" ---------------------------");
        }

        void PrintBooks (IEnumerable<XElement> books)
        {
            int i = 1;
            foreach (var item in books)
            {
                Console.WriteLine("");
                Console.WriteLine("    Title       : " + item.Element("title").Value);
                Console.WriteLine("    Author      : " + item.Element("author").Value);
                Console.WriteLine("    Price       : " + item.Element("price").Value);
                Console.WriteLine("    Description : " + item.Element("description").Value + "\n");
                i++;
            }
        }

        Console.ReadKey();
    }
}
