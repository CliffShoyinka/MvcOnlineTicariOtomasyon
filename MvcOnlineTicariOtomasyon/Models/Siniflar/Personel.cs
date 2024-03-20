﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int Personelid {  get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd {  get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; } //fazla alan kaplamasin diye gorselin yolunu saklayacagiz sadece
        public SatisHareket SatisHareket { get; set; }
        public Departman Departman { get; set; }
    }
}