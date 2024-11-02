using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Domain.Interfaces
{
    public interface IRepositoryBase<T>//where T : class arvici rashi gvchirdeba mara sachiroa
    {
        T Get(params object[] par);
        void Save(T item);
        void Delete(T item);
        void Detete(params object[] key);
    }
}
