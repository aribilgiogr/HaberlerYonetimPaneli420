namespace Core.Abstracts.BaseModels
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
        public bool Aktif { get; set; } = true;
        public bool Silindi { get; set; } = false;
    }
}
