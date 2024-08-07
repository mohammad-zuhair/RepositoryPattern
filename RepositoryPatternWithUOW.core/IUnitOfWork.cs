﻿using RepositoryPatternWithUOW.core.Interfaces;
using RepositoryPatternWithUOW.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Author> Authors { get; }
        //IBaseRepository<Book> Books{ get; }
        IBookRepository Books { get; }
        int Complete();

    }

}
