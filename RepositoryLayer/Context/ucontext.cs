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
        public DbSet<Collaborate> CollaboratorTable
        {
            get; set;
        }
        public DbSet<Lable> LableTable
        {
            get; set;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collaborate>()
                .HasKey(e => new {e.CollaboratorId});
            modelBuilder.Entity<Collaborate>()
                .HasOne(e => e.Notes)
                .WithMany(e => e.Collaborate)
                .HasForeignKey(e => e.NotesId);
            modelBuilder.Entity<Collaborate>()
                .HasOne(e => e.User)
                .WithMany(e => e.Collaborate)
                .HasForeignKey(e => e.Id);

            modelBuilder.Entity<Lable>()
               .HasKey(e => new { e.LableId });
            modelBuilder.Entity<Lable>()
                .HasOne(e => e.Notes)
                .WithMany(e => e.Lable)
                .HasForeignKey(e => e.NotesId);
            modelBuilder.Entity<Lable>()
                .HasOne(e => e.User)
                .WithMany(e => e.Lable)
                .HasForeignKey(e => e.Id);
        }
    }

}

