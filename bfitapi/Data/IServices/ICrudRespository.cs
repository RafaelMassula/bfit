using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Data.IServices
{
    public interface ICrudRespository<T> where T : class
    {
        Task<T> Create(T obj);
        Task<T> Delete(int key);
        Task<T> Get(int key);
        Task<IEnumerable<T>> GetList();
        Task<T> Update(T obj);
    }
}
