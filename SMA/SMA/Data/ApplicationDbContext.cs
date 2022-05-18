using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using SMA.Models;

namespace SMA.Data {
    
    /// <summary>
    /// Esta classe funciona como base dados do projeto.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        // Definir tabelas para a base de dados.
        public DbSet<Utente> Utentes { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Receita> Receitas { get; set; }

    }
}