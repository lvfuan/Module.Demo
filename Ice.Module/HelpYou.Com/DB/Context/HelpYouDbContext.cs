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
        public virtual DbSet<CustomModel> Custom { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuModel>().ToTable("Com_Menu");
            EntityTypeBuilder<MenuModel> entity1 = modelBuilder.Entity<MenuModel>();
            entity1.Property(x => x.Id).UseSqlServerIdentityColumn();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomModel>().ToTable("User_Custom");
            EntityTypeBuilder<CustomModel> entity2 = modelBuilder.Entity<CustomModel>();
            entity2.Property(x => x.Id).UseSqlServerIdentityColumn();
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "127.0.0.1",
                InitialCatalog = "HelpYouDB",
                UserID = "sa",
                Password = "jack116"
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
