using helpyou.net.cn.DB.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace helpyou.net.cn.DB.Context
{
    public class HelpYouDbContext : DbContext
    {
        public HelpYouDbContext() : base("HelpYouDbContext")
        {
            
        }
        public DbSet<MenuModel> Menu { get; set; }
        public DbSet<CustomModel> Custom { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuModel>().ToTable("Sys_Menu");
            modelBuilder.Entity<CustomModel>().ToTable("User_Custom");
        }
    }
}
