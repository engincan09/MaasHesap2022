using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Entity.Shared
{
    /// <summary>
    /// Bütün tablolarda ortak tutulan alanlar.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Tablo tekil bilgisidir.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Verinin oluşturulma tarihidir.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
