using Core.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IMakaleService
    {
        Task<IEnumerable<MakaleKartDto>> MakaleleriGetir();
        Task MakaleEkleAsync(YeniMakaleDto yeniMakale);

        // Kategoriler:
        Task<IEnumerable<KategoriDto>> KategorileriGetir();
        Task KategoriEkleAsync(string ad);
        Task KategoriSilAsync(int id);
        Task KategoriGuncelleAsync(int id, string yeniAd);
    }
}
