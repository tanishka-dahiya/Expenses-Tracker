using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Contexts
{
    public class ExpensesContext : DbContext
    {
        public ExpensesContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}
