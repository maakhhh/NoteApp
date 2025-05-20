using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace Core;

public class NoteAppDbContext : DbContext
{
    private readonly IConfiguration config;
    
    public NoteAppDbContext(IConfiguration config, DbContextOptions<NoteAppDbContext> options) : base(options)
    {
        this.config = config;
        Database.EnsureCreated();
    }
    
    public DbSet<Node> Nodes { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        NoteAppDbContextConfig.ConfigureNode(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_CONNECTION") ?? throw new Exception("Connection string is not defined"));
    }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>()
            .HaveColumnType("timestamp with time zone")
            .HaveConversion<DateTimeKindConverter>();
    }
}