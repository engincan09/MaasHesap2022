using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Dto.MaasHesapDto
{
    public class MaasHesaplaRequest
    {
        public int Yil { get; set; }
        public IList<MaasHesaplaAyRequestDto> AyList { get; set; } = new List<MaasHesaplaAyRequestDto>();
    }
}
