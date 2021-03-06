using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppsBeginner2.Models;

namespace WebAppsBeginner2.Data
{
    public class ApplicationDBContext :DbContext 
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
             

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Expense> Expenses{ get; set; }


    }
}
