using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Encounter> Encounters { get; set; } = null!;
    public DbSet<CombatMonster> CombatMonsters { get; set; } = null!;

    public DbSet<MonsterTemplate> Templates { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Encounter>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<MonsterTemplate>().HasData(
        new MonsterTemplate
        {
            Id = "mudcrab-001",
            BaseName = "Mudcrab",
            MaxHp = 7,
            Ac = 12,
            DetailsJson = """
            {
              "level": 1,
              "traits": ["Beast", "Aquatic"],
              "speed": {
                "walking": 20,
                "flying": 0,
                "swimming": 20,
                "burrowing": 10,
                "climbing": 0
              },
              "savingThrows": {
                "fortitude": 6,
                "reflex": 4,
                "will": 2
              },
              "attacks": [
                { "name": "Pincer", "type": "melee", "bonus": 6, "traits": ["agile", "finesse"] }
              ],
              "loot": [
                { "item": "Mudcrab Chitin", "quantity": 1 }
              ]
            }
            """
        },
        new MonsterTemplate
        {
            Id = "draugr-001",
            BaseName = "Draugr Deathlord",
            MaxHp = 85,
            Ac = 15,
            DetailsJson = """
            {
              "level": 5,
              "traits": ["Undead", "Mindless"],
              "speed": {
                "walking": 25,
                "flying": 0,
                "swimming": 0,
                "burrowing": 0,
                "climbing": 0
              },
              "savingThrows": {
                "fortitude": 12,
                "reflex": 8,
                "will": 10
              },
              "attacks": [
                { "name": "Ebony Greatsword", "type": "melee", "bonus": 14, "traits": ["reach", "sweep"] }
              ],
              "loot": [
                { "item": "Bone Meal", "quantity": 2 },
                { "item": "Ebony Greatsword", "quantity": 1 }
              ]
            }
            """
        },
        new MonsterTemplate
        {
            Id = "dragon-001",
            BaseName = "Ancient Dragon",
            MaxHp = 250,
            Ac = 19,
            DetailsJson = """
            {
              "level": 12,
              "traits": ["Dragon", "Fire"],
              "speed": {
                "walking": 30,
                "flying": 100,
                "swimming": 0,
                "burrowing": 0,
                "climbing": 0
              },
              "savingThrows": {
                "fortitude": 24,
                "reflex": 20,
                "will": 22
              },
              "attacks": [
                { "name": "Bite", "type": "melee", "bonus": 26, "traits": ["reach"] },
                { "name": "Fire Breath", "type": "ranged", "bonus": 20, "traits": ["magical", "fire"] }
              ],
              "loot": [
                { "item": "Dragon Scales", "quantity": 5 },
                { "item": "Dragon Bone", "quantity": 3 }
              ]
            }
            """
        }
    );

        modelBuilder.Entity<CombatMonster>(entity =>
        {
            entity.HasOne(m => m.Encounter).WithMany(e => e.Monsters).HasForeignKey(m => m.EncounterId).OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(m => m.Template).WithMany().HasForeignKey(m => m.TemplateId).OnDelete(DeleteBehavior.Restrict);

            entity.Property(m => m.TemplateId)
                .IsRequired()
                .HasMaxLength(50);
        });
    }
}