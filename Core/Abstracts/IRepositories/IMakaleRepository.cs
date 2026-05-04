using Core.Abstracts.BaseModels;
using Core.Concretes.Entities;

namespace Core.Abstracts.IRepositories
{
    public interface IMakaleRepository : IRepository<Makale>
    {
        Task YayinlaGeriAlAsync(int makaleId);
    }
}
