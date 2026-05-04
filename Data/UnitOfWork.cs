using Core.Abstracts;
using Core.Abstracts.IRepositories;
using Data.Contexts;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HaberlerContext context;

        public UnitOfWork(HaberlerContext context)
        {
            this.context = context;
        }

        private IMakaleRepository? makaleler;
        public IMakaleRepository Makaleler => makaleler ??= new MakaleRepository(context);

        private IKategoriRepository? kategoriler;
        public IKategoriRepository Kategoriler => kategoriler ??= new KategoriRepository(context);

        private IEtiketRepository? etiketler;
        public IEtiketRepository Etiketler => etiketler ??= new EtiketRepository(context);

        public async Task CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async ValueTask DisposeAsync() => await context.DisposeAsync();
    }
}
