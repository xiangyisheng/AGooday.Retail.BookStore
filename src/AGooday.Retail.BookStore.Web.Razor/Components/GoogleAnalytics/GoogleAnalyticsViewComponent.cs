using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace AGooday.Retail.BookStore.Web.Components.GoogleAnalytics
{
    public class GoogleAnalyticsViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Components/GoogleAnalytics/Default.cshtml");
        }
    }
}
