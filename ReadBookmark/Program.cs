using HtmlAgilityPack;
using System;
using System.Linq;

namespace ReadBookmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            //var fileStream = new FileStream(@"bookmarks_8_2_16.html", FileMode.Open, FileAccess.Read);

            //string url = @"http://vnexpress.net/";

            var doc = new HtmlDocument();

            doc.Load("bookmarks_8_2_16.html");

            //var doc = new HtmlWeb().Load(url);

            var linkTags = doc.DocumentNode.Descendants("link");
            var linkedPages = doc.DocumentNode.Descendants("a")
                                              .Select(a => new { Href = a.GetAttributeValue("href", null), Title = a.InnerText })
                                              .Where(u => !String.IsNullOrEmpty(u.Href));

            foreach (var link in linkedPages)
            {
                Console.WriteLine(link.Href + " - " + link.Title);
            }

            Console.ReadKey();
        }
    }
}
