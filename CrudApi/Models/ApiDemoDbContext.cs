using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace CrudApi.Models
{
    public class ApiDemoDbContext : DbContext
    {
        public ApiDemoDbContext(DbContextOptions<ApiDemoDbContext> options) : base(options)
        {


        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
       new User () { UserId=1 , EmailAddress="sayed" , FirstName="sd" , LastName="sd" }
           
            );
        }

    }
}
