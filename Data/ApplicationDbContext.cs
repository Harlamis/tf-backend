using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Encounter> Encounters { get; set; } = null!;
    public DbSet<CombatMonster> CombatMonsters { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Encounter>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<CombatMonster>(entity =>
        {
            entity.HasOne(m => m.Encounter).WithMany(e => e.Monsters).HasForeignKey(m => m.EncounterId).OnDelete(DeleteBehavior.Cascade);

            entity.Property(m => m.TemplateId)
                .IsRequired()
                .HasMaxLength(50);            
        });
    }
}