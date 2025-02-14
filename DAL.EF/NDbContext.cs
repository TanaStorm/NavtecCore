﻿using DAL.DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public partial class NDbContext : DbContext
    {
        public NDbContext()
        {

        }
        public NDbContext(DbContextOptions<NDbContext> options)
    : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Roles> Roles { get; set; } 
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        //public virtual DbSet<Cotizaciones> Cotizaciones { get; set; }
        //public virtual DbSet<Gastos> Gastos { get; set; }
        //public virtual DbSet<Proveedores> Proveedores { get; set; }
        //public virtual DbSet<Servicios> Servicios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=NavtecCore;Trusted_Connection=True;"); //OJO Cambiar por el nombre de la base de datos
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__885457EEDC8D8629");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.CorreoCliente)
                    .IsRequired()
                    .HasColumnName("correoCliente")
                    .HasMaxLength(255);

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasColumnName("nombreCliente")
                    .HasMaxLength(255);

                entity.Property(e => e.TelefonoCliente)
                    .IsRequired()
                    .HasColumnName("telefonoCliente")
                    .HasMaxLength(255);
            });

            //modelBuilder.Entity<Cotizaciones>(entity =>
            //{
            //    entity.HasKey(e => e.IdCotizacion)
            //        .HasName("PK__Cotizaci__D931C39B89B8DD60");

            //    entity.Property(e => e.IdCotizacion).HasColumnName("idCotizacion");

            //    entity.Property(e => e.FechaCotizacion)
            //        .HasColumnName("fechaCotizacion")
            //        .HasColumnType("date");

            //    entity.Property(e => e.IdServicio).HasColumnName("idServicio");

            //    entity.Property(e => e.NombreCliente)
            //        .IsRequired()
            //        .HasColumnName("nombreCliente")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.PrecioCotizacion)
            //        .HasColumnName("precioCotizacion")
            //        .HasColumnType("decimal(18, 0)");

            //    entity.HasOne(d => d.IdServicioNavigation)
            //        .WithMany(p => p.Cotizaciones)
            //        .HasForeignKey(d => d.IdServicio)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Cotizacion_Servicio");
            //});

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresas__75D2CED444007347");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.CedulaJuridica)
                    .IsRequired()
                    .HasColumnName("cedulaJuridica")
                    .HasMaxLength(255);

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.NombreEmpresa)
                    .IsRequired()
                    .HasColumnName("nombreEmpresa")
                    .HasMaxLength(255);

                entity.Property(e => e.TelefonoEmpresa)
                    .IsRequired()
                    .HasColumnName("telefonoEmpresa")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Clientes) //Tabla del Foreign Key (Ojo este alias se lee de DAL.DO.Objects la cual fue copiada de API.W Models)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull) //No estoy segura de borrar esto, me parece el constraint --Karen 19/03/2022
                    .HasConstraintName("FK_Empresa_Cliente");
            });

            //modelBuilder.Entity<Gastos>(entity =>
            //{
            //    entity.HasKey(e => e.IdGasto)
            //        .HasName("PK__Gastos__F25CC3211C99B399");

            //    entity.Property(e => e.IdGasto).HasColumnName("idGasto");

            //    entity.Property(e => e.DescripcionGasto)
            //        .IsRequired()
            //        .HasColumnName("descripcionGasto")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.FechaGasto)
            //        .HasColumnName("fechaGasto")
            //        .HasColumnType("date");

            //    entity.Property(e => e.MontoGasto)
            //        .HasColumnName("montoGasto")
            //        .HasColumnType("decimal(18, 0)");
            //});

            //modelBuilder.Entity<Proveedores>(entity =>
            //{
            //    entity.HasKey(e => e.IdProveedor)
            //        .HasName("PK__Proveedo__A3FA8E6BB819187A");

            //    entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

            //    entity.Property(e => e.DescripcionProveedor)
            //        .IsRequired()
            //        .HasColumnName("descripcionProveedor")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.NombreProveedor)
            //        .IsRequired()
            //        .HasColumnName("nombreProveedor")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.TelefonoProveedor)
            //        .IsRequired()
            //        .HasColumnName("telefonoProveedor")
            //        .HasMaxLength(255);
            //});

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol) //No estoy segura si debería comentar esto, es la relación con el FK --Karen 19/03/2022
                    .HasName("PK__Roles__3C872F762314100D");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasColumnName("rol")
                    .HasMaxLength(255);
            });

            //modelBuilder.Entity<Servicios>(entity =>
            //{
            //    entity.HasKey(e => e.IdServicio)
            //        .HasName("PK__Servicio__CEB98119A3D8A7BE");

            //    entity.Property(e => e.IdServicio).HasColumnName("idServicio");

            //    entity.Property(e => e.DescripcionServicio)
            //        .IsRequired()
            //        .HasColumnName("descripcionServicio")
            //        .HasMaxLength(255);
            //});

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A616FBD182");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.ClaveUsuario)
                    .IsRequired()
                    .HasColumnName("claveUsuario")
                    .HasMaxLength(255);

                entity.Property(e => e.CorreoUsuario)
                    .IsRequired()
                    .HasColumnName("correoUsuario")
                    .HasMaxLength(255);

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasColumnName("nombreCompleto")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Roles) //Tabla del Foreign Key (Ojo este alias se lee de DAL.DO.Objects la cual fue copiada de API.W Models)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol);
                    //.OnDelete(DeleteBehavior.ClientSetNull) //En el examen yo no usé esto. --Karen 19/03/2022
                    //.HasConstraintName("FK_Usuario_Rol");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
