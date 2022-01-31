using MaasHesap2022.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Entity.User
{
    /// <summary>
    /// Personellerin tutulduğu tablodur.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Personel adı
        /// </summary>
        public string Ad { get; set; }

        /// <summary>
        /// Personel Soyadı
        /// </summary>
        public string Soyad { get; set; }

        /// <summary>
        /// Evlilik durumu
        /// </summary>
        public bool IsEvli { get; set; }

        /// <summary>
        /// Çocuk sayısı
        /// </summary>
        public int CocukSayisi { get; set; }

    }
}
