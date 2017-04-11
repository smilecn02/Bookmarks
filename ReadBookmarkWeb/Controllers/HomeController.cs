using HtmlAgilityPack;
using PagedList;
using ReadBookmarkWeb.Models;
using System;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using System.Web.Mvc;

namespace ReadBookmarkWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page, bool isRandom = true)
        {
            var doc = new HtmlDocument();

            doc.Load(HostingEnvironment.ApplicationPhysicalPath + "/bookmarks_8_2_16.html", Encoding.UTF8);

            //var doc = new HtmlWeb().Load(url);

            var linkTags = doc.DocumentNode.Descendants("link");
            var linkedPages = doc.DocumentNode.Descendants("a")
                                              .Select(a => new Link { Href = a.GetAttributeValue("href", null), Title = a.InnerText })
                                              .Where(u => !String.IsNullOrEmpty(u.Href));

            int pageSize = 14;
            if (isRandom) linkedPages = linkedPages.OrderBy(i => Guid.NewGuid()).Take(pageSize);

            
            int pageNumber = (page ?? 1);

            return View(linkedPages.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    
}