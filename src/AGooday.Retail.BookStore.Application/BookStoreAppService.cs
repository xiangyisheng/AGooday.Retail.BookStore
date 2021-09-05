using System;
using System.Collections.Generic;
using System.Text;
using AGooday.Retail.BookStore.Localization;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace AGooday.Retail.BookStore
{
    /* Inherit your application services from this class.
     */
    [RemoteService(Name = BookStoreRemoteServiceConsts.RemoteServiceName)]
    public abstract class BookStoreAppService : ApplicationService
    {
        protected BookStoreAppService()
        {
            LocalizationResource = typeof(BookStoreResource);
        }
    }
}
