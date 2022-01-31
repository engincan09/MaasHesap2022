using MaasHesap2022.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Entity.BrutAsgariUcret
{
    /// <summary>
    /// Brüt asgari ücret tutar bilgileri
    /// </summary>
    public class BrutAsgariUcret : BaseEntity
    {
        /// <summary>
        /// Yıl bilgisi
        /// </summary>
        public string Yil { get; set; }

        /// <summary>
        /// Tutar bilgisi
        /// </summary>
        public decimal Tutar { get; set; }
    }
}
