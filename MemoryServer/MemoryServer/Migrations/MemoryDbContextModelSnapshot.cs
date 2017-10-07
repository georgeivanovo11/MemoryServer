using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MemoryServer.Persistence;

namespace MemoryServer.Migrations
{
    [DbContext(typeof(MemoryDbContext))]
    partial class MemoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MemoryServer.Models.EngWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PartOfSpeechId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Transcription")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("PartOfSpeechId");

                    b.ToTable("EngWordSet");
                });

            modelBuilder.Entity("MemoryServer.Models.PartOfSpeech", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PartOfSpeechSet");
                });

            modelBuilder.Entity("MemoryServer.Models.RusWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PartOfSpeechId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("PartOfSpeechId");

                    b.ToTable("RusWordSet");
                });

            modelBuilder.Entity("MemoryServer.Models.EngWord", b =>
                {
                    b.HasOne("MemoryServer.Models.PartOfSpeech", "PartOfSpeech")
                        .WithMany("EngWords")
                        .HasForeignKey("PartOfSpeechId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MemoryServer.Models.RusWord", b =>
                {
                    b.HasOne("MemoryServer.Models.PartOfSpeech", "PartOfSpeech")
                        .WithMany("RusWords")
                        .HasForeignKey("PartOfSpeechId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
