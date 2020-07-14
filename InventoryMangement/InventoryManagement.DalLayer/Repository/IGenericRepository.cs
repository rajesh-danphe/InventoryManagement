using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DalLayer
{
  public interface IGenericRepository<T> where T : class
  {
    Task<IQueryable<T>> GetAll();
    Task<T> GetById(object id);
    Task<IQueryable<T>> GetAllById(object id);
    Task<T> Add(T obj);
    Task<T> Update(T obj);
    Task<T> Delete(T obj);
  }
}
