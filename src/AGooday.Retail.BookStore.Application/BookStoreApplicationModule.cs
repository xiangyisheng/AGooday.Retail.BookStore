using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace AGooday.Retail.BookStore
{
    [DependsOn(
        typeof(BookStoreDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(BookStoreApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpSettingManagementApplicationModule)
        )]
    public class BookStoreApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                //AddMaps 注册给定类的程序集中所有的配置类,通常使用模块类. 它还会注册 attribute 映射.
                //https://docs.automapper.org/en/stable/Attribute-mapping.html
                options.AddMaps<BookStoreApplicationModule>();

                //如果你有多个配置文件,并且只需要为其中几个启用验证,那么首先使用AddMaps而不进行验证,
                //然后为你想要验证的每个配置文件使用AddProfile.
                options.AddProfile<BookStoreApplicationAutoMapperProfile>(validate: true);
            });
        }
    }
}
