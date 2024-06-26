﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tareas.API.Data;

#nullable disable

namespace Tareas.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tareas.Shared.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cancelo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Departamentos", (string)null);
                });

            modelBuilder.Entity("Tareas.Shared.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cancelo")
                        .HasColumnType("int");

                    b.Property<string>("CveEmpleado")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Empleados", (string)null);
                });

            modelBuilder.Entity("Tareas.Shared.Models.Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cancelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("CveEquipo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("RubroId")
                        .HasColumnType("int");

                    b.Property<int>("UnidadNegocioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RubroId");

                    b.HasIndex("UnidadNegocioId");

                    b.ToTable("Equipos", (string)null);
                });

            modelBuilder.Entity("Tareas.Shared.Models.Rubro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte>("Cancelo")
                        .HasColumnType("tinyint");

                    b.Property<long>("Folio")
                        .HasColumnType("bigint");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Rubros", (string)null);
                });

            modelBuilder.Entity("Tareas.Shared.Models.RubroEncargados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CveEmpleado")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<bool>("EsJefe")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("RubroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("RubroId");

                    b.ToTable("RubrosEncargados", (string)null);
                });

            modelBuilder.Entity("Tareas.Shared.Models.UnidadNegocio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cancelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("UnidadesNegocio", (string)null);
                });

            modelBuilder.Entity("Tareas.Shared.Models.Empleado", b =>
                {
                    b.HasOne("Tareas.Shared.Models.Departamento", "Departamento")
                        .WithMany("Empleados")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Tareas.Shared.Models.Equipo", b =>
                {
                    b.HasOne("Tareas.Shared.Models.Rubro", "Rubro")
                        .WithMany("Equipos")
                        .HasForeignKey("RubroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tareas.Shared.Models.UnidadNegocio", "UnidadNegocio")
                        .WithMany("Equipos")
                        .HasForeignKey("UnidadNegocioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rubro");

                    b.Navigation("UnidadNegocio");
                });

            modelBuilder.Entity("Tareas.Shared.Models.RubroEncargados", b =>
                {
                    b.HasOne("Tareas.Shared.Models.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tareas.Shared.Models.Rubro", "Rubro")
                        .WithMany("Encargados")
                        .HasForeignKey("RubroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("Rubro");
                });

            modelBuilder.Entity("Tareas.Shared.Models.Departamento", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Tareas.Shared.Models.Rubro", b =>
                {
                    b.Navigation("Encargados");

                    b.Navigation("Equipos");
                });

            modelBuilder.Entity("Tareas.Shared.Models.UnidadNegocio", b =>
                {
                    b.Navigation("Equipos");
                });
#pragma warning restore 612, 618
        }
    }
}
