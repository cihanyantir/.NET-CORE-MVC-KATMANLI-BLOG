﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity_Framework
{
    class EfWriterRepository : GenericRepository<Writer>, IWriterDal
    {
    }
}