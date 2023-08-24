using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Infra.Data.EntitiesConfiguration;

namespace ProductCatalog.Infra.Data.Tests.EntitiesConfiguration
{
    public class CategoryConfigurationTest
    {
        [Fact(DisplayName = "HasKey - Category With Valid HasKey")]
        public void CategoryConfiguration_HasKey_ShouldReturnCategoryWithValidHasKey()
        {
            var modelBuilder = new ModelBuilder();
            var entityBuilder = modelBuilder.Entity<Category>();
            var configuration = new CategoryConfiguration();

            configuration.Configure(entityBuilder);

            IMutableEntityType entityType = modelBuilder.Model.FindEntityType(typeof(Category));
            Assert.NotNull(entityType);

            var key = entityType.FindPrimaryKey();
            Assert.NotNull(key);
            Assert.Equal(nameof(Category.Id), key.Properties[0].Name);
        }

        [Fact(DisplayName = "HasKey - Category With Invalid HasKey")]
        public void CategoryConfiguration_HasKey_ShouldReturnCategoryWithInvalidHasKey()
        {
            var modelBuilder = new ModelBuilder();
            var entityBuilder = modelBuilder.Entity<Category>();
            var configuration = new CategoryConfiguration();

            configuration.Configure(entityBuilder);

            IMutableEntityType entityType = modelBuilder.Model.FindEntityType(typeof(Category));
            Assert.NotNull(entityType);

            var key = entityType.FindPrimaryKey();
            Assert.NotNull(key);

            var incorrectKeyName = "IncorrectKeyName";
            Assert.NotEqual(incorrectKeyName, key.Properties[0].Name);
        }


        [Fact(DisplayName = "HasMaxLength - Category With Max Length Name")]
        public void CategoryConfiguration_HasMaxLength_ShouldReturnCategoryWithValidHasMaxLengthName()
        {
            var modelBuilder = new ModelBuilder();
            var entityBuilder = modelBuilder.Entity<Category>();
            var configuration = new CategoryConfiguration();

            configuration.Configure(entityBuilder);

            IMutableEntityType entityType = modelBuilder.Model.FindEntityType(typeof(Category));
            Assert.NotNull(entityType);

            var nameProperty = entityType.FindProperty(nameof(Category.Name));
            Assert.NotNull(nameProperty);
            Assert.Equal(100, nameProperty.GetMaxLength());
            Assert.True(!nameProperty.IsNullable);
        }

        [Fact(DisplayName = "HasMaxLength - Category With Long Max Length Name")]
        public void CategoryConfiguration_HasMaxLength_ShouldReturnCategoryWithInvalidHasMaxLengthName()
        {
            var modelBuilder = new ModelBuilder();
            var entityBuilder = modelBuilder.Entity<Category>();
            var configuration = new CategoryConfiguration();

            configuration.Configure(entityBuilder);

            IMutableEntityType entityType = modelBuilder.Model.FindEntityType(typeof(Category));
            Assert.NotNull(entityType);

            var nameProperty = entityType.FindProperty(nameof(Category.Name));
            Assert.NotNull(nameProperty);

            Assert.NotEqual(150, nameProperty.GetMaxLength());
        }

    }
}
