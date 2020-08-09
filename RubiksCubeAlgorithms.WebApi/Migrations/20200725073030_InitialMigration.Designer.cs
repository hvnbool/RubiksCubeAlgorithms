﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RubiksCubeAlgorithmsWebApi.DAL;

namespace RubiksCubeAlgorithmsWebApi.Migrations
{
    [DbContext(typeof(RubiksCubeContext))]
    [Migration("20200725073030_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RubiksCubeAlgorithmsWebApi.DAL.Entities.Algorithm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Moves")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Algorithms");
                });

            modelBuilder.Entity("RubiksCubeAlgorithmsWebApi.DAL.Entities.Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("RubiksCubeAlgorithmsWebApi.DAL.Entities.CaseAlgorithm", b =>
                {
                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<int>("AlgorithmId")
                        .HasColumnType("int");

                    b.HasKey("CaseId", "AlgorithmId");

                    b.HasIndex("AlgorithmId");

                    b.ToTable("CaseAlgorithms");
                });

            modelBuilder.Entity("RubiksCubeAlgorithmsWebApi.DAL.Entities.Method", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Methods");
                });

            modelBuilder.Entity("RubiksCubeAlgorithmsWebApi.DAL.Entities.MethodStep", b =>
                {
                    b.Property<int>("MethodId")
                        .HasColumnType("int");

                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.HasKey("MethodId", "StepId");

                    b.HasIndex("StepId");

                    b.ToTable("MethodSteps");
                });

            modelBuilder.Entity("RubiksCubeAlgorithmsWebApi.DAL.Entities.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("RubiksCubeAlgorithmsWebApi.DAL.Entities.StepCase", b =>
                {
                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.HasKey("StepId", "CaseId");

                    b.HasIndex("CaseId");

                    b.ToTable("StepCases");
                });

            modelBuilder.Entity("RubiksCubeAlgorithmsWebApi.DAL.Entities.CaseAlgorithm", b =>
                {
                    b.HasOne("RubiksCubeAlgorithmsWebApi.DAL.Entities.Algorithm", "Algorithm")
                        .WithMany("CaseAlgorithms")
                        .HasForeignKey("AlgorithmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RubiksCubeAlgorithmsWebApi.DAL.Entities.Case", "Case")
                        .WithMany("CaseAlgorithms")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RubiksCubeAlgorithmsWebApi.DAL.Entities.MethodStep", b =>
                {
                    b.HasOne("RubiksCubeAlgorithmsWebApi.DAL.Entities.Method", "Method")
                        .WithMany("MethodSteps")
                        .HasForeignKey("MethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RubiksCubeAlgorithmsWebApi.DAL.Entities.Step", "Step")
                        .WithMany("MethodSteps")
                        .HasForeignKey("StepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RubiksCubeAlgorithmsWebApi.DAL.Entities.StepCase", b =>
                {
                    b.HasOne("RubiksCubeAlgorithmsWebApi.DAL.Entities.Case", "Case")
                        .WithMany("StepCases")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RubiksCubeAlgorithmsWebApi.DAL.Entities.Step", "Step")
                        .WithMany("StepCases")
                        .HasForeignKey("StepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}