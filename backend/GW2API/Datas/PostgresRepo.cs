using BaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GW2API.Datas
{
    public class PostgresRepo : IRepo
    {
        private readonly DbContext _context;
        public PostgresRepo(GwDbContext context)
        {
            _context = context;
        }
    }
}
