using MaasHesap2022.Dal.Extensions;
using MaasHesap2022.Entity.Bordrolar;
using MaasHesap2022.Entity.BrutAsgariUcret;
using MaasHesap2022.Entity.GelirVergisiDilimleri;
using MaasHesap2022.Entity.SgkMatrah;
using MaasHesap2022.Entity.Shared;
using MaasHesap2022.Entity.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MaasHesap2022.Dal.EfCore
{
    public class MaasHesapContext : DbContext
    {
        public MaasHesapContext(DbContextOptions<MaasHesapContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        #region Bordro
        public DbSet<AylikBordro> AylikBordrolar { get; set; }
        #endregion

        #region User
        public DbSet<User> Users { get; set; }
        #endregion

        #region SgkMatrahTavan
        public DbSet<SgkMatrahTavan> SgkMatrahTavan { get; set; }
        #endregion

        #region GelirVergisiDilimleri
        public DbSet<GelirVergisiDilim> GelirVergisiDilimleri { get; set; }
        #endregion

        #region BrutAsgariUcret
        public DbSet<BrutAsgariUcret> BrutAsgariUcret { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// <summary>
            /// https://docs.microsoft.com/en-us/ef/core/modeling/indexes#indexes
            /// </summary>

            /// IndexAttribute ile oluşturulan indexleri create eder.
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
                foreach (var prop in entity.GetProperties())
                    try
                    {
                        var attr = prop.PropertyInfo.GetCustomAttribute<IndexAttribute>();
                        if (attr != null)
                        {
                            var index = entity.AddIndex(prop);
                            index.IsUnique = attr.IsUnique;
                        }
                    }
                    catch
                    {
                    }
            // Seed
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

    }

}
