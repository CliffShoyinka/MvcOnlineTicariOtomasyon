using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }

        public ActionResult KategoriEkle()
        {
            return View();
        }

        //we added second time because KategoriEkle() method run when the page was uploaded
        public ActionResult KategoriEkle()
        {
            return View();
        }
    }
}