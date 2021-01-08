using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseModels;
using Microsoft.EntityFrameworkCore;

namespace DbFiller.Models
{
    public class PostgresContext : GwDbContext
    {
        public PostgresContext(string connectionString) : base(GetDbContextOptions(connectionString))
        {
        }

        private static DbContextOptions GetDbContextOptions(string connectionString)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseNpgsql(connectionString);
            return builder.Options;
        }
    }
}
