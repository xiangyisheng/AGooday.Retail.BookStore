using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using AGooday.Retail.BookStore.Localization;
using AGooday.Retail.BookStore.MultiTenancy;
using AGooday.Retail.BookStore.Web.Razor.Menus;
using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.OpenIdConnect;
using Volo.Abp.AspNetCore.Mvc.Client;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Http.Client.IdentityModel.Web;
using Volo.Abp.Identity.Web;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Web;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.UI;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AGooday.Retail.BookStore.Permissions;
using Volo.Abp.Auditing;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Components.LayoutHook;
using AGooday.Retail.BookStore.Web.Components.GoogleAnalytics;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.PageToolbars;
using Volo.Abp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Button;
using AGooday.Retail.BookStore.Web.Pages.Identity.Users.ClickMeToolbarItem;
using Volo.Abp.Http.Client;

namespace AGooday.Retail.BookStore.Web.Razor
{
    /// <summary>
    /// 继承自：AbpModule
    /// 还需要依赖于AbpVNext的MVC和Autofac等模块
    /// </summary>
    [DependsOn(
        typeof(BookStoreHttpApiModule),
        typeof(BookStoreHttpApiClientModule),
        //typeof(BookStoreApplicationModule),
        typeof(AbpAspNetCoreAuthenticationOpenIdConnectModule),
        typeof(AbpAspNetCoreMvcClientModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAutofacModule),
        typeof(AbpCachingStackExchangeRedisModule),
        typeof(AbpSettingManagementWebModule),
        typeof(AbpHttpClientIdentityModelWebModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpTenantManagementWebModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpSwashbuckleModule)
        )]
    public class BookStoreWebRazorModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(BookStoreResource),
                    typeof(BookStoreDomainSharedModule).Assembly,
                    typeof(BookStoreApplicationContractsModule).Assembly,
                    //typeof(BookStoreApplicationModule).Assembly,
                    typeof(BookStoreWebRazorModule).Assembly
                );
            });
        }

        /// <summary>
        /// 用作依赖注入
        /// </summary>
        /// <param name="context"></param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            //ConfigureDbProperties();
            ConfigureBundles();
            ConfigureCache();
            ConfigureRedis(context, configuration, hostingEnvironment);
            ConfigureUrls(configuration);
            ConfigureAuthentication(context, configuration);
            ConfigureAutoMapper();
            ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureNavigation(configuration);
            ConfigureLayoutHook();
            ConfigurePageToolbar();
            ConfigureMultiTenancy();
            //ConfigureAutoApiControllers();
            ConfigureSwaggerServices(context.Services);
            ConfigureRemoteService(context.Services, configuration);
            ConfigureAbpAuditing();

            Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AuthorizePage("/Books/Index", BookStorePermissions.Books.Default);
                options.Conventions.AuthorizePage("/Books/CreateModal", BookStorePermissions.Books.Create);
                options.Conventions.AuthorizePage("/Books/EditModal", BookStorePermissions.Books.Edit);
            });
        }

        #region Configure
        //private static void ConfigureDbProperties()
        //{
        //    // Global setup DBTablePrefix, DBTablePrefix can not be null! Set to empty string if you don't want a table prefix.
        //    Volo.Abp.Data.AbpCommonDbProperties.DbTablePrefix = BookStoreConsts.DbTablePrefix;
        //    Volo.Abp.Data.AbpCommonDbProperties.DbSchema = BookStoreConsts.DbSchema;
        //    //Volo.Abp.IdentityServer.AbpIdentityServerDbProperties.DbTablePrefix = BookStoreConsts.DbTablePrefix;
        //    //Volo.Abp.IdentityServer.AbpIdentityServerDbProperties.DbSchema = BookStoreConsts.DbSchema;
        //}

        private void ConfigureBundles()
        {
            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Configure(
                    BasicThemeBundles.Styles.Global,
                    bundle =>
                    {
                        bundle.AddFiles("/global-styles.css");
                    }
                );

                options.ScriptBundles.Configure(
                    typeof(Volo.Abp.Identity.Web.Pages.Identity.Users.IndexModel).FullName,
                    bundle =>
                    {
                        bundle.AddFiles("/Pages/Identity/Users/user-extensions.js");
                    });
            });
        }

        private void ConfigureCache()
        {
            Configure<AbpDistributedCacheOptions>(options =>
            {
                options.KeyPrefix = "BookStore:";
            });
        }

        private void ConfigureUrls(IConfiguration configuration)
        {
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            });
        }

        private void ConfigureMultiTenancy()
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies", options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromDays(365);
                })
                .AddAbpOpenIdConnect("oidc", options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                    options.ResponseType = OpenIdConnectResponseType.CodeIdToken;

                    options.ClientId = configuration["AuthServer:ClientId"];
                    options.ClientSecret = configuration["AuthServer:ClientSecret"];

                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.Scope.Add("role");
                    options.Scope.Add("email");
                    options.Scope.Add("phone");
                    options.Scope.Add("BookStore");
                });
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<BookStoreWebRazorModule>();
            });
        }

        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<BookStoreDomainSharedModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}AGooday.Retail.BookStore.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<BookStoreApplicationContractsModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}AGooday.Retail.BookStore.Application.Contracts"));
                    //options.FileSets.ReplaceEmbeddedByPhysical<BookStoreApplicationModule>(
                    //    Path.Combine(hostingEnvironment.ContentRootPath, 
                    //    $"..{Path.DirectorySeparatorChar}AGooday.Retail.BookStore.Application"));
                    options.FileSets.ReplaceEmbeddedByPhysical<BookStoreWebRazorModule>(hostingEnvironment.ContentRootPath);
                });
            }
        }

        private void ConfigureNavigation(IConfiguration configuration)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new BookStoreMenuContributor(configuration));
            });

            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new BookStoreToolbarContributor());
            });
        }

        private void ConfigureLayoutHook()
        {
            Configure<AbpLayoutHookOptions>(options =>
            {
                options.Add(
                    LayoutHooks.Head.Last, //The hook name
                    typeof(GoogleAnalyticsViewComponent) //The component to add
                );
            });
        }

        private void ConfigurePageToolbar()
        {
            Configure<AbpPageToolbarOptions>(options =>
            {
                options.Configure<Volo.Abp.Identity.Web.Pages.Identity.Users.IndexModel>(toolbar =>
                {
                    //向用户管理页面添加新按钮
                    toolbar.AddButton(
                        LocalizableString.Create<BookStoreResource>("ImportFromExcel"),
                        icon: "file-import",
                        id: "ImportUsersFromExcel",
                        type: AbpButtonType.Secondary
                    );

                    //将视图组件添加到页面工具栏
                    //toolbar.AddComponent<ClickMeToolbarItemViewComponent>();
                    toolbar.Contributors.Add(new Web.Pages.Identity.Users.ToolbarContributor());
                });
            });
        }

        //private void ConfigureAutoApiControllers()
        //{
        //    Configure<AbpAspNetCoreMvcOptions>(options =>
        //    {
        //        options.ConventionalControllers.Create(typeof(BookStoreApplicationModule).Assembly);
        //    });
        //}

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddAbpSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );
        }

        private void ConfigureRemoteService(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AbpRemoteServiceOptions>(options =>
            {
                options.RemoteServices.Default =
                    new RemoteServiceConfiguration(configuration["RemoteServices:Default:BaseUrl"]);
            });
        }

        private void ConfigureRedis(
            ServiceConfigurationContext context,
            IConfiguration configuration,
            IWebHostEnvironment hostingEnvironment)
        {
            if (!hostingEnvironment.IsDevelopment())
            {
                var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
                context.Services
                    .AddDataProtection()
                    .PersistKeysToStackExchangeRedis(redis, "BookStore-Protection-Keys");
            }
        }
        private void ConfigureAbpAuditing()
        {
            Configure<AbpAuditingOptions>(options =>
            {
                options.ApplicationName = "BookStore";
                options.IsEnabledForGetRequests = true;
                //options.IgnoredTypes.Add(typeof(Books.Book));
                options.EntityHistorySelectors.AddAllEntities();
            });
        }
        #endregion

        /// <summary>
        /// 用来注册中间件
        /// </summary>
        /// <param name="context"></param>
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();

            if (!env.IsDevelopment())
            {
                app.UseErrorPage();
            }

            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();

            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseAuthorization();
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API");
            });
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }
    }
}
