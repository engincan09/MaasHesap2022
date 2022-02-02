using MaasHesap2022.Bll.EfCore.Abstract.GelirVergisiDilimler;
using MaasHesap2022.Dal.EfCore;
using MaasHesap2022.Dal.EfCore.Concrete;
using MaasHesap2022.Entity.GelirVergisiDilimleri;

namespace MaasHesap2022.Bll.EfCore.Concrete.GelirVergisiDilimler
{
    public class GelirVergisiDilimlerRepository : EntityBaseRepository<GelirVergisiDilim>, IGelirVergisiDilimlerRepository
    {
        public GelirVergisiDilimlerRepository(MaasHesapContext context) : base(context)
        {

        }
    }
}
