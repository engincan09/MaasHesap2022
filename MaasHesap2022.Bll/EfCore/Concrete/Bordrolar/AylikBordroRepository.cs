using MaasHesap2022.Bll.EfCore.Abstract.Bordrolar;
using MaasHesap2022.Bll.EfCore.Abstract.BrutAsgariUcretler;
using MaasHesap2022.Bll.EfCore.Abstract.GelirVergisiDilimler;
using MaasHesap2022.Bll.EfCore.Abstract.SgkMatrahTavanlar;
using MaasHesap2022.Dal.EfCore;
using MaasHesap2022.Dal.EfCore.Concrete;
using MaasHesap2022.Dal.Extensions;
using MaasHesap2022.Dto.SgkDto;
using MaasHesap2022.Entity.Bordrolar;
using MaasHesap2022.Entity.BrutAsgariUcret;
using MaasHesap2022.Entity.GelirVergisiDilimleri;
using MaasHesap2022.Entity.SgkMatrah;
using System.Collections.Generic;

namespace MaasHesap2022.Bll.EfCore.Concrete.Bordrolar
{
    public class AylikBordroRepository : EntityBaseRepository<AylikBordro>, IAylikBordroRepository
    {
        ///SGK Primi İşçi Payı (%14)
        private const decimal SgkIsciOran = 0.14m;

        //İşsizlik Sigortası Primi İşçi Payı (%1)
        private const decimal IssizlikIsciOran = 0.01m;

        //Damga Vergisi (% 0,00759)
        private const decimal DamgaVergisiOran = 0.00759m;

        private readonly IGelirVergisiDilimlerRepository _gelirVergisiDilimlerRepository;
        private readonly IBrutAsgariUcretRepository _brutAsgariUcretRepository;
        private readonly ISgkMatrahTavanRepository _sgkMatrahTavanRepository;
        public AylikBordroRepository(MaasHesapContext context, IGelirVergisiDilimlerRepository gelirVergisiDilimlerRepository, IBrutAsgariUcretRepository brutAsgariUcretRepository, ISgkMatrahTavanRepository sgkMatrahTavanRepository) : base(context)
        {
            _gelirVergisiDilimlerRepository = gelirVergisiDilimlerRepository;
            _brutAsgariUcretRepository = brutAsgariUcretRepository;
            _sgkMatrahTavanRepository = sgkMatrahTavanRepository;
        }








        /// <summary>
        /// Sgk işci ücreti hesabı döndürür.
        /// </summary>
        /// <param name="brutUcret"></param>
        /// <param name="devirMatrah1AyOnce"></param>
        /// <param name="devirMatrah2AyOnce"></param>
        /// <param name="yil"></param>
        /// <returns></returns>
        private SgkIsciResponse SgkIsciPrimHesapla(decimal brutUcret, decimal devirMatrah1AyOnce, decimal devirMatrah2AyOnce, int yil)
        {
            decimal sgkMatrahTavan = GetYilaGoreSgkMatrahTavan(yil);
            if (devirMatrah2AyOnce >= sgkMatrahTavan)
            {
                return new SgkIsciResponse
                {
                    SgkIsciTutar = (sgkMatrahTavan * SgkIsciOran).Round(),
                    KalanMatrah = brutUcret,
                    KalanMatrah1AyOnce = devirMatrah1AyOnce
                };
            }
            if (devirMatrah2AyOnce + devirMatrah1AyOnce >= sgkMatrahTavan)
            {
                return new SgkIsciResponse
                {
                    SgkIsciTutar = (sgkMatrahTavan * SgkIsciOran).Round(),
                    KalanMatrah = brutUcret,
                    KalanMatrah1AyOnce = devirMatrah2AyOnce + devirMatrah1AyOnce - sgkMatrahTavan
                };
            }
            if (devirMatrah2AyOnce + devirMatrah1AyOnce + brutUcret >= sgkMatrahTavan)
            {
                return new SgkIsciResponse
                {
                    SgkIsciTutar = (sgkMatrahTavan * SgkIsciOran).Round(),
                    KalanMatrah = devirMatrah2AyOnce + devirMatrah1AyOnce + brutUcret - sgkMatrahTavan,
                    KalanMatrah1AyOnce = 0
                };
            }
            return new SgkIsciResponse
            {
                SgkIsciTutar = ((devirMatrah2AyOnce + devirMatrah1AyOnce + brutUcret) * SgkIsciOran).Round(),
                KalanMatrah = 0,
                KalanMatrah1AyOnce = 0
            };
        }

        /// <summary>
        /// İşsizlik işçi oranı döndürür.
        /// </summary>
        /// <param name="brutUcret"></param>
        /// <returns></returns>
        private decimal HesaplaIssizlikIsci(decimal brutUcret)
        {
            return (brutUcret * IssizlikIsciOran).Round();
        }



        /// <summary>
        /// Gelir vergisi dilimlerini döndürür.
        /// </summary>
        /// <returns></returns>
        private List<GelirVergisiDilim> GetGelirVergisiDilimler()
        {
            return _gelirVergisiDilimlerRepository.GetAll();
        }

        /// <summary>
        /// Sgk Matrah tavan bilgilerini döndürür.
        /// </summary>
        /// <returns></returns>
        private List<SgkMatrahTavan> GetSgkMatrahTavan()
        {
            return _sgkMatrahTavanRepository.GetAll();
        }

        /// <summary>
        /// Sgk Matrah tavan bilgisni yıla göre döndürür.
        /// </summary>
        /// <returns></returns>
        private decimal GetYilaGoreSgkMatrahTavan(int yil)
        {
            return _sgkMatrahTavanRepository.Get(m=> m.Yil == yil.ToString()).Tutar;
        }



        /// <summary>
        /// Brut asgari ücret bilgilerini döndürür.
        /// </summary>
        /// <returns></returns>
        private List<BrutAsgariUcret> GetBrutAsgariUcretler()
        {
            return _brutAsgariUcretRepository.GetAll();
        }
    }
}
