﻿using BookManagement.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DataAccess.ServiceInterface
{
    public interface IBookRepository
    {
        bool Add(BookEntity entity);
    }
}
