using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;

namespace Business.Services
{
    public class MakaleService : IMakaleService
    {
        private readonly IUnitOfWork unitOfWork;

        public MakaleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task KategoriEkleAsync(string ad)
        {
            var kategori = new Kategori { Ad = ad };
            await unitOfWork.Kategoriler.CreateAsync(kategori);
            await unitOfWork.CommitAsync();
        }

        public Task KategoriGuncelleAsync(int id, string yeniAd)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<KategoriDto>> KategorileriGetir()
        {
            var kategoriler = await unitOfWork.Kategoriler.ReadManyAsync();
            return from k in kategoriler
                   select new KategoriDto
                   {
                       Id = k.Id,
                       Ad = k.Ad
                   };
        }

        public Task KategoriSilAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task MakaleEkleAsync(YeniMakaleDto yeniMakale)
        {
            // yeniMakale ile gelen görselin kaydedilmesi:
            string? kapakGorseliYolu = null;
            if (yeniMakale.KapakGorseli != null && yeniMakale.KapakGorseli.Length > 0)
            {
                // Görseli kaydetmek için bir yol belirleyelim (örneğin "wwwroot/images/makaleler/")
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "makaleler");
                if (!Directory.Exists(uploadsFolder))
                {
                    // Klasör yoksa oluştur.
                    Directory.CreateDirectory(uploadsFolder);
                }
                // Aynı dosya isimleri sorun çıkaracağından her gelen dosya için bir GUID (Global Unique Identifier) oluşturup dosya adına ekleyelim.
                // örn: "123e4567-e89b-12d3-a456-426614174000.jpg"
                var filename = $"{Guid.NewGuid()}{Path.GetExtension(yeniMakale.KapakGorseli.FileName)}";
                var filepath = Path.Combine(uploadsFolder, filename);

                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    yeniMakale.KapakGorseli.CopyTo(stream);
                }

                // Veritabanında saklanacak yolu oluştur (örneğin "/images/makaleler/benzersizdosyaadı.jpg")
                kapakGorseliYolu = $"/images/makaleler/{filename}";
            }

            var makale = new Makale
            {
                Baslik = yeniMakale.Baslik,
                Icerik = yeniMakale.Icerik,
                KategoriId = yeniMakale.KategoriId,
                KapakGorseliYolu = kapakGorseliYolu
            };
            await unitOfWork.Makaleler.CreateAsync(makale);
            await unitOfWork.CommitAsync();

            // Etiketleri ekleyelim:
            var etiketler = from e in yeniMakale.Etiketler
                            select new Etiket
                            {
                                Ad = e,
                                MakaleId = makale.Id
                            };

            await unitOfWork.Etiketler.CreateManyAsync(etiketler);
            await unitOfWork.CommitAsync();
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
