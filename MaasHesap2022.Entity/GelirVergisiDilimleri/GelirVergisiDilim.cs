using MaasHesap2022.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Entity.GelirVergisiDilimleri
{
    /// <summary>
    /// 2022 yılı gelir vergisi dilimleri ücret gelirleri tutulduğu tablodur.
    /// </summary>
    public class GelirVergisiDilim : BaseEntity
    {
        /// <summary>
        /// Gelir Dilimi başlık
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Alt dilim
        /// </summary>
        public decimal AltDilim { get; set; }

        /// <summary>
        /// Üst dilim
        /// </summary>
        public decimal UstDilim { get; set; }

        /// <summary>
        /// Oran
        /// </summary>
        public decimal Oran { get; set; }

        /// <summary>
        /// Yil
        /// </summary>
        public string Yil { get; set; }
    }
}
