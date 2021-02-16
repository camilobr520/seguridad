using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebaCamiloBautista.Datos
{
    public partial class DigitalWareContext : DbContext
    {
        public DigitalWareContext()
        {
        }

        public DigitalWareContext(DbContextOptions<DigitalWareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aeronave> Aeronaves { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Pasajero> Pasajeros { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vuelo> Vuelos { get; set; }
        public virtual DbSet<VueloUsuario> VueloUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-PCAJPIH\\SQLEXPRESS01;DataBase=DigitalWare;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Aeronave>(entity =>
            {
                entity.ToTable("aeronave");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Capacidad).HasColumnName("capacidad");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("marca");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("modelo");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("estado");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.NombreEstado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre_estado");
            });

            modelBuilder.Entity<Pasajero>(entity =>
            {
                entity.ToTable("pasajeros");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("apellidos");

                entity.Property(e => e.IdSexo).HasColumnName("id_sexo");

                entity.Property(e => e.IdVuelo).HasColumnName("id_vuelo");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombres");

                entity.HasOne(d => d.IdVueloNavigation)
                    .WithMany(p => p.Pasajeros)
                    .HasForeignKey(d => d.IdVuelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pasajeros_vuelo");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NombreRoll)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre_roll");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.IdRoll).HasColumnName("id_roll");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Vuelo>(entity =>
            {
                entity.ToTable("vuelo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Destino)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("destino");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaLlegada)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_llegada");

                entity.Property(e => e.FechaSalida)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_salida");

                entity.Property(e => e.IdAeronave).HasColumnName("id_aeronave");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdAeronaveNavigation)
                    .WithMany(p => p.Vuelos)
                    .HasForeignKey(d => d.IdAeronave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vuelo_aeronave");
            });

            modelBuilder.Entity<VueloUsuario>(entity =>
            {
                entity.ToTable("vuelo_usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IdVuelo).HasColumnName("id_vuelo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.VueloUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vuelo_usuario_usuario");

                entity.HasOne(d => d.IdVueloNavigation)
                    .WithMany(p => p.VueloUsuarios)
                    .HasForeignKey(d => d.IdVuelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vuelo_usuario_vuelo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
