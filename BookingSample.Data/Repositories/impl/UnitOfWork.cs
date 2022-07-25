using BookingSample.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSample.Data.Repositories.impl
{
    public class UnitOfWork : IUnitOfWork
    {
        public BookingSampleContext _context { get; set; }

        public UnitOfWork(BookingSampleContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
