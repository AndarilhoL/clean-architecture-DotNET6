using CleanArch.Domain.Entities;
using FluentAssertions;

namespace CleanArch.Tests
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name ");
            action.Should()
                 .NotThrow<CleanArch.Domain.Validations.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name ");
            action.Should()
                .Throw<CleanArch.Domain.Validations.DomainExceptionValidation>()
                 .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "C");
            action.Should()
                .Throw<CleanArch.Domain.Validations.DomainExceptionValidation>()
                   .WithMessage("Invalid name, name has minimun 2 characters");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArch.Domain.Validations.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required !");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArch.Domain.Validations.DomainExceptionValidation>();
        }
    }
}