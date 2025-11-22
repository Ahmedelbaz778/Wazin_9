using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace wAzin.Models.Data
{
    public class _DbcontextFactory : IDesignTimeDbContextFactory<_Dbcontext>
    {
        public _Dbcontext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<_Dbcontext>();
            optionsBuilder.UseSqlServer("Server=AHMEDELBAZ_77;Database=wAzinDB;Trusted_Connection=True;Encrypt=False;Trust Server Certificate=True");

            return new _Dbcontext(optionsBuilder.Options);
        }
    }
}
