using AGooday.Retail.BookStore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AGooday.Retail.BookStore
{
    [DependsOn(
        typeof(BookStoreEntityFrameworkCoreTestModule)
        )]
    public class BookStoreDomainTestModule : AbpModule
    {

    }
}