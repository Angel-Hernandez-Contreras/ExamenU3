﻿// <auto-generated />
using ExamenU3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ExamenU3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211124211035_FechaTipoString")]
    partial class FechaTipoString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ExamenU3.Models.Fichas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Puntos")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Fichas");
                });

            modelBuilder.Entity("ExamenU3.Models.Historial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Fecha")
                        .HasColumnType("text");

                    b.Property<int>("Puntos")
                        .HasColumnType("integer");

                    b.Property<string>("Resultado")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Historial");
                });
#pragma warning restore 612, 618
        }
    }
}
