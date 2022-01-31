using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Dto.AsgariUcret
{
    public class AsgariUcretIstisnaDto
    {
        public decimal GelirVergisiIstisnaTutar { get; set; }
        public decimal DamgaVergisiIstisnaTutar { get; set; }
        public decimal GelirVergisiMatrahi { get; set; }
        public int Yil { get; set; }
    }
}
