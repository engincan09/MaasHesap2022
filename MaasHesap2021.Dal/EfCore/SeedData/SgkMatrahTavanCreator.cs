using MaasHesap2022.Entity.SgkMatrah;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Dal.EfCore.SeedData
{

    public class SgkMatrahTavanCreator
    {
        public static readonly SgkMatrahTavan[] SgkMatrah = new SgkMatrahTavan[] {
                new SgkMatrahTavan
                {
                    Id = 1,
                    Tutar = 37350,
                    Yil = "2022",
                    CreatedAt = DateTime.Now

                }
        };

        public static void Create(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SgkMatrahTavan>().HasData(SgkMatrah);
        }
    }

}
