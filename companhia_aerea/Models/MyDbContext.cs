using Microsoft.EntityFrameworkCore;

namespace companhia_aerea.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    }
}
