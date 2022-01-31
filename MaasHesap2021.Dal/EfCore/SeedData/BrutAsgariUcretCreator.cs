using MaasHesap2022.Entity.BrutAsgariUcret;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Dal.EfCore.SeedData
{
    public class BrutAsgariUcretCreator
    {
        public static readonly BrutAsgariUcret[] BrutUcret = new BrutAsgariUcret[] {
                new BrutAsgariUcret
                {
                    Id = 1,
                    Tutar = 5004,
                    Yil = "2022",
                    CreatedAt = DateTime.Now
                  
                }
        };

        public static void Create(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrutAsgariUcret>().HasData(BrutUcret);
        }
    }
}
