using Core.Abstracts.BaseModels;
using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;

namespace Data.Repositories
{
    public class MakaleRepository : Repository<Makale>, IMakaleRepository
    {
        public MakaleRepository(HaberlerContext context) : base(context)
        {
        }

        public async Task YayinlaGeriAlAsync(int makaleId)
        {
            var makale = await base.ReadByIdAsync(makaleId);
            if (makale != null)
            {
                makale.Taslak = !makale.Taslak;
                makale.YayinlanmaTarihi = makale.Taslak ? null : DateTime.Now;
                await base.UpdateAsync(makale);
            }
        }
    }
}
