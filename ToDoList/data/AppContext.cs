using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<TaskItem> Events { get; set; }
    public DbSet<TaskItem> Team { get; set; }
    public DbSet<TaskItem> User { get; set; }

    public string DbPath { get; }

    public AppContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "local.db");
    }

    // public AppContext(DbContextOptions<AppContext> options) : base(options) { }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);

    //     modelBuilder.Entity<Role>()
    //         .HasOne(r => r.CreateByUser)
    //         .WithMany()
    //         .HasForeignKey(r => r.CreateByUserId)
    //         .OnDelete(DeleteBehavior.Restrict);

    //     modelBuilder.Entity<Role>()
    //         .HasOne(r => r.UpdateByUser)
    //         .WithMany()
    //         .HasForeignKey(r => r.UpdateByUserId)
    //         .OnDelete(DeleteBehavior.Restrict);
    // }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        base.OnConfiguring(options);
        options.UseSqlite($"Data source={DbPath}");
    }
}