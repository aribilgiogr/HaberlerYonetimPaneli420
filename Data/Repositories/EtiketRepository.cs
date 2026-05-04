using Core.Abstracts.BaseModels;
using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;

namespace Data.Repositories
{
    public class EtiketRepository : Repository<Etiket>, IEtiketRepository
    {
        public EtiketRepository(HaberlerContext context) : base(context)
        {
        }
    }
}
