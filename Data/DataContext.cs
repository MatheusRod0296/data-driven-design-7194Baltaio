using Microsoft.EntityFrameworkCore;
using shop.Models;

namespace shop.Data
{
    public class DataContext : DbContext
    {
        //  docker create container -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=1q2w3e4r!@#$'  -p 1433: 1433 --name sql1 -v $(pwd):/var/opt/mssql -d mcr.microsoft.com/mssql/server: 2019-CU3-ubuntu-18.04

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}