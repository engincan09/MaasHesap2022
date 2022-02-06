using MaasHesap2022.Bll.EfCore.Abstract.Bordrolar;
using MaasHesap2022.Bll.EfCore.Abstract.BrutAsgariUcretler;
using MaasHesap2022.Bll.EfCore.Abstract.GelirVergisiDilimler;
using MaasHesap2022.Bll.EfCore.Abstract.SgkMatrahTavanlar;
using MaasHesap2022.Dal.EfCore;
using MaasHesap2022.Dal.EfCore.Concrete;
using MaasHesap2022.Dal.Extensions;
using MaasHesap2022.Dto.GelirVergsiDto;
using MaasHesap2022.Dto.SgkDto;
using MaasHesap2022.Entity.Bordrolar;
using MaasHesap2022.Entity.BrutAsgariUcret;
using MaasHesap2022.Entity.GelirVergisiDilimleri;
using MaasHesap2022.Entity.SgkMatrah;
using System.Collections.Generic;
using System.Linq;

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
        /// Gelir vergisini döndürür.
        /// </summary>
        /// <param name="brutUcret"></param>
        /// <param name="sgkIsci"></param>
        /// <param name="issizlikIsci"></param>
        /// <param name="kumulatifGelirVergisiMatrahi"></param>
        /// <param name="yil"></param>
        /// <returns></returns>
        private GelirVergisiResponseDto HesaplaGelirVergisi(decimal brutUcret, decimal sgkIsci, decimal issizlikIsci, decimal kumulatifGelirVergisiMatrahi, int yil)
        {
            GelirVergisiResponseDto response = new GelirVergisiResponseDto();
            var gelirVergisiDilimListesi = GetGelirVergisiDilimler(yil);

            decimal gelirVergisiMatrahi = brutUcret - sgkIsci - issizlikIsci.Round();
            decimal toplamMatrah = kumulatifGelirVergisiMatrahi + gelirVergisiMatrahi;

            //Vergi oranını hesaplamak için gelir vergisinin hangi dilimde olduğuna bakıyoruz.
            foreach (var dilim in gelirVergisiDilimListesi)
            {

                if (dilim.AltDilim <= kumulatifGelirVergisiMatrahi && dilim.UstDilim > kumulatifGelirVergisiMatrahi)
                {
                    //Kümülatif gelir vergisi ile işlem yapılan ayın gelir vergisi toplanır ve toplam tutarın hangi veri diliminde olduğuna bakılır
                    if (kumulatifGelirVergisiMatrahi + gelirVergisiMatrahi <= dilim.UstDilim)
                    {
                        response.GelirVergisiDilimList.Add(new GelirVergisiDilimResponseDto
                        {
                            GelirVergisiMatrahi = gelirVergisiMatrahi,
                            GelirVergisiOrani = dilim.Oran,
                            GelirVergisi = (gelirVergisiMatrahi * dilim.Oran).Round()
                        });
                        break;
                    }
                    else
                    {
                        decimal dilimMatrah = dilim.UstDilim - kumulatifGelirVergisiMatrahi;

                        response.GelirVergisiDilimList.Add(new GelirVergisiDilimResponseDto
                        {
                            GelirVergisiMatrahi = dilimMatrah,
                            GelirVergisiOrani = dilim.Oran,
                            GelirVergisi = (dilimMatrah * dilim.Oran).Round()
                        });
                        kumulatifGelirVergisiMatrahi = dilim.UstDilim;
                        gelirVergisiMatrahi = kumulatifGelirVergisiMatrahi + gelirVergisiMatrahi - kumulatifGelirVergisiMatrahi;
                    }
                }
            }
            response.GelirVergisi = response.GelirVergisiDilimList.Sum(x => x.GelirVergisi);
            response.GelirVergisiMatrahi = response.GelirVergisiDilimList.Sum(x => x.GelirVergisiMatrahi);
            return response;
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
        private List<GelirVergisiDilim> GetGelirVergisiDilimler(int yil)
        {
            return _gelirVergisiDilimlerRepository.GetAll(m => m.Yil == yil.ToString());
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
            return _sgkMatrahTavanRepository.Get(m => m.Yil == yil.ToString()).Tutar;
        }

        /// <summary>
        /// Brut asgari ücret bilgilerini döndürür.
        /// </summary>
        /// <returns></returns>
        private List<BrutAsgariUcret> GetBrutAsgariUcretler()
        {
            return _brutAsgariUcretRepository.GetAll();
        }

        /// <summary>
        /// Damga vergisi
        /// </summary>
        /// <param name="brutUcret"></param>
        /// <returns></returns>
        private  decimal HesaplaDamgaVergisi(decimal brutUcret)
        {
            return (brutUcret * DamgaVergisiOran).Round();
        }
    }
}
