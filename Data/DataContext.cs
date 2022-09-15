
using Microsoft.EntityFrameworkCore;

namespace APICrudWithEntityFramework.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<SaleItems> SaleItems { get; set; }
    }
}
