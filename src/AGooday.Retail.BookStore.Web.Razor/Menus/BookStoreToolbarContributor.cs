using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AGooday.Retail.BookStore.Web.Razor.Components.Toolbar.LoginLink;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.Users;
using AGooday.Retail.BookStore.Web.Components.Notification;

namespace AGooday.Retail.BookStore.Web.Razor.Menus
{
    public class BookStoreToolbarContributor : IToolbarContributor
    {
        public virtual Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name != StandardToolbars.Main)
            {
                return Task.CompletedTask;
            }

            if (context.ServiceProvider.GetRequiredService<ICurrentUser>().IsAuthenticated)
            {
                context.Toolbar.Items.Insert(
                        0,
                        new ToolbarItem(typeof(NotificationViewComponent))
                    ); 
            }

            //if (!context.ServiceProvider.GetRequiredService<ICurrentUser>().IsAuthenticated)
            //{
            //    context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginLinkViewComponent)));
            //}

            return Task.CompletedTask;
        }
    }
}
