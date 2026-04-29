using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Concretes.Entities
{
    // Table: Veritabanında hangi tablo adıyla saklandığını belirtir, bu olmazsa türkçe ingilizce çatışması oluşur, Etiket sınıfının tablosunun Etikets olduğu varsayılır.
    [Table("etiketler")]
    public class Etiket
    {
        public int Id { get; set; }
        public string Ad { get; set; } = null!;

        [ForeignKey("Makale")]
        public int MakaleId { get; set; }
        public virtual Makale? Makale { get; set; }
        
    }
}
