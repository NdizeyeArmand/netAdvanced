using Microsoft.EntityFrameworkCore;
using MyNamespace;
using EF.Models;

namespace App
{
    internal class Program
    {
        private static void Main()
        {
            using (var context = new MyDbContext())
            {

            }
        }
    }

}


namespace MyNamespace
{
    internal class MyDbContext: DbContext
    {
        public DbSet<Klant> Klanten {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=12345678;database=usersdb5;",
                new MySqlServerVersion(new Version(8, 0, 11))
                );
        }
    }
}