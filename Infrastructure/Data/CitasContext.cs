

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CitasContext : DbContext
    {
        public CitasContext(DbContextOptions<CitasContext> options) : base(options)
        {
        }
    }
}