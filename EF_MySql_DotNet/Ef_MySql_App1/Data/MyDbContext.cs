using Microsoft.EntityFrameworkCore;

namespace Ef_MySql_App1.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        
    }
}