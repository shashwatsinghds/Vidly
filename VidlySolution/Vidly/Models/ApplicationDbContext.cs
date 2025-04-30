using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Vidly.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
    }

   
    }





