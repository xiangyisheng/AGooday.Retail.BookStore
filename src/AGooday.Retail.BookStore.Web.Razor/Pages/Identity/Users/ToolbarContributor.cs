using AGooday.Retail.BookStore.Web.Pages.Identity.Users.ClickMeToolbarItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.PageToolbars;

namespace AGooday.Retail.BookStore.Web.Pages.Identity.Users
{
    public class ToolbarContributor : PageToolbarContributor
    {
        public override Task ContributeAsync(PageToolbarContributionContext context)
        {
            context.Items.Insert(0, new PageToolbarItem(typeof(ClickMeToolbarItemViewComponent)));

            return Task.CompletedTask;
        }
    }
}
