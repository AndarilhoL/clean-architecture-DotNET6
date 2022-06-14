using CleanArch.Domain.Validations;

namespace CleanArch.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, name is required !");

            DomainExceptionValidation.When(name.Length < 2,
                "Invalid name, name has minimun 2 characters");

            Name = name;
        }
    }
}
