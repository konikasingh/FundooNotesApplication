using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Context
{
    public class ucontext : DbContext
    {
        public ucontext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> UserTable
        {
            get; set;
        }
         public DbSet<Notes> NotesTable
        {
            get; set;
        }
    }

}

