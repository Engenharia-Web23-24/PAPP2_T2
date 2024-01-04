using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PAP2T2.Models;

namespace PAP2T2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UnidadeCurricular> UnidadesCurriculares { get; set; }

        public DbSet<Inscricao> Inscricoes { get; set; }
    }
}
