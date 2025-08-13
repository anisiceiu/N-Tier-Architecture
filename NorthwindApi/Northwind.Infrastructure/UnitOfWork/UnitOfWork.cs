using Northwind.Domain.Entities;
using Northwind.Domain.Interfaces;
using Northwind.Infrastructure.Data;
using Northwind.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindContext _context;
        private GenericRepository<Category> _categories;

        public UnitOfWork(NorthwindContext context)
        {
            _context = context;
        }

        public IGenericRepository<Category> Categories => _categories ??= new GenericRepository<Category>(_context);

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
