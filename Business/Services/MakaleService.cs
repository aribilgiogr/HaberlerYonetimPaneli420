using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;

namespace Business.Services
{
    public class MakaleService : IMakaleService
    {
        private readonly IUnitOfWork unitOfWork;

        public MakaleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<MakaleKartDto>> MakaleleriGetir()
        {
            throw new NotImplementedException();
        }
    }
}
