using Microsoft.EntityFrameworkCore;
using calculator_api.Models;

namespace calculator_api.Data
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext(DbContextOptions<CalculatorContext> options)
            : base(options)
        {
        }

        public DbSet<CalculoIR> CalculoIRs { get; set; }
        public DbSet<Contribuinte> Contribuintes { get; set; }
        //public DbSet<Dependente> Dependentes { get; set; }

        //public DbSet<FormulaRL> Formulas { get; set; }

        public DbSet<Aliquota> Aliquotas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

            modelBuilder.Entity<CalculoIR>().ToTable("CalculoIR");
            modelBuilder.Entity<Contribuinte>().ToTable("Contribuinte");

            modelBuilder.Entity<Contribuinte>()
            .HasIndex(c => c.Cpf)
            .IsUnique();

            //modelBuilder.Entity<Dependente>().ToTable("Dependente");
            //modelBuilder.Entity<FormulaRL>().ToTable("FormulaRL");
        }

    }
}