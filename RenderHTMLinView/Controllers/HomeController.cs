using HtmlAgilityPack;
using RenderHTMLinView.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RenderHTMLinView.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                Test objTest = new Test();
                // string BaseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                // string FilePath = Path.Combine(BaseDirectory, @"Files\test.cshtml");
                string FilePath = Server.MapPath("HTML/AWORStoreProcedures.html");
                string FileContent = System.IO.File.ReadAllText(FilePath);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(FileContent);
                var query = $"//a[contains(@id,'lnkTest')]";
                HtmlNode htmlNode= htmlDoc.DocumentNode.SelectSingleNode(query);
                htmlNode.SetAttributeValue("href","https://www.google.com");
                FileContent = htmlDoc.DocumentNode.WriteTo();
                objTest.HTMLContent = HttpUtility.HtmlDecode(FileContent);
                return View(objTest);
            }
            catch (Exception e)
            {
                throw e;
            }
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