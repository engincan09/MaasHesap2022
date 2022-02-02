using MaasHesap2022.Bll.EfCore.Abstract.SgkMatrahTavanlar;
using MaasHesap2022.Dal.EfCore;
using MaasHesap2022.Dal.EfCore.Concrete;
using MaasHesap2022.Entity.SgkMatrah;

namespace MaasHesap2022.Bll.EfCore.Concrete.SgkMatrahTavanlar
{
    public class SgkMatrahTavanRepository : EntityBaseRepository<SgkMatrahTavan>, ISgkMatrahTavanRepository
    {
        public SgkMatrahTavanRepository(MaasHesapContext context) : base(context)
        {

        }
    }
}
