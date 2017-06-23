using System;
using System.Threading.Tasks;

namespace ngVega.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}