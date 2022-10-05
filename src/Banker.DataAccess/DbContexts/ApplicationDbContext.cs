namespace Banker.DataAccess.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<AccountModel> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AccountModel>().HasData(
            new AccountModel()
            {
                Id = 1,
                Name = "Steve Wanderson",
                Email = "steve_wanderson@gmail.com",
                Balance = 955.5m,
                CreatedDate = DateTime.Now,
            },
            new AccountModel()
            {
                Id = 2,
                Name = "Marry Dave",
                Email = "marry-1992@outlook.com",
                Balance = 6584.5m,
                CreatedDate = DateTime.Now,
            }
        );
    }
}