using HelpYou.Com.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.SqlClient;

namespace HelpYou.Com.DB.Context
{
    public class HelpYouDbContext : DbContext
    {
        public HelpYouDbContext() { }
        public HelpYouDbContext(DbContextOptions<HelpYouDbContext> option):base(option) { }
        public virtual DbSet<MenuModel> Menu { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuModel>().ToTable("Com_Menu");
            EntityTypeBuilder<MenuModel> entity = modelBuilder.Entity<MenuModel>();
            entity.Property(x => x.Id).UseSqlServerIdentityColumn();
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "127.0.0.1",
                InitialCatalog = "HelpYouDB",
                UserID = "sa",
                Password = "123"
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
