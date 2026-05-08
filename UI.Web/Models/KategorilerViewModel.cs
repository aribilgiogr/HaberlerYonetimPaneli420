using Core.Concretes.DTOs;

namespace UI.Web.Models
{
    public class KategorilerViewModel
    {
        public IEnumerable<KategoriDto> Kategoriler { get; set; } = [];
        public KategoriDto? SeciliKategori { get; set; }
    }
}
