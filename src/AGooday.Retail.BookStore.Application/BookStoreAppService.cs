using System;
using System.Collections.Generic;
using System.Text;
using AGooday.Retail.BookStore.Localization;
using Volo.Abp.Application.Services;

namespace AGooday.Retail.BookStore
{
    /* Inherit your application services from this class.
     */
    public abstract class BookStoreAppService : ApplicationService
    {
        protected BookStoreAppService()
        {
            LocalizationResource = typeof(BookStoreResource);
        }
    }
}
