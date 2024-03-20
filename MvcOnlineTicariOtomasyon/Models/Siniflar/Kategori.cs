﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // key kutuphanesi
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        //burada bir tablo olusturacagiz bunu belirtiyoruz sutunlarin satirlarini olacagini soyluyoruz
        //degisken degil propertyler olacak

        //entityler uzerinden uygulamamizi yapicaz bu yuzden keye ihtiyacimiz o da primary key
        [Key]
        //property erisim belirleyici

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public int KategoriId { get; set; }
        public string KategoriAd {  get; set; }
        
        //collection
        public ICollection<Urun> Uruns { get; set; } //herbir kategoride birden fazla urun var anlamina geliyor
    }
}