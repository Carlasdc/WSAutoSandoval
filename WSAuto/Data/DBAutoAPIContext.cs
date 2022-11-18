using Microsoft.EntityFrameworkCore;
using WSAuto.Models;
namespace WSAuto.Data
{
    public class DBAutoAPIContext:DbContext
    {
        public DBAutoAPIContext(DbContextOptions<DBAutoAPIContext> options) : base(options) { }

        //DBSET
        public DbSet<Auto> Autos { get; set; }

    }
}
