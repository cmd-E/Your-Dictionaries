﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YourDictionaries.EntityFramework;

namespace YourDictionaries.EntityFramework.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YourDictionaries.Domain.Models.Dictionary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dictionaries");
                });

            modelBuilder.Entity("YourDictionaries.Domain.Models.Phrase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AssignedDictionaryId")
                        .HasColumnType("int");

                    b.Property<string>("Expression")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Meaning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transcription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Translation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssignedDictionaryId");

                    b.ToTable("Phrases");
                });

            modelBuilder.Entity("YourDictionaries.Domain.Models.Phrase", b =>
                {
                    b.HasOne("YourDictionaries.Domain.Models.Dictionary", "AssignedDictionary")
                        .WithMany("Phrases")
                        .HasForeignKey("AssignedDictionaryId");
                });
#pragma warning restore 612, 618
        }
    }
}
