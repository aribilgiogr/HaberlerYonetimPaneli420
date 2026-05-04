using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs
{
    public class MakaleKartDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; } = null!;
        public string? KapakGorseliYolu { get; set; }
        public DateTime? YayinlanmaTarihi { get; set; }
        public int KategoriId { get; set; }
        public string KategoriAd { get; set; } = null!;
        public IEnumerable<string> Etiketler { get; set; } = [];
    }
}
