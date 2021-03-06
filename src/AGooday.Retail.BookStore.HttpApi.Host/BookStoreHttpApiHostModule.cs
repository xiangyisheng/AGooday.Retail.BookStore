using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AGooday.Retail.BookStore.EntityFrameworkCore;
using AGooday.Retail.BookStore.MultiTenancy;
using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Auditing;

namespace AGooday.Retail.BookStore
{
    [DependsOn(
        typeof(BookStoreHttpApiModule),
        typeof(AbpAutofacModule),
        typeof(AbpCachingStackExchangeRedisModule),
        typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
        typeof(BookStoreApplicationModule),
        typeof(BookStoreEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpSwashbuckleModule)
    )]
    public class BookStoreHttpApiHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            ConfigureDbProperties();
            ConfigureConventionalControllers();
            ConfigureAuthentication(context, configuration);
            ConfigureLocalization();
            ConfigureCache(configuration);
            ConfigureVirtualFileSystem(context);
            ConfigureRedis(context, configuration, hostingEnvironment);
            ConfigureCors(context, configuration);
            ConfigureSwaggerServices(context, configuration);
            ConfigureAbpAuditing();
        }

        private static void ConfigureDbProperties()
        {
            // Global setup DBTablePrefix, DBTablePrefix can not be null! Set to empty string if you don't want a table prefix.
            Volo.Abp.Data.AbpCommonDbProperties.DbTablePrefix = BookStoreConsts.DbTablePrefix;
            Volo.Abp.Data.AbpCommonDbProperties.DbSchema = BookStoreConsts.DbSchema;
            //Volo.Abp.IdentityServer.AbpIdentityServerDbProperties.DbTablePrefix = BookStoreConsts.DbTablePrefix;
            //Volo.Abp.IdentityServer.AbpIdentityServerDbProperties.DbSchema = BookStoreConsts.DbSchema;
        }

        private void ConfigureCache(IConfiguration configuration)
        {
            Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "BookStore:"; });
        }

        private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<BookStoreDomainSharedModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                            $"..{Path.DirectorySeparatorChar}AGooday.Retail.BookStore.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<BookStoreDomainModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                            $"..{Path.DirectorySeparatorChar}AGooday.Retail.BookStore.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<BookStoreApplicationContractsModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                            $"..{Path.DirectorySeparatorChar}AGooday.Retail.BookStore.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<BookStoreApplicationModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                            $"..{Path.DirectorySeparatorChar}AGooday.Retail.BookStore.Application"));
                });
            }
        }

        /// <summary>
        /// ??????API?????????
        /// ????????????????????? /api ???????????????????????????????????????????????? /app ??????????????????opts => { opts.RootPath = "volosoft/book-store"; }
        /// </summary>
        private void ConfigureConventionalControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(BookStoreApplicationModule).Assembly
                    //, opts => { opts.RootPath = "bookstore"; }
                );
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                    options.Audience = "BookStore";
                });
        }

        /// <summary>
        /// ?????????????????? Microsoft.OpenApi.Models;
        /// ??????Swagger?????????????????? Swagger ?????????
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
        {
            //??????Swagger?????????JWT(OAuth)
            context.Services.AddAbpSwaggerGenWithOAuth(
                configuration["AuthServer:Authority"],
                new Dictionary<string, string>
                {
                    {"BookStore", "BookStore API"}
                },
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "BookStore API", //??????
                        Version = "v1", //??????
                        //Description = "BookStore API",//??????
                        //Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        //{
                        //    Name = "BookStore",
                        //    Email = "bookstore@ag.com"
                        //}//??????
                        //License=new OpenApiLicense
                        //{
                        //    Name = "?????????",
                        //    Url = new Uri("http://www.agooday.com/bookstore")
                        //}//?????????
                    });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);

                    #region ??????XML??????
                    ////<GenerateDocumentationFile>true</GenerateDocumentationFile>
                    ////<NoWarn>$(NoWarn);1591</NoWarn>
                    //#region ??????xml??????
                    //   // ??????????????????xml????????????????????????????????????
                    //   var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    //// ??????xml?????????????????????????????????????????????????????????????????????false.
                    //options.IncludeXmlComments(xmlPath, true);
                    //#endregion 
                    #endregion
                });
        }
        private void ConfigureAbpAuditing()
        {
            Configure<AbpAuditingOptions>(options =>
            {
                options.ApplicationName = "BookStoreAPI";
                options.IsEnabledForGetRequests = true;
                //options.IgnoredTypes.Add(typeof(Books.Book));
                options.EntityHistorySelectors.AddAllEntities();
            });
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("ar", "ar", "??????????????"));
                options.Languages.Add(new LanguageInfo("cs", "cs", "??e??tina"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
                options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
                options.Languages.Add(new LanguageInfo("fr", "fr", "Fran??ais"));
                options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
                options.Languages.Add(new LanguageInfo("it", "it", "Italian", "it"));
                options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
                options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Portugu??s"));
                options.Languages.Add(new LanguageInfo("ru", "ru", "??????????????"));
                options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "T??rk??e"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "????????????"));
                options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "????????????"));
                options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch", "de"));
                options.Languages.Add(new LanguageInfo("es", "es", "Espa??ol", "es"));
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

        private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }

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
            app.UseCors();
            app.UseAuthentication();

            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseAuthorization();

            //??????Swagger?????????
            app.UseSwagger();
            //??????SwaggerUI
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API");
                //options.RoutePrefix = "";//??????????????????
                //options.HeadContent = "";//??????????????????
                //options.DocumentTitle = "";//??????????????????
                //https://github.com/swagger-api/swagger-ui/blob/master/dist/index.html
                //options.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("BsAPI.Swagger.index.html");

                var configuration = context.GetConfiguration();
                options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
                options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
                options.OAuthScopes("BookStore");
            });

            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseUnitOfWork();
            app.UseConfiguredEndpoints();
        }
    }
}
