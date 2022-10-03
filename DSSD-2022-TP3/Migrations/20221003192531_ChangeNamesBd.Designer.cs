﻿// <auto-generated />
using DSSD_2022_TP3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DSSD_2022_TP3.Migrations
{
    [DbContext(typeof(AcademicaContext))]
    [Migration("20221003192531_ChangeNamesBd")]
    partial class ChangeNamesBd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DSSD_2022_TP3.Model.Estudiante", b =>
                {
                    b.Property<int>("IdEstudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("apellido");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("celular");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("clave");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("dni");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("mail");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nombre");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("usuario");

                    b.HasKey("IdEstudiante");

                    b.ToTable("estudiantes");
                });
#pragma warning restore 612, 618
        }
    }
}
