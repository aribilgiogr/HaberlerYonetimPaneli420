using Core.Abstracts.BaseModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Concretes.Entities
{
    [Table("kategoriler")]
    public class Kategori : BaseEntity
    {
        public string Ad { get; set; } = null!;
        // İlişkilendirilmiş makale listesini gerektiğinde doldurur.
        public virtual ICollection<Makale> Makaleler { get; set; } = [];
    }
}
