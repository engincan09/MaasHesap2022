using MaasHesap2022.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Entity.Bordrolar
{
    public class AylikBordro : BaseEntity
    {
        /// <summary>
        /// Personel tekil bilgisi
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Ay Bilgisi
        /// </summary>
        public string Ay { get; set; }

        /// <summary>
        /// BrutUcret
        /// </summary>
        public decimal BrutUcret { get; set; }

        /// <summary>
        /// Sgk
        /// </summary>
        public decimal SgkIsci { get; set; }
        /// <summary>
        /// İşsizlik
        /// </summary>
        public decimal IssizlikIsci { get; set; }
        /// <summary>
        /// Kumulatif gelir vergisi matrah
        /// </summary>
        public decimal KumulatifGelirVergisiMatrahi { get; set; }
        /// <summary>
        /// Gelir vergisi matrah
        /// </summary>
        public decimal GelirVergisiMatrahi { get; set; }
        /// <summary>
        /// Gelir vergisi
        /// </summary>
        public decimal GelirVergisi { get; set; }
        /// <summary>
        /// Damga vergisi
        /// </summary>
        public decimal DamgaVergisi { get; set; }

        /// <summary>
        /// Kesintiler toplamı
        /// </summary>
        public decimal KesintilerToplami { get; set; }

        /// <summary>
        /// Net ücret
        /// </summary>
        public decimal NetUcret { get; set; }

        /// <summary>
        /// Gelir vergisi istisna tutar
        /// </summary>
        public decimal GelirVergisiIstisnaTutar { get; set; }
        
        /// <summary>
        /// Damga vergisi istisna tutar
        /// </summary>
        public decimal DamgaVergisiIstisnaTutar { get; set; }

        /// <summary>
        /// Net ücret
        /// </summary>
        public decimal NetEleGecenUcret { get; set; }

    }
}
