using System.Threading.Tasks;

namespace AGooday.Retail.BookStore.Data
{
    public interface IBookStoreDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
