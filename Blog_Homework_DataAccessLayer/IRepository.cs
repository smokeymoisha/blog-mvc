using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Homework_DataAccessLayer
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Edit(T entity);
        void Delete(int id);
    }
}
