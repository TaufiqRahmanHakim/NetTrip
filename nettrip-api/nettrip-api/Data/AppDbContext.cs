using Microsoft.EntityFrameworkCore;
using nettrip_api.Model;

namespace nettrip_api.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            
        }
        public DbSet<User> users { get; set; }
    }
}
