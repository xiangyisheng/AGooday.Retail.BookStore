using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace AGooday.Retail.BookStore.Web.Razor.Pages
{
    public class IndexModel : BookStorePageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}