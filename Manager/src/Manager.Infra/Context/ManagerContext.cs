using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra;

public partial class ManagerContext : DbContext
{
    public ManagerContext()
    {
    }

    public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user id=informatica;password=Lab@inf019;database=UserManagerAPI",
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserMap());
    }
}
