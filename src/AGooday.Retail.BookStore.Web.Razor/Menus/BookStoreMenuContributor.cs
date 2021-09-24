using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AGooday.Retail.BookStore.Localization;
using AGooday.Retail.BookStore.MultiTenancy;
using Volo.Abp.Account.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;
using AGooday.Retail.BookStore.Permissions;

namespace AGooday.Retail.BookStore.Web.Razor.Menus
{
    public class BookStoreMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public BookStoreMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
            else if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<BookStoreResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    BookStoreMenus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fas fa-home",
                    order: 0
                )
            );

            var bookStoreMenu = new ApplicationMenuItem(
                BookStorePermissions.GroupName,
                l["Menu:BookStore"],
                icon: "fa fa-book"
            );

            bookStoreMenu.AddItem(new ApplicationMenuItem(
                BookStorePermissions.Books.Default,
                l["Menu:Books"],
                url: "/Books").RequirePermissions(BookStorePermissions.Books.Default)
            );

            bookStoreMenu.AddItem(new ApplicationMenuItem(
                BookStorePermissions.Authors.Default,
                l["Menu:Authors"],
                url: "/Authors").RequirePermissions(BookStorePermissions.Authors.Default)
            );

            context.Menu.AddItem(bookStoreMenu);

            ////CHECK the PERMISSION
            //if (await context.IsGrantedAsync(BookStorePermissions.Books.Default))
            //{
            //    bookStoreMenu.AddItem(new ApplicationMenuItem(
            //        BookStorePermissions.Books.Default,
            //        l["Menu:Books"],
            //        url: "/Books"
            //    ));
            //}

            //if (await context.IsGrantedAsync(BookStorePermissions.Authors.Default))
            //{
            //    bookStoreMenu.AddItem(new ApplicationMenuItem(
            //        BookStorePermissions.Authors.Default,
            //        l["Menu:Authors"],
            //        url: "/Authors"
            //    ));
            //}

            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

            return Task.CompletedTask;
        }

        private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<BookStoreResource>();
            var accountStringLocalizer = context.GetLocalizer<AccountResource>();
            var identityServerUrl = _configuration["AuthServer:Authority"] ?? "";

            context.Menu.AddItem(new ApplicationMenuItem(
                "Account.Manage",
                accountStringLocalizer["MyAccount"],
                $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage?returnUrl={_configuration["App:SelfUrl"]}", icon: "fa fa-cog", order: 1000, null, "_blank")
                .RequireAuthenticated());
            context.Menu.AddItem(new ApplicationMenuItem(
                "Account.Logout",
                l["Logout"],
                url: "~/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000)
                .RequireAuthenticated());

            return Task.CompletedTask;
        }
    }
}
