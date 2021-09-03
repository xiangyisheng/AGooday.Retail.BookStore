using AGooday.Retail.BookStore.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AGooday.Retail.BookStore.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class BookStoreController : AbpController
    {
        protected BookStoreController()
        {
            LocalizationResource = typeof(BookStoreResource);
        }
    }
}