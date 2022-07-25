using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSample.Data.Repositories
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();
    }
}
