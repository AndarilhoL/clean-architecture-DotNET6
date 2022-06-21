using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public long Id { get; set; }
        public ProductRemoveCommand(long id)
        {
            Id = id;
        }
    }
}
