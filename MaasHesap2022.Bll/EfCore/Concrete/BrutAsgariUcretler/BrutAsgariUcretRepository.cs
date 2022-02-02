using MaasHesap2022.Bll.EfCore.Abstract.BrutAsgariUcretler;
using MaasHesap2022.Dal.EfCore;
using MaasHesap2022.Dal.EfCore.Concrete;
using MaasHesap2022.Entity.BrutAsgariUcret;

namespace MaasHesap2022.Bll.EfCore.Concrete.BrutAsgariUcretler
{
    public class BrutAsgariUcretRepository : EntityBaseRepository<BrutAsgariUcret>, IBrutAsgariUcretRepository
    {
        public BrutAsgariUcretRepository(MaasHesapContext context) : base(context)
        {

        }
    }
}
