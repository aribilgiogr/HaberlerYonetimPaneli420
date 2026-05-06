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

        public async Task<IEnumerable<MakaleKartDto>> MakaleleriGetir()
        {
            var makaleler = await unitOfWork.Makaleler.ReadManyAsync(x => x.Aktif && !x.Silindi && !x.Taslak, "Kategori", "Etiketler");
            
            return from m in makaleler
                   select new MakaleKartDto
                   {
                       Id = m.Id,
                       Baslik = m.Baslik,
                       KapakGorseliYolu = m.KapakGorseliYolu,
                       YayinlanmaTarihi = m.YayinlanmaTarihi,
                       KategoriId = m.KategoriId,
                       KategoriAd = m.Kategori.Ad,
                       Etiketler = m.Etiketler.Select(e => e.Ad).ToList()
                   };
        }
    }
}
