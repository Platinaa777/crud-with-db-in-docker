using Microsoft.EntityFrameworkCore;

namespace DockerAPIwithDb;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> o) : base(o)
    {
        
    }
    public DbSet<Car> Cars { get; set; }
}