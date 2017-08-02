using FromSql.CoreWeb.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FromSql.CoreWeb.DB.Context
{
    public class FromSqlDbContext:DbContext
    {
        public FromSqlDbContext() { }
        public FromSqlDbContext(DbContextOptions<FromSqlDbContext> options) : base(options) { }
        public virtual DbSet<PeopleModel> People { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeopleModel>().ToTable("People");
            EntityTypeBuilder<PeopleModel> entity = modelBuilder.Entity<PeopleModel>();
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).UseSqlServerIdentityColumn();
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "127.0.0.1",
                InitialCatalog = "CoreFromSqlDB",
                UserID="sa",
                Password="jack116"
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
