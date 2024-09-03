﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using crudNet.Models;

#nullable disable

namespace crudNet.Migrations
{
    [DbContext(typeof(ElectionDbContext))]
    partial class ElectionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ElectionResultsApp.Models.CandidateVote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CandidateCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Votes")
                        .HasColumnType("int");

                    b.Property<int>("VotingTableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VotingTableId", "CandidateCode");

                    b.ToTable("CandidateVotes");
                });

            modelBuilder.Entity("crudNet.Models.ElectionResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AE")
                        .HasColumnType("int");

                    b.Property<int>("BERA")
                        .HasColumnType("int");

                    b.Property<int>("CF")
                        .HasColumnType("int");

                    b.Property<string>("Centro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodEdo")
                        .HasColumnType("int");

                    b.Property<int>("CodMun")
                        .HasColumnType("int");

                    b.Property<int>("CodPar")
                        .HasColumnType("int");

                    b.Property<int>("DC")
                        .HasColumnType("int");

                    b.Property<int>("EG")
                        .HasColumnType("int");

                    b.Property<int>("EM")
                        .HasColumnType("int");

                    b.Property<string>("Edo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JABE")
                        .HasColumnType("int");

                    b.Property<int>("JOBR")
                        .HasColumnType("int");

                    b.Property<int>("LM")
                        .HasColumnType("int");

                    b.Property<int>("Mesa")
                        .HasColumnType("int");

                    b.Property<string>("Mun")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NM")
                        .HasColumnType("int");

                    b.Property<string>("Par")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VotosNulos")
                        .HasColumnType("int");

                    b.Property<int>("VotosValidos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ElectionResults");
                });

            modelBuilder.Entity("crudNet.Models.Municipality", b =>
                {
                    b.Property<int>("CodMun")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodMun"));

                    b.Property<int>("CodEdo")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodMun");

                    b.HasIndex("CodEdo", "CodMun");

                    b.ToTable("Municipalities");
                });

            modelBuilder.Entity("crudNet.Models.Parish", b =>
                {
                    b.Property<int>("CodPar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodPar"));

                    b.Property<int>("CodMun")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodPar");

                    b.HasIndex("CodMun", "CodPar");

                    b.ToTable("Parishes");
                });

            modelBuilder.Entity("crudNet.Models.State", b =>
                {
                    b.Property<int>("CodEdo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodEdo"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodEdo");

                    b.HasIndex("CodEdo");

                    b.ToTable("States");
                });

            modelBuilder.Entity("crudNet.Models.VotingCenter", b =>
                {
                    b.Property<string>("CentroCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CodPar")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CentroCode");

                    b.HasIndex("CentroCode");

                    b.HasIndex("CodPar");

                    b.ToTable("VotingCenters");
                });

            modelBuilder.Entity("crudNet.Models.VotingTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CentroCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VotosNulos")
                        .HasColumnType("int");

                    b.Property<int>("VotosValidos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CentroCode");

                    b.ToTable("VotingTables");
                });

            modelBuilder.Entity("ElectionResultsApp.Models.CandidateVote", b =>
                {
                    b.HasOne("crudNet.Models.VotingTable", "VotingTable")
                        .WithMany("CandidateVotes")
                        .HasForeignKey("VotingTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VotingTable");
                });

            modelBuilder.Entity("crudNet.Models.Municipality", b =>
                {
                    b.HasOne("crudNet.Models.State", "State")
                        .WithMany("Municipalities")
                        .HasForeignKey("CodEdo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("crudNet.Models.Parish", b =>
                {
                    b.HasOne("crudNet.Models.Municipality", "Municipality")
                        .WithMany("Parishes")
                        .HasForeignKey("CodMun")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipality");
                });

            modelBuilder.Entity("crudNet.Models.VotingCenter", b =>
                {
                    b.HasOne("crudNet.Models.Parish", "Parish")
                        .WithMany("VotingCenters")
                        .HasForeignKey("CodPar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parish");
                });

            modelBuilder.Entity("crudNet.Models.VotingTable", b =>
                {
                    b.HasOne("crudNet.Models.VotingCenter", "VotingCenter")
                        .WithMany("VotingTables")
                        .HasForeignKey("CentroCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VotingCenter");
                });

            modelBuilder.Entity("crudNet.Models.Municipality", b =>
                {
                    b.Navigation("Parishes");
                });

            modelBuilder.Entity("crudNet.Models.Parish", b =>
                {
                    b.Navigation("VotingCenters");
                });

            modelBuilder.Entity("crudNet.Models.State", b =>
                {
                    b.Navigation("Municipalities");
                });

            modelBuilder.Entity("crudNet.Models.VotingCenter", b =>
                {
                    b.Navigation("VotingTables");
                });

            modelBuilder.Entity("crudNet.Models.VotingTable", b =>
                {
                    b.Navigation("CandidateVotes");
                });
#pragma warning restore 612, 618
        }
    }
}
