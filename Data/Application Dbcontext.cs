using Microsoft.EntityFrameworkCore;
using collegemainatanceportal.Models;


namespace collegemainatanceportal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
