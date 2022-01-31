using System;
using System.Collections.Generic;
using System.Text;

namespace MaasHesap2022.Dto.MaasHesapDto
{
    public class MaasHesaplaAyResponseDto
    {
        public int Ay { get; set; }
        public decimal BrutUcret { get; set; }
        public decimal SgkIsci { get; set; }
        public decimal IssizlikIsci { get; set; }
        public decimal KumulatifGelirVergisiMatrahi { get; set; }
        public decimal GelirVergisiMatrahi { get; set; }
        public decimal GelirVergisi { get; set; }
        public decimal DamgaVergisi { get; set; }
        public decimal KesintilerToplami
        {
            get { return SgkIsci + IssizlikIsci + GelirVergisi + DamgaVergisi; }
        }
        public decimal NetUcret
        {
            get { return BrutUcret - KesintilerToplami; }
        }
        public decimal GelirVergisiIstisnaTutar { get; set; }
        public decimal DamgaVergisiIstisnaTutar { get; set; }
        public decimal NetEleGecenUcret
        {
            get
            {
                return NetUcret + GelirVergisiIstisnaTutar + DamgaVergisiIstisnaTutar;
            }
        }

        public IList<MaasHesaplaAyResponseGelirVergisiDto> GelirVergisiList { get; set; } = new List<MaasHesaplaAyResponseGelirVergisiDto>();
    }
}
