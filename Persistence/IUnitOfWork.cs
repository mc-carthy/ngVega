using System;
using System.Threading.Tasks;

namespace ngVega.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}