using FluentAssertions;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Validation;
using System.Reflection;

namespace ProductCatalog.Domain.Tests.Entities
{
    public class ProductValidateDomainTest
    {
        [Fact(DisplayName = "ValidateDomain - Product With Valid Domain")]
        public void Product_ValidateProduct_ShouldReturnProductWithValidParameterAndNotThrowException()
        {
            string name = "Caderno Espiral";
            string description = "Caderno espiral com 100 fôlhas";
            decimal price = 7.99m;
            int stock = 50;
            string image = "caderno-1.png";

            var product = new Product("Caderno Espiral", "Caderno espiral com 100 fôlhas", 7.99m, 50, "caderno-1.png");

            MethodInfo method = typeof(Product).GetMethod("ValidateDomain", BindingFlags.NonPublic | BindingFlags.Instance);
            Action action = () =>
            {
                method.Invoke(product, new object[] { name, description, price, stock, image });
            };

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "ValidateDomain - Product With Empty Name")]
        public void Product_ValidateProduct_ShouldReturnProductWithEmptyNameAndExceptionsThrown()
        {
            var product = new Product("Caderno Espiral", "Caderno espiral com 100 fôlhas", 7.99m, 50, "caderno-1.png");

            MethodInfo method = typeof(Product).GetMethod("ValidateDomain", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { "", "Caderno espiral com 100 fôlhas", 7.99m, 50, "caderno-1.png" };

            Action action = () =>
            {
                try
                {
                    method.Invoke(product, parameters);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, Name is required");
        }

        [Fact(DisplayName = "ValidateDomain - Product With Invalid Name")]
        public void Product_ValidateProduct_ShouldReturnProductWithShortNameAndExceptionsThrown()
        {
            var product = new Product("Caderno Espiral", "Caderno espiral com 100 fôlhas", 7.99m, 50, "caderno-1.png");

            MethodInfo method = typeof(Product).GetMethod("ValidateDomain", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { "Ca", "Caderno espiral com 100 fôlhas", 7.99m, 50, "caderno-1.png" };

            Action action = () =>
            {
                try
                {
                    method.Invoke(product, parameters);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "ValidateDomain - Product With Null Name")]
        public void Product_ValidateProduct_ValidateProduct_ShouldReturnProductWithNullNameAndExceptionsThrown()
        {
            var product = new Product("Caderno Espiral", "Caderno espiral com 100 fôlhas", 7.99m, 50, "caderno-1.png");

            MethodInfo method = typeof(Product).GetMethod("ValidateDomain", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null, "Caderno espiral com 100 fôlhas", 7.99m, 50, "caderno-1.png" };

            Action action = () =>
            {
                try
                {
                    method.Invoke(product, parameters);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, Name is required");
        }

        [Fact(DisplayName = "ValidateDomain - Product With Empty Description")]
        public void Product_ValidateProduct_ShouldReturnProductWithEmptyDescriptionAndExceptionsThrown()
        {
            var product = new Product("Caderno Espiral", "Caderno espiral com 100 fôlhas", 7.99m, 50, "caderno-1.png");

            MethodInfo method = typeof(Product).GetMethod("ValidateDomain", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { "Caderno Espiral", "", 7.99m, 50, "caderno-1.png" };

            Action action = () =>
            {
                try
                {
                    method.Invoke(product, parameters);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "ValidateDomain - Product With Null Description")]
        public void Product_ValidateProduct_ShouldReturnProductWithNullDescriptionAndExceptionsThrown()
        {
            var product = new Product("Caderno Espiral", "Caderno espiral com 100 fôlhas", 7.99m, 50, "caderno-1.png");

            MethodInfo method = typeof(Product).GetMethod("ValidateDomain", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { "Caderno Espiral", null, 7.99m, 50, "caderno-1.png" };

            Action action = () =>
            {
                try
                {
                    method.Invoke(product, parameters);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "ValidateDomain - Product With Short Description")]
        public void Product_ValidateProduct_ShouldReturnProductWithShortDescriptionAndExceptionsThrown()
        {
            var product = new Product("Caderno Espiral", "Caderno espiral com 100 fôlhas", 7.99m, 50, "caderno-1.png");

            MethodInfo method = typeof(Product).GetMethod("ValidateDomain", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { "Caderno Espiral", "Cade", 7.99m, 50, "caderno-1.png" };

            Action action = () =>
            {
                try
                {
                    method.Invoke(product, parameters);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description, too short, minimum 5 characters");
        }

        [Fact(DisplayName = "ValidateDomain - Product With Invalid Price")]
        public void Product_ValidateProduct_ShouldReturnProductWithNegativePriceAndExceptionsThrown()
        {
            var product = new Product("Caderno Espiral", "Caderno espiral com 100 fôlhas", 7.99m, 50, "caderno-1.png");

            MethodInfo method = typeof(Product).GetMethod("ValidateDomain", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { "Caderno Espiral", "Caderno espiral com 100 fôlhas", -7.99m, 50, "caderno-1.png" };

            Action action = () =>
            {
                try
                {
                    method.Invoke(product, parameters);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "ValidateDomain - Product With Negative Stock")]
        public void Product_ValidateProduct_ShouldReturnProductWithNegativeStockAndExceptionsThrown()
        {
            var product = new Product("Caderno Espiral", "Caderno espiral com 100 fôlhas", 7.99m, 50, "caderno-1.png");

            MethodInfo method = typeof(Product).GetMethod("ValidateDomain", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { "Caderno Espiral", "Caderno espiral com 100 fôlhas", 7.99m, -1, "caderno-1.png" };

            Action action = () =>
            {
                try
                {
                    method.Invoke(product, parameters);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "ValidateDomain - Product With Long Image Name")]
        public void Product_ValidateProduct_ShouldReturnProductWitLongImageNameAndExceptionsThrown()
        {
            var product = new Product("Caderno Espiral", "Caderno espiral com 100 fôlhas", 7.99m, 50, "caderno-1.png");

            MethodInfo method = typeof(Product).GetMethod("ValidateDomain", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { "Caderno Espiral", "Caderno espiral com 100 fôlhas", 7.99m, 50, new string('a', 251) };

            Action action = () =>
            {
                try
                {
                    method.Invoke(product, parameters);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters");
        }
    }
}
