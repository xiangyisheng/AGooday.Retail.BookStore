using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AGooday.Retail.BookStore.Web.Razor
{
    public class Startup
    {
        /// <summary>
        /// 此方法由运行时调用。使用此方法向容器添加服务。
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // 注册模块=>和BookStoreWebRazorModule产生关联
            services.AddApplication<BookStoreWebRazorModule>();
        }

        /// <summary>
        /// 此方法由运行时调用。使用此方法配置 HTTP 请求管道。
        /// </summary>
        /// <param name="app"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}
