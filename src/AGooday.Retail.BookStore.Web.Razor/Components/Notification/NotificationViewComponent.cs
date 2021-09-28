using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace AGooday.Retail.BookStore.Web.Components.Notification
{
    public class NotificationViewComponent : AbpViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Components/Notification/Default.cshtml");
        }
    }
}
