using Application.Repositories;
using Domain.Entites.Concrete;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductWriteRepository : WriteRepositoryBase<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
