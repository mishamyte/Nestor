﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nestor.Data.Ef;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Nestor.Data.Ef.Migrations
{
    [DbContext(typeof(NestorContext))]
    [Migration("20191105203522_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("nestor")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Nestor.Data.Nest", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("HashtagName")
                        .HasColumnType("text");

                    b.Property<bool>("IsRecommended")
                        .HasColumnType("boolean");

                    b.Property<int>("LastMigration")
                        .HasColumnType("integer");

                    b.Property<double>("Lat")
                        .HasColumnType("double precision");

                    b.Property<double>("Lng")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("NestType")
                        .HasColumnType("integer");

                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Nest");
                });

            modelBuilder.Entity("Nestor.Data.NestUpdate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("MigrationNumber")
                        .HasColumnType("integer");

                    b.Property<int>("NestId")
                        .HasColumnType("integer");

                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("NestUpdate");
                });

            modelBuilder.Entity("Nestor.Data.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pokemon");
                });

            modelBuilder.Entity("Nestor.Data.Nest", b =>
                {
                    b.HasOne("Nestor.Data.Pokemon", "Pokemon")
                        .WithMany("Nests")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nestor.Data.NestUpdate", b =>
                {
                    b.HasOne("Nestor.Data.Nest", "Nest")
                        .WithMany("NestUpdates")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nestor.Data.Pokemon", "Pokemon")
                        .WithMany("NestUpdates")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}