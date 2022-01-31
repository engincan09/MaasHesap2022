using MaasHesap2022.Entity.GelirVergisiDilimleri;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Dal.EfCore.SeedData
{
    public class GelirVergisiDilimCreator
    {
        public static readonly GelirVergisiDilim[] TumDilimler = new GelirVergisiDilim[] {
                new GelirVergisiDilim
                {
                    Id = 1,
                    Name = "32.000 TL’ye kadar",
                    Yil = "2022",
                   AltDilim = 0,
                   UstDilim = 32000,
                   Oran = 0.15m
                },
                new GelirVergisiDilim
                {
                    Id = 2,
                    Name = "70.000 TL’nin 32.000 TL’si için 4800 TL. Fazlası",
                    Yil = "2022",
                   AltDilim = 32000,
                   UstDilim = 70000,
                   Oran =0.20m
                },
                new GelirVergisiDilim
                {
                    Id = 3,
                    Name = "250.000 TL’nin 70.000 TL’si için 12.400 TL. Fazlası",
                    Yil = "2022",
                   AltDilim = 70000,
                   UstDilim = 250000,
                   Oran =0.27m
                },
                  new GelirVergisiDilim
                {
                    Id = 4,
                    Name = "880.000 TL’nin 250.000 TL’si için 61.000 TL. Fazlası",
                    Yil = "2022",
                   AltDilim = 250000,
                   UstDilim = 880000,
                   Oran = 0.35m
                },
                    new GelirVergisiDilim
                {
                    Id = 5,
                    Name = "880.000 TL’den fazlasının 880.000 TL’si için 281.500 TL. Fazlası",
                    Yil = "2022",
                   AltDilim = 880000,
                   UstDilim = 250000,
                   Oran = 0.40m
                },
        };

        public static void Create(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GelirVergisiDilim>().HasData(TumDilimler);
        }
    }
}
