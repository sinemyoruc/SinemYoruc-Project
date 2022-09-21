using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SinemYoruc_Project.Mapper;
using SinemYoruc_Project.Service;

namespace SinemYoruc_Project.StartUpExtension
{
    public static class ExtensionService
    {
        public static void AddServices(this IServiceCollection services)
        {
            // services 
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountDetailService, AccountDetailService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IProductService, ProductService>();


            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}
