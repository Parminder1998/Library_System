using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Library_System.Models;

namespace Library_System.Models
{
    //Uses to connect the model objects  to database via Entity framework.
    public class Library_SystemDatabaseContext : DbContext
    {
        public Library_SystemDatabaseContext (DbContextOptions<Library_SystemDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Library_System.Models.Book> Book { get; set; }

        public DbSet<Library_System.Models.Member> Member { get; set; }

        public DbSet<Library_System.Models.LendingRecord> LendingRecord { get; set; }
    }
}
