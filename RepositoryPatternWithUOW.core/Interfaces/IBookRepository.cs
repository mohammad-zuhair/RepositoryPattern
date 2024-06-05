using RepositoryPatternWithUOW.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.core.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        IEnumerable<Book> SpecialMethod();
    }
}
