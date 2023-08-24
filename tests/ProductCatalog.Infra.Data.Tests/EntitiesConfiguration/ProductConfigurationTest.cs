using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Infra.Data.EntitiesConfiguration;

namespace ProductCatalog.Infra.Data.Tests.EntitiesConfiguration
{
    public class ProductConfigurationTest
    {
        [Fact(DisplayName = "HasKey - Product With Valid HasKey")]
        public void ProductConfiguration_HasKey_ShouldReturnProductWithValidHasKey()
        {
            var modelBuilder = new ModelBuilder();
            var entityBuilder = modelBuilder.Entity<Product>();
            var configuration = new ProductConfiguration();

            configuration.Configure(entityBuilder);

            IMutableEntityType entityType = modelBuilder.Model.FindEntityType(typeof(Product));
            Assert.NotNull(entityType);

            var key = entityType.FindPrimaryKey();
            Assert.NotNull(key);
            Assert.Equal(nameof(Product.Id), key.Properties[0].Name);
        }

        [Fact(DisplayName = "HasKey - Product With Invalid HasKey")]
        public void ProductConfiguration_HasKey_ShouldReturnProductWithInvalidHasKey()
        {
            var modelBuilder = new ModelBuilder();
            var entityBuilder = modelBuilder.Entity<Product>();
            var configuration = new ProductConfiguration();

            configuration.Configure(entityBuilder);

           IMutableEntityType entityType = modelBuilder.Model.FindEntityType(typeof(Product));
            Assert.NotNull(entityType);

            var key = entityType.FindPrimaryKey();
            Assert.NotNull(key);

            var incorrectKeyName = "IncorrectKeyName";
            Assert.NotEqual(incorrectKeyName, key.Properties[0].Name);
        }



        [Fact(DisplayName = "HasMaxLength - Product With Max Length Name")]
        public void ProductConfiguration_NameMaxLength_ShouldHaveCorrectMaxLength()
        {
            var modelBuilder = new ModelBuilder();
            var entityBuilder = modelBuilder.Entity<Product>();
            var configuration = new ProductConfiguration();

            configuration.Configure(entityBuilder);

            IMutableEntityType entityType = modelBuilder.Model.FindEntityType(typeof(Product));
            Assert.NotNull(entityType);

            var nameProperty = entityType.FindProperty(nameof(Product.Name));
            Assert.NotNull(nameProperty);

            Assert.Equal(100, nameProperty.GetMaxLength());
        }

        [Fact(DisplayName = "HasMaxLength - Product With Long Max Length Name")]
        public void ProductConfiguration_NameMaxLength_ShouldHaveIncorrectMaxLength()
        {
            var modelBuilder = new ModelBuilder();
            var entityBuilder = modelBuilder.Entity<Product>();
            var configuration = new ProductConfiguration();

            configuration.Configure(entityBuilder);

            IMutableEntityType entityType = modelBuilder.Model.FindEntityType(typeof(Product));
            Assert.NotNull(entityType);

            var nameProperty = entityType.FindProperty(nameof(Product.Name));
            Assert.NotNull(nameProperty);

            Assert.NotEqual(101, nameProperty.GetMaxLength());
        }


        [Fact(DisplayName = "HasMaxLength - Product With Max Length Description")]
        public void ProductConfiguration_DescriptionMaxLength_ShouldHaveCorrectMaxLength()
        {
            var modelBuilder = new ModelBuilder();
            var entityBuilder = modelBuilder.Entity<Product>();
            var configuration = new ProductConfiguration();

            configuration.Configure(entityBuilder);

            IMutableEntityType entityType = modelBuilder.Model.FindEntityType(typeof(Product));
            Assert.NotNull(entityType);

            var descriptionProperty = entityType.FindProperty(nameof(Product.Description));
            Assert.NotNull(descriptionProperty);

            Assert.Equal(200, descriptionProperty.GetMaxLength());
        }

        [Fact(DisplayName = "HasMaxLength - Product With Long Max Length Description")]
        public void ProductConfiguration_DescriptionMaxLength_ShouldHaveIncorrectMaxLength()
        {
            var modelBuilder = new ModelBuilder();
            var entityBuilder = modelBuilder.Entity<Product>();
            var configuration = new ProductConfiguration();

            configuration.Configure(entityBuilder);

            IMutableEntityType entityType = modelBuilder.Model.FindEntityType(typeof(Product));
            Assert.NotNull(entityType);

            var descriptionProperty = entityType.FindProperty(nameof(Product.Description));
            Assert.NotNull(descriptionProperty);

            Assert.NotEqual(201, descriptionProperty.GetMaxLength());
        }


        [Fact(DisplayName = "HasMaxLength - Product With Precision Price")]
        public void ProductConfiguration_PricePrecision_ShouldHaveCorrectPrecision()
        {
            var modelBuilder = new ModelBuilder();
            var entityBuilder = modelBuilder.Entity<Product>();
            var configuration = new ProductConfiguration();

            configuration.Configure(entityBuilder);

            IMutableEntityType entityType = modelBuilder.Model.FindEntityType(typeof(Product));
            Assert.NotNull(entityType);

            var priceProperty = entityType.FindProperty(nameof(Product.Price));
            Assert.NotNull(priceProperty);

            Assert.Equal(10, priceProperty.GetPrecision());
            Assert.Equal(2, priceProperty.GetScale());
        }

        [Fact(DisplayName = "HasMaxLength - Product With Long Precision Price")]
        public void ProductConfiguration_PricePrecision_ShouldHaveIncorrectPrecision()
        {
           var modelBuilder = new ModelBuilder();
            var entityBuilder = modelBuilder.Entity<Product>();
            var configuration = new ProductConfiguration();

            configuration.Configure(entityBuilder);

            IMutableEntityType entityType = modelBuilder.Model.FindEntityType(typeof(Product));
            Assert.NotNull(entityType);

            var priceProperty = entityType.FindProperty(nameof(Product.Price));
            Assert.NotNull(priceProperty);

            Assert.NotEqual(12, priceProperty.GetPrecision());
            Assert.Equal(2, priceProperty.GetScale());
        }

    }
}
