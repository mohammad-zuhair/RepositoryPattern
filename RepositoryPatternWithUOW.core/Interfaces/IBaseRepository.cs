using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternWithUOW.core.Consts;

namespace RepositoryPatternWithUOW.core.Interfaces
{
    public  interface IBaseRepository <T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);

        IEnumerable<T> GetAll();


        T Find(Expression<Func<T, bool>> criteria ,string[] includes); 
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria ,string[] includes);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take ,int skip);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip,
            Expression<Func<T ,object>> orderBy =null ,string orderByDirection = OrderBy.Ascinding);

        T Add(T entity);
        IEnumerable <T> AddRange(IEnumerable<T>  entities);

        T Update (T entity);
        void Delete (T entity);
        void DeleteRange (IEnumerable<T> entities);
        void Attachment (T entity);

        int Count();
        int Count(Expression<Func<T, bool>> criteria);


    }
}
