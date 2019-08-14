using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public interface IEnqueueable<T>
    {
        Task<bool> EnqueueAsync(T obj);
    }
}
