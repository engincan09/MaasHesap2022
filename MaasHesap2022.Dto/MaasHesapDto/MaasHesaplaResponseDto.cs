using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Dto.MaasHesapDto
{
    public class MaasHesaplaResponseDto
    {
        public decimal NetOrtalama { get; set; }
        public IList<MaasHesaplaAyResponseDto> AyList { get; } = new List<MaasHesaplaAyResponseDto>();
    }
}
