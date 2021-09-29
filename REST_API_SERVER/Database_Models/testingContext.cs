using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class TestingContext : DbContext
    {
        public TestingContext()
        {
        }

        public TestingContext(DbContextOptions<TestingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<Classification> Classifications { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientInvoice> ClientInvoices { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieClassification> MovieClassifications { get; set; }
        public virtual DbSet<Projection> Projections { get; set; }
        public virtual DbSet<ProjectionClient> ProjectionClients { get; set; }
        public virtual DbSet<ProjectionInvoice> ProjectionInvoices { get; set; }
        public virtual DbSet<ProjectionRoom> ProjectionRooms { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=6200;Database=testing;Username=admin;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Spanish_Costa Rica.1252");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => new { e.FirstName, e.MiddleName, e.LastName, e.SecondLastName })
                    .HasName("actor_pkey");

                entity.ToTable("actor");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .HasColumnName("first_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(15)
                    .HasColumnName("middle_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(15)
                    .HasColumnName("last_name");

                entity.Property(e => e.SecondLastName)
                    .HasMaxLength(15)
                    .HasColumnName("second_last_name");

                entity.Property(e => e.MovieName)
                    .HasMaxLength(15)
                    .HasColumnName("movie_name");

                entity.HasOne(d => d.MovieNameNavigation)
                    .WithMany(p => p.Actors)
                    .HasForeignKey(d => d.MovieName)
                    .HasConstraintName("actor_movie");
            });

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("cinema_pkey");

                entity.ToTable("cinema");

                entity.Property(e => e.Name)
                    .HasMaxLength(15)
                    .HasColumnName("name");

                entity.Property(e => e.Location)
                    .HasMaxLength(31)
                    .HasColumnName("location");

                entity.Property(e => e.NumberOfRooms).HasColumnName("number_of_rooms");
            });

            modelBuilder.Entity<Classification>(entity =>
            {
                entity.ToTable("classification");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Final).HasColumnName("final");

                entity.Property(e => e.Initial).HasColumnName("initial");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => new { e.IdCard, e.Username })
                    .HasName("client_pkey");

                entity.ToTable("client");

                entity.Property(e => e.IdCard).HasColumnName("id_card");

                entity.Property(e => e.Username)
                    .HasMaxLength(15)
                    .HasColumnName("username");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(15)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(15)
                    .HasColumnName("middle_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNum).HasColumnName("phone_num");

                entity.Property(e => e.SecondLastName)
                    .HasMaxLength(15)
                    .HasColumnName("second_last_name");
            });

            modelBuilder.Entity<ClientInvoice>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.InvoiceId, e.ClientUsername })
                    .HasName("client_invoice_pkey");

                entity.ToTable("client_invoice");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.ClientUsername)
                    .HasMaxLength(15)
                    .HasColumnName("client_username");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.ClientInvoices)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ci_invoice");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientInvoices)
                    .HasForeignKey(d => new { d.ClientId, d.ClientUsername })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ci_client");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(e => new { e.FirstName, e.MiddleName, e.LastName, e.SecondLastName })
                    .HasName("director_pkey");

                entity.ToTable("director");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .HasColumnName("first_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(15)
                    .HasColumnName("middle_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(15)
                    .HasColumnName("last_name");

                entity.Property(e => e.SecondLastName)
                    .HasMaxLength(15)
                    .HasColumnName("second_last_name");

                entity.Property(e => e.MovieName)
                    .HasMaxLength(31)
                    .HasColumnName("movie_name");

                entity.HasOne(d => d.MovieNameNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.MovieName)
                    .HasConstraintName("director_movie");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => new { e.IdCard, e.Username })
                    .HasName("employee_pkey");

                entity.ToTable("employee");

                entity.Property(e => e.IdCard).HasColumnName("id_card");

                entity.Property(e => e.Username)
                    .HasMaxLength(15)
                    .HasColumnName("username");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.CinemaName)
                    .HasMaxLength(25)
                    .HasColumnName("cinema_name");

                entity.Property(e => e.FirstDateWorking)
                    .HasColumnType("date")
                    .HasColumnName("first_date_working");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(15)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(15)
                    .HasColumnName("middle_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNum).HasColumnName("phone_num");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.SecondLastName)
                    .HasMaxLength(15)
                    .HasColumnName("second_last_name");

                entity.HasOne(d => d.CinemaNameNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CinemaName)
                    .HasConstraintName("employee_cinema");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("employee_role");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.TicketNumber).HasColumnName("ticket_number");

                entity.Property(e => e.Total)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("total");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.OriginalName)
                    .HasName("movie_pkey");

                entity.ToTable("movie");

                entity.Property(e => e.OriginalName)
                    .HasMaxLength(31)
                    .HasColumnName("original_name");

                entity.Property(e => e.AdultPrice).HasColumnName("adult_price");

                entity.Property(e => e.ElderPrice).HasColumnName("elder_price");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.KidPrice).HasColumnName("kid_price");

                entity.Property(e => e.Name)
                    .HasMaxLength(31)
                    .HasColumnName("name");

                entity.Property(e => e.TimeLength).HasColumnName("time_length");
            });

            modelBuilder.Entity<MovieClassification>(entity =>
            {
                entity.HasKey(e => new { e.MovieOriginalName, e.ClassificationId })
                    .HasName("movie_classification_pkey");

                entity.ToTable("movie_classification");

                entity.Property(e => e.MovieOriginalName)
                    .HasMaxLength(31)
                    .HasColumnName("movie_original_name");

                entity.Property(e => e.ClassificationId).HasColumnName("classification_id");

                entity.HasOne(d => d.Classification)
                    .WithMany(p => p.MovieClassifications)
                    .HasForeignKey(d => d.ClassificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mc_classification");

                entity.HasOne(d => d.MovieOriginalNameNavigation)
                    .WithMany(p => p.MovieClassifications)
                    .HasForeignKey(d => d.MovieOriginalName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mc_movie");
            });

            modelBuilder.Entity<Projection>(entity =>
            {
                entity.ToTable("projection");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.EndTime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("end_time");

                entity.Property(e => e.InitialTime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("initial_time");

                entity.Property(e => e.MovieOriginalName)
                    .HasMaxLength(31)
                    .HasColumnName("movie_original_name");

                entity.HasOne(d => d.MovieOriginalNameNavigation)
                    .WithMany(p => p.Projections)
                    .HasForeignKey(d => d.MovieOriginalName)
                    .HasConstraintName("projection_movie");
            });

            modelBuilder.Entity<ProjectionClient>(entity =>
            {
                entity.HasKey(e => new { e.ProjectionId, e.ClientIdCard, e.ClientUsername })
                    .HasName("projection_client_pkey");

                entity.ToTable("projection_client");

                entity.Property(e => e.ProjectionId).HasColumnName("projection_id");

                entity.Property(e => e.ClientIdCard).HasColumnName("client_id_card");

                entity.Property(e => e.ClientUsername)
                    .HasMaxLength(15)
                    .HasColumnName("client_username");

                entity.HasOne(d => d.Projection)
                    .WithMany(p => p.ProjectionClients)
                    .HasForeignKey(d => d.ProjectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pc_projection");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ProjectionClients)
                    .HasForeignKey(d => new { d.ClientIdCard, d.ClientUsername })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pc_client");
            });

            modelBuilder.Entity<ProjectionInvoice>(entity =>
            {
                entity.HasKey(e => new { e.ProjectionId, e.InvoiceId })
                    .HasName("projection_invoice_pkey");

                entity.ToTable("projection_invoice");

                entity.Property(e => e.ProjectionId).HasColumnName("projection_id");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.ProjectionInvoices)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pi_invoice");

                entity.HasOne(d => d.Projection)
                    .WithMany(p => p.ProjectionInvoices)
                    .HasForeignKey(d => d.ProjectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pi_projection");
            });

            modelBuilder.Entity<ProjectionRoom>(entity =>
            {
                entity.HasKey(e => new { e.ProjectionId, e.CinemaName, e.RoomId })
                    .HasName("projection_room_pkey");

                entity.ToTable("projection_room");

                entity.Property(e => e.ProjectionId).HasColumnName("projection_id");

                entity.Property(e => e.CinemaName)
                    .HasMaxLength(15)
                    .HasColumnName("cinema_name");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.HasOne(d => d.Projection)
                    .WithMany(p => p.ProjectionRooms)
                    .HasForeignKey(d => d.ProjectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pr_projection");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.ProjectionRooms)
                    .HasForeignKey(d => new { d.CinemaName, d.RoomId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pr_room_cinema");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(15)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => new { e.CinemaName, e.Number })
                    .HasName("room_pkey");

                entity.ToTable("room");

                entity.Property(e => e.CinemaName)
                    .HasMaxLength(15)
                    .HasColumnName("cinema_name");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Columns).HasColumnName("columns");

                entity.Property(e => e.RestrictionPercent).HasColumnName("restriction_percent");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.HasOne(d => d.CinemaNameNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.CinemaName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_cinema");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
