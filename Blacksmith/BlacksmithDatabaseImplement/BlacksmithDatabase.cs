using BlacksmithDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace BlacksmithDatabaseImplement
{
    public class BlacksmithDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-V0A9OFL\SQLEXPRESS;initial catalog=BlacksmithDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Manufacture> Manufactures { set; get; }
        public virtual DbSet<ManufactureComponent> ManufactureComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
    }
}
