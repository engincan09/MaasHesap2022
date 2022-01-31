using MaasHesap2022.Dal.EfCore.SeedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Dal.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            BrutAsgariUcretCreator.Create(modelBuilder);
            GelirVergisiDilimCreator.Create(modelBuilder);
            SgkMatrahTavanCreator.Create(modelBuilder);

        }
    }
}
