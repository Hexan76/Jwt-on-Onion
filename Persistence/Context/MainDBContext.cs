using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

public class MainDBContext : DbContext
{
#nullable disable
    private readonly IConfiguration _configuration;
    public MainDBContext(DbContextOptions<MainDBContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Debugger.Launch();
        string _connectionstring = _configuration.GetConnectionString("ApiCon");
        optionsBuilder.UseSqlServer(_connectionstring, o => o.MigrationsAssembly("Api"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Debugger.Launch();
        modelBuilder.ApplyConfiguration(new UserConfig());
        modelBuilder.ApplyConfiguration(new RoleConfig());
        modelBuilder.ApplyConfiguration(new UserClaimConfig());
        modelBuilder.ApplyConfiguration(new RoleClaimConfig());
        modelBuilder.ApplyConfiguration(new UserTokenConfig());
    }

    //entities
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserClaim> UserClaims { get; set; }
    public DbSet<RoleClaim> RoleClaims { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }

}
