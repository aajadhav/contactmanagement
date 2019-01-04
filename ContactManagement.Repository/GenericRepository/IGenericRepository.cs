using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ContactManagement.Models.AuditEntries;

namespace ContactManagement.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
    }
}
