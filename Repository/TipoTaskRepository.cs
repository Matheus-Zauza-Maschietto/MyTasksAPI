using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTasksAPI.Context;
using MyTasksAPI.Models;

namespace MyTasksAPI.Repository
{
    public class TipoTaskRepository
    {
        private readonly MyTaskContext _context;
        public TipoTaskRepository(MyTaskContext context)
        {
            _context = context;
        }

    }
}