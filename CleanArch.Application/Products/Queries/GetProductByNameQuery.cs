using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Queries
{
    public class GetProductByNameQuery : IRequest<Product>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public GetProductByNameQuery(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
