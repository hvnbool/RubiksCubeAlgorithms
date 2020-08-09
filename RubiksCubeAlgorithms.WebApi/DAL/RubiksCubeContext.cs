using Microsoft.EntityFrameworkCore;
using RubiksCubeAlgorithmsWebApi.DAL.Entities;

namespace RubiksCubeAlgorithmsWebApi.DAL
{
    public class RubiksCubeContext : DbContext
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="opt">Options for creating the context</param>
        public RubiksCubeContext(DbContextOptions opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Keys

            modelBuilder.Entity<Algorithm>().HasKey(a => a.Id);
            modelBuilder.Entity<Case>().HasKey(c => c.Id);
            modelBuilder.Entity<Step>().HasKey(s => s.Id);
            modelBuilder.Entity<Method>().HasKey(m => m.Id);
            modelBuilder.Entity<CaseAlgorithm>().HasKey(ca => new { ca.CaseId, ca.AlgorithmId });
            modelBuilder.Entity<StepCase>().HasKey(ca => new { ca.StepId, ca.CaseId });
            modelBuilder.Entity<MethodStep>().HasKey(ca => new { ca.MethodId, ca.StepId });

            #endregion

            #region Relationships

            // Case-algorithm many-to-many relationship 
            modelBuilder.Entity<CaseAlgorithm>()
                .HasOne(ca => ca.Case)
                .WithMany(c => c.CaseAlgorithms)
                .HasForeignKey(ca => ca.CaseId);

            modelBuilder.Entity<CaseAlgorithm>()
                .HasOne(ca => ca.Algorithm)
                .WithMany(c => c.CaseAlgorithms)
                .HasForeignKey(ca => ca.AlgorithmId);

            // Step-case many-to-many relationship
            modelBuilder.Entity<StepCase>()
                .HasOne(sc => sc.Step)
                .WithMany(s => s.StepCases)
                .HasForeignKey(sc => sc.StepId);

            modelBuilder.Entity<StepCase>()
                .HasOne(sc => sc.Case)
                .WithMany(s => s.StepCases)
                .HasForeignKey(sc => sc.CaseId);

            // Method-step many-to-many relationship
            modelBuilder.Entity<MethodStep>()
                .HasOne(sc => sc.Method)
                .WithMany(m => m.MethodSteps)
                .HasForeignKey(sc => sc.MethodId);

            modelBuilder.Entity<MethodStep>()
                .HasOne(sc => sc.Step)
                .WithMany(s => s.MethodSteps)
                .HasForeignKey(sc => sc.StepId);

            #endregion
        }

        public DbSet<Algorithm> Algorithms { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Method> Methods { get; set; }
        public DbSet<CaseAlgorithm> CaseAlgorithms { get; set; }
        public DbSet<StepCase> StepCases { get; set; }
        public DbSet<MethodStep> MethodSteps { get; set; }
    }
}
