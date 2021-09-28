using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace AGooday.Retail.BookStore.Web.Pages.Identity.Users.ClickMeToolbarItem
{
    public class ClickMeToolbarItemViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Pages/Identity/Users/ClickMeToolbarItem/Default.cshtml");
        }
    }
}
