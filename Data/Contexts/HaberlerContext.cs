using Core.Concretes.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    // Genel dokümanlarda ve örneklerde bu yapının adı ApplicationDbContext olarak geçer fakat o da özel isimdir.
    public class HaberlerContext : DbContext
    {
        public HaberlerContext(DbContextOptions<HaberlerContext> options) : base(options)
        {

        }

        public virtual DbSet<Makale> Makaleler { get; set; }
        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<Etiket> Etiketler { get; set; }
    }
}
