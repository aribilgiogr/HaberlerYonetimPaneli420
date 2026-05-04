using Core.Abstracts.BaseModels;
using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;

namespace Data.Repositories
{
    public class KategoriRepository : Repository<Kategori>, IKategoriRepository
    {
        public KategoriRepository(HaberlerContext context) : base(context)
        {
        }
    }
}
