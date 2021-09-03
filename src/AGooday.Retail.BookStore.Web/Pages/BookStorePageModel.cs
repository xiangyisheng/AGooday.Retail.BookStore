﻿using AGooday.Retail.BookStore.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AGooday.Retail.BookStore.Web.Pages
{
    public abstract class BookStorePageModel : AbpPageModel
    {
        protected BookStorePageModel()
        {
            LocalizationResourceType = typeof(BookStoreResource);
        }
    }
}