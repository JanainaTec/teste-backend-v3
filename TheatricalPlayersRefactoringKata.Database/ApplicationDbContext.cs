using Microsoft.EntityFrameworkCore;
using TheatricalPlayersRefactoringKata.Database.Models;

namespace TheatricalPlayersRefactoringKata.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<StatementModel> Statements { set; get; }

        public DbSet<PlayModel> Plays { set; get; }

        public DbSet<StatementItensModel> StatementItens { set; get; }
    }
}
