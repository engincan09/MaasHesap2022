using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Dto.GelirVergsiDto
{
    public class GelirVergisiResponseDto
    {
        public decimal GelirVergisiMatrahi { get; set; }
        public decimal GelirVergisi { get; set; }
        public IList<GelirVergisiDilimResponseDto> GelirVergisiDilimList { get; set; } = new List<GelirVergisiDilimResponseDto>();
    }
}
