using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Core.ApplicationService.Categories.Commands;
using Shop.Core.ApplicationService.Categories.Queries;
using Shop.Core.ApplicationService.Masters.Commands;
using Shop.Core.ApplicationService.Masters.Queries;
using Shop.Core.Domain.Categories.Commands;
using Shop.Core.Domain.Categories.Entities;
using Shop.Core.Domain.Categories.Queries;
using Shop.Core.Domain.Categories.Repositories;
using Shop.Core.Domain.Masters.Commands;
using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Queries;
using Shop.Core.Domain.Masters.Repositories;
using Shop.Core.Resources.Resources;
using Shop.Framework.Commands;
using Shop.Framework.Queries;
using Shop.Framework.Resources;
using Shop.Infrastructure.Data.SqlServer;
using Shop.Infrastructure.Data.SqlServer.Categories.Repositories;
using Shop.Infrastructure.Data.SqlServer.Masters.Repositories;
using System.Collections.Generic;

namespace Shop.EndPoints.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            // language service
            services.AddLocalization(option => option.ResourcesPath = "Resources");
            services.AddTransient<IResourceManager, ResourceManager<SharedResource>>();

            // mvc
            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(SharedResource));
                });


            // add database
            services.AddDbContextPool<ShopDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("ShopCnnString")));

            // add dispatchers
            services.AddTransient<CommandDispatcher>();
            services.AddTransient<QueryDispatcher>();


            // Master services
            services.AddTransient<IMasterCommandRepository, MasterCommandRepository>();
            services.AddTransient<CommandHandler<AddMasterCommand>, AddMasterCommandHandler>();
            services.AddTransient<IMasterQueryRepository, MasterQueryRepository>();
            services.AddTransient<IQueryHandler<GetAllMasterQuery, List<Master>>, GetAllMasterQueryHandler>();
            services.AddTransient<IQueryHandler<GetByIdMasterQuery, Master>, GetByIdMasterQueryHandler>();




            // Category services
            services.AddTransient<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddTransient<CommandHandler<AddCategoryCommand>, AddCategoryCommandHandler>();
            services.AddTransient<ICategoryQueryRepository, CategoryQueryRepository>();
            services.AddTransient<IQueryHandler<GetAllCategoryQuery, List<Category>>, GetAllCategoryQueryHandler>();
            services.AddTransient<IQueryHandler<GetParentCategoriesQuery, List<Category>>, GetParentCategoriesQueryHandler>();



            // MasterProduct services
            services.AddTransient<IMasterProductCommandRepository, MasterProductCommandRepository>();
            services.AddTransient<CommandHandler<AddMasterProductCommand>, AddMasterProductCommandHandler>();
            services.AddTransient<IMasterProductQueryRepository, MasterProductQueryRepository>();
            services.AddTransient<IQueryHandler<GetAllMasterProductQuery, List<MasterProduct>>, GetAllMasterProductQueryHandler>();
            services.AddTransient<IQueryHandler<GetByIdMasterProductQuery, MasterProduct>, GetByIdMasterProductQueryHandler>();




        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
