using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AGooday.Retail.BookStore.Web.Razor
{
    [Dependency(ReplaceServices = true)]
    public class BookStoreBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "BookStore";
    }
}
