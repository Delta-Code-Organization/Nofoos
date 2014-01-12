using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GDAL;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using GDAL;

namespace Nofos.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                Doctors Doc = new Doctors();
                List<Doctors> LOD = new List<Doctors>();
                LOD = Doc.GetTopFive();
                Blog B = new Blog();
                List<Blog> LOB = new List<Blog>();
                LOB = B.GetAll();
                ViewBag.blogs = LOB;
                ViewBag.OurPsychologists = LOD;
                return View("IndexAr");

            }
            else
            {
                Doctors Doc = new Doctors();
                List<Doctors> LOD = new List<Doctors>();
                LOD = Doc.GetTopFive();
                Blog B = new Blog();
                List<Blog> LOB = new List<Blog>();
                LOB = B.GetAll();
                ViewBag.blogs = LOB;
                ViewBag.OurPsychologists = LOD;
                return View();
            }
        }
        public bool SendEmail(string _Name,string _Email,string _phone,string _Message)
        {

            Helper H = new Helper();
            H.SendEmail(_Name, "Sender email:" + _Email + "<br/>" + "Sender phone:" + _phone + "<br/>" + _Message, "Nofoos.com@gmail.com");
            return true;

        }

        public void ChangeLang(string _Lang) 
        {
            Response.Cookies["Lang"].Value = _Lang;
        
        }

        public ActionResult PostDetails(int id) 
        {
            Blog B = new Blog();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@ID", id);
            B= B.Search(Dic)[0];
            ViewBag.CurrentBlog = B;
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                return View("PostDetailsAr");
            }
            else 
            {

                return View();
            }
        }
    }
}
