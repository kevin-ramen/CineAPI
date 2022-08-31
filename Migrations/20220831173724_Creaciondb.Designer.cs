﻿// <auto-generated />
using System;
using Cine.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cine.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220831173724_Creaciondb")]
    partial class Creaciondb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cine.Domain.Objects.OActor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaNacimientoA")
                        .HasColumnType("datetime2");

                    b.Property<string>("FotoA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreA")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("TActor");
                });

            modelBuilder.Entity("Cine.Domain.Objects.OGenero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("TGenero");
                });

            modelBuilder.Entity("Cine.Domain.Objects.OPelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Encine")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaEstrenoP")
                        .HasColumnType("datetime2");

                    b.Property<string>("FotoP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreP")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TPelicula");
                });

            modelBuilder.Entity("Cine.Domain.Objects.OReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("OUsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OUsuarioId");

                    b.ToTable("TReview");
                });

            modelBuilder.Entity("Cine.Domain.Objects.OSala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Sala")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TSala");
                });

            modelBuilder.Entity("Cine.Domain.Objects.OUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("TUsuario");
                });

            modelBuilder.Entity("Cine.Domain.ObjectsR.PeliculaActor", b =>
                {
                    b.Property<int>("PeliculaID")
                        .HasColumnType("int");

                    b.Property<int>("ActorID")
                        .HasColumnType("int");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<string>("Personaje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PeliculaID", "ActorID");

                    b.HasIndex("ActorID");

                    b.ToTable("TPeliculaActor");
                });

            modelBuilder.Entity("Cine.Domain.ObjectsR.PeliculaGenero", b =>
                {
                    b.Property<int>("PeliculaID")
                        .HasColumnType("int");

                    b.Property<int>("GeneroID")
                        .HasColumnType("int");

                    b.HasKey("PeliculaID", "GeneroID");

                    b.HasIndex("GeneroID");

                    b.ToTable("TPeliculaGenero");
                });

            modelBuilder.Entity("Cine.Domain.ObjectsR.PeliculaSala", b =>
                {
                    b.Property<int>("PeliculaID")
                        .HasColumnType("int");

                    b.Property<int>("SalaID")
                        .HasColumnType("int");

                    b.HasKey("PeliculaID", "SalaID");

                    b.HasIndex("SalaID");

                    b.ToTable("TPeliculaSala");
                });

            modelBuilder.Entity("Cine.Domain.Objects.OReview", b =>
                {
                    b.HasOne("Cine.Domain.Objects.OUsuario", "OUsuario")
                        .WithMany("ReviewsU")
                        .HasForeignKey("OUsuarioId");

                    b.Navigation("OUsuario");
                });

            modelBuilder.Entity("Cine.Domain.ObjectsR.PeliculaActor", b =>
                {
                    b.HasOne("Cine.Domain.Objects.OActor", "Actor")
                        .WithMany("PeliculaActor")
                        .HasForeignKey("ActorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cine.Domain.Objects.OPelicula", "Pelicula")
                        .WithMany("PeliculaActor")
                        .HasForeignKey("PeliculaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("Cine.Domain.ObjectsR.PeliculaGenero", b =>
                {
                    b.HasOne("Cine.Domain.Objects.OGenero", "Genero")
                        .WithMany("PeliculaGenero")
                        .HasForeignKey("GeneroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cine.Domain.Objects.OPelicula", "Pelicula")
                        .WithMany("PeliculaGenero")
                        .HasForeignKey("PeliculaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("Cine.Domain.ObjectsR.PeliculaSala", b =>
                {
                    b.HasOne("Cine.Domain.Objects.OPelicula", "Pelicula")
                        .WithMany("PeliculaSala")
                        .HasForeignKey("PeliculaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cine.Domain.Objects.OSala", "Sala")
                        .WithMany("PeliculaSala")
                        .HasForeignKey("SalaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pelicula");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("Cine.Domain.Objects.OActor", b =>
                {
                    b.Navigation("PeliculaActor");
                });

            modelBuilder.Entity("Cine.Domain.Objects.OGenero", b =>
                {
                    b.Navigation("PeliculaGenero");
                });

            modelBuilder.Entity("Cine.Domain.Objects.OPelicula", b =>
                {
                    b.Navigation("PeliculaActor");

                    b.Navigation("PeliculaGenero");

                    b.Navigation("PeliculaSala");
                });

            modelBuilder.Entity("Cine.Domain.Objects.OSala", b =>
                {
                    b.Navigation("PeliculaSala");
                });

            modelBuilder.Entity("Cine.Domain.Objects.OUsuario", b =>
                {
                    b.Navigation("ReviewsU");
                });
#pragma warning restore 612, 618
        }
    }
}