using Dogs.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dogs.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // default constructor for the database
        }

        public DbSet<Dog> Dogs { get; set; }
    }
}
