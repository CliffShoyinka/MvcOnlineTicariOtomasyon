using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun() 
        {
            List<SelectListItem> deger1=(from x in c.Kategoris.ToList() 
                                         select new SelectListItem
                                            {
                                             Text=x.KategoriAd,
                                             Value = x.KategoriId.ToString(),
                                            }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        { 
            // Yeni eklenen ürünler varsayılan olarak aktif olsun
            p.Durum = true;
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString(),
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }

        // Ürün güncelleme işlemi
        [HttpPost]
        public ActionResult UrunGuncelle(Urun p)
        {
            var urun = c.Uruns.Find(p.Urunid);
            if (urun == null)
            {
                return HttpNotFound();
            }

            urun.UrunAd = p.UrunAd;
            urun.Marka = p.Marka;
            urun.Stok = p.Stok;
            urun.AlisFiyati = p.AlisFiyati;
            urun.SatisFiyati = p.SatisFiyati;
            urun.Kategoriid = p.Kategoriid;
            urun.UrunGorsel = p.UrunGorsel;
            urun.Durum = p.Durum;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}