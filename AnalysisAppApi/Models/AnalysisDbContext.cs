using Microsoft.EntityFrameworkCore;

namespace AnalysisAppApi.Models
{
    public class AnalysisDbContext : DbContext
    {
        public AnalysisDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Analysis> Analysis { get; set; }
        public DbSet<AnalysisQuestion> AnalysisQuestion { get; set; }
        public DbSet<AnalysisAnswer> AnalysisAnswer { get; set; }
        public DbSet<AnalysisError> AnalysisError { get; set; }
        public DbSet<AnalysisProblem> AnalysisProblem { get; set; }
        public DbSet<AnalysisCompensator> AnalysisCompensator { get; set; }
        public DbSet<AnalysisFeedback> AnalysisFeedback { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Article> Article { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Analysis>().ToTable("Tbl_Analysis");
            modelBuilder.Entity<AnalysisQuestion>().ToTable("Tbl_AnalysisQuestion");
            modelBuilder.Entity<AnalysisAnswer>().ToTable("Tbl_AnalysisAnswer");
            modelBuilder.Entity<AnalysisError>().ToTable("Tbl_AnalysisError");
            modelBuilder.Entity<AnalysisError>().ToTable("Tbl_AnalysisProblem");
            modelBuilder.Entity<AnalysisCompensator>().ToTable("Tbl_AnalysisCompensator");
            modelBuilder.Entity<AnalysisFeedback>().ToTable("Tbl_AnalysisFeedback");
            modelBuilder.Entity<Account>().ToTable("Tbl_Accounts");
            modelBuilder.Entity<Article>().ToTable("Tbl_Article");
        }
    }
}
