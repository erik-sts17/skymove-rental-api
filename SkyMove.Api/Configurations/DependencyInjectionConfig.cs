using FluentValidation;
using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using SkyMove.Application.Services.Customers;
using SkyMove.Domain.Interfaces.Repositories;
using SkyMove.Domain.Interfaces.Repositories.Base;
using SkyMove.Infra.Contexts;
using SkyMove.Infra.Repositories;
using SkyMove.Infra.Repositories.Base;
using System.Reflection;

namespace SkyMove.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped(typeof(IWriteRepository<,>), typeof(WriteRepository<,>));

            var connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? throw new ArgumentNullException("Connection string not found");

            services.AddLinqToDBContext<WriteContext>((provider, options)
                => options.UseMySql(connectionString)
                          .UseDefaultLogging(provider));

            services.AddValidatorsFromAssembly(Assembly.Load("SkyMove.Application"));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
