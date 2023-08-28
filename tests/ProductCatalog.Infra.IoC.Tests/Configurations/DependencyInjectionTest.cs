using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Interfaces;
using ProductCatalog.Infra.Data.Context;
using ProductCatalog.Infra.IoC.Configurations;

namespace ProductCatalog.Infra.IoC.Tests.Configurations
{
    public class DependencyInjectionTest
    {
        private readonly ILogger<DependencyInjectionTest> _logger;

        public DependencyInjectionTest()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            _logger = serviceProvider.GetService<ILogger<DependencyInjectionTest>>();
        }

        [Fact(DisplayName = "AddInfrastructure - Services Must Be Validated")]
        public void DependencyInjection_AddInfrastructure_ServicesShouldBeRegisteredCorrectly()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    {"ConnectionStrings:DefaultConnection", "Data Source=DESKTOP-33V8307\\SQLEXPRESS;Initial Catalog=ProductCatalogDB;Integrated Security=True"}
                })
                .Build();

            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddInfrastructure(configuration);
            var serviceProvider = services.BuildServiceProvider();

            Assert.NotNull(serviceProvider.GetService<ApplicationDbContext>());
            Assert.NotNull(serviceProvider.GetService<IProductRepository>());
            Assert.NotNull(serviceProvider.GetService<ICategoryRepository>());
            Assert.NotNull(serviceProvider.GetService<IProductService>());
            Assert.NotNull(serviceProvider.GetService<ICategoryService>());
        }

        [Fact(DisplayName = "AddInfrastructure - Services Must Not Be Validated")]
        public void DependencyInjection_AddInfrastructure_ServicesShouldBeRegisteredAsNull()
        {
            var services = new ServiceCollection();

            Assert.Throws<ArgumentNullException>(() => services.AddInfrastructure(null));
        }
    }
}
