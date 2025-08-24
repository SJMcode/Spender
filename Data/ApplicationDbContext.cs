using Microsoft.EntityFrameworkCore;
using Spender.Models;

namespace Spender.Data
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Spender.Models.Expense> Expenses { get; set; }

        // 1. Creata model class
        // 2. Add DB Set in DB Context
        // 3 . add-migration AddExpenseEntryTable
        // 4. update-database
    }
}
