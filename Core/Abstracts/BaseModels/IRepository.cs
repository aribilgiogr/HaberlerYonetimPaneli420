using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.BaseModels
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task CreateManyAsync(IEnumerable<T> entities);

        Task<T?> ReadByIdAsync(object id);

        // Expression<Func<T, bool>>? where: SELECT * FROM <tablo_adı> WHERE <filtre koşulları> senaryosunu grçekleştirmek için veri tabanına filtre koşullarını yollayan yapıdır, null ise o koşullar gönderilmez.

        // includes: Ardışık olarak yazılan foreignkey ilişkilerini JOIN ile tabloları birleştirerek getirebilir. lazy-loading kullanıldığından dolayı gerektiğinde belirtilmesi için bu alan kullanılır.
        Task<IEnumerable<T>> ReadManyAsync(Expression<Func<T, bool>>? where = null, params string[] includes);

        Task UpdateAsync(T entity);
        Task UpdateMany(IEnumerable<T> entities);

        Task DeleteAsync(object id);

        Task<int> CountAsync(Expression<Func<T, bool>>? where = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>>? where = null);
    }
}
