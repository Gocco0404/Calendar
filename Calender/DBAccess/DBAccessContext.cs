using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Calender.DBAccess
{
    public class DBAccessContext : DbContext
    {
        public DBAccessContext(DbContextOptions<DBAccessContext> options)
           : base(options)
        { 
        }

        public DbSet<Calender.Models.TaskInfo> DBAccess { get; set; }
    }
}
