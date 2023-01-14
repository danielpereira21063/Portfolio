using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Identity;

namespace Portfolio.Infra.Data.Context
{
    public class PortfolioContext : IdentityDbContext<User, Role, int>
    {
        public PortfolioContext() { }

        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options) { }


        public DbSet<DadosPortfolio> DadosPortfolios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<ImagemProjeto> ImagensProjeto { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortfolioContext).Assembly);
        }
    }
}
