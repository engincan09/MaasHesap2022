using MaasHesap2022.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Entity.SgkMatrah
{
    /// <summary>
    /// Sgk matrah tavan bilgileri
    /// </summary>
    public class SgkMatrahTavan : BaseEntity
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
