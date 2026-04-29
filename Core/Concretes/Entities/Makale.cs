using Core.Abstracts.BaseModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Concretes.Entities
{
    [Table("makaleler")]
    public class Makale : BaseEntity
    {
        // null!: Bu içeriğin gönderileceğini dair garanti veriyorum demektir.
        public string Baslik { get; set; } = null!;

        // ?: Bu içeriğin gönderilmesinin zorunluluğu yoktur anlamına gelir.
        public string? KapakGorseliYolu { get; set; }

        public string Icerik { get; set; } = null!;

        [ForeignKey("Kategori")]
        public int KategoriId { get; set; }

        // virtual: Tembel yükleme (lazy-loading) prensibi ile gerektiğinde doldurulur bu sayede bellek sızıntısı ve/veya taşması sorunlarını çözer.
        public virtual Kategori? Kategori { get; set; }

        public virtual ICollection<Etiket> Etiketler { get; set; } = [];
    }
}
