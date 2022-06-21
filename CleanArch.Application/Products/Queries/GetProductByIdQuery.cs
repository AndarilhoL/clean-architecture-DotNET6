using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public long Id { get; set; }
        public GetProductByIdQuery(long id)
        {
            Id = id;
        }
    }
}
