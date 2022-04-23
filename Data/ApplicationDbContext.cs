using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Editorial> Editorial { get; set; }
        public DbSet<Bibliography> Bibliography { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Science> Science { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Employee> Employee { get; set; }   
        public DbSet<TypePerson> TypePerson { get; set; }
        public DbSet<LoanAndRepayment> LoanAndRepayment { get; set; }
        public DbSet<Schedule> Schedule { get; set; }

    }
}
