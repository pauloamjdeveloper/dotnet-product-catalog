using FluentAssertions;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Validation;
using System.Reflection;

namespace ProductCatalog.Domain.Tests.Entities
{
    public class CategoryValidateDomainTest
    {
        [Fact(DisplayName = "ValidateDomain - Category With Valid Domain")]
        public void Category_ValidateDomain_ShouldReturnCategoryWithValidParameterAndNotThrowException()
        {
            string name = "Material Escolar";
            var category = new Category(name);

            MethodInfo method = typeof(Category).GetMethod("ValidateDomain", BindingFlags.NonPublic | BindingFlags.Instance);
            Action action = () =>
            {
                method.Invoke(category, new object[] { name });
            };

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "ValidateDomain - Category With Empty Name")]
        public void Category_ValidateDomain_ShouldReturnCategoryWithEmptyNameAndExceptionsThrown()
        {
            var category = new Category("Material Escolar");

            MethodInfo method = typeof(Category).GetMethod("ValidateDomain", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { "" };

            Action action = () =>
            {
                try
                {
                    method.Invoke(category, parameters);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            };

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, Name is required");
        }

        [Fact(DisplayName = "ValidateDomain - Category With Invalid Name")]
        public void Category_ValidateDomain_ShouldReturnCategoryWithShortNameAndThrowException()
        {
            var category = new Category("Material Escolar");

            MethodInfo method = typeof(Category).GetMethod("ValidateDomain", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { "Ma" };

            Action action = () =>
            {
                try
                {
                    method.Invoke(category, parameters);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            };

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "ValidateDomain - Category With Null Name")]
        public void Category_ValidateDomain_ShouldReturnCategoryWithNullNameAndThrowException()
        {
            var category = new Category("Material Escolar");

            MethodInfo method = typeof(Category).GetMethod("ValidateDomain", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { null };

            Action action = () =>
            {
                try
                {
                    method.Invoke(category, parameters);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            };

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, Name is required");
        }
    }
}
