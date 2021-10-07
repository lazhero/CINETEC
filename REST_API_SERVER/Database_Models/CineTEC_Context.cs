using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class CineTEC_Context : DbContext
    {
        public CineTEC_Context()
        {
        }

        public CineTEC_Context(DbContextOptions<CineTEC_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<ActorMovie> ActorMovies { get; set; }
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
        public virtual DbSet<Seat> Seats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseNpgsql("Host=25.92.13.1;Port=6200;Database=cinetec;Username=admin;Password=1234");
                optionsBuilder.UseNpgsql("Host=localhost;Port=6200;Database=cinetec;Username=admin;Password=1234");
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
            });

            modelBuilder.Entity<ActorMovie>(entity =>
            {
                entity.HasKey(e => new { e.ActorFirstName, e.ActorMiddleName, e.ActorLastName, e.ActorSecondLastName, e.MovieOriginalName })
                    .HasName("actor_movie_pkey");

                entity.ToTable("actor_movie");

                entity.Property(e => e.ActorFirstName)
                    .HasMaxLength(15)
                    .HasColumnName("actor_first_name");

                entity.Property(e => e.ActorMiddleName)
                    .HasMaxLength(15)
                    .HasColumnName("actor_middle_name");

                entity.Property(e => e.ActorLastName)
                    .HasMaxLength(15)
                    .HasColumnName("actor_last_name");

                entity.Property(e => e.ActorSecondLastName)
                    .HasMaxLength(15)
                    .HasColumnName("actor_second_last_name");

                entity.Property(e => e.MovieOriginalName)
                    .HasMaxLength(31)
                    .HasColumnName("movie_original_name");

                entity.HasOne(d => d.MovieOriginalNameNavigation)
                    .WithMany(p => p.ActorMovies)
                    .HasForeignKey(d => d.MovieOriginalName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("am_movie");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ActorMovies)
                    .HasForeignKey(d => new { d.ActorFirstName, d.ActorMiddleName, d.ActorLastName, d.ActorSecondLastName })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("am_actor");
            });

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("cinema_pkey");

                entity.ToTable("cinema");

                entity.Property(e => e.Name)
                    .HasMaxLength(32)
                    .HasColumnName("name");

                entity.Property(e => e.Location)
                    .HasMaxLength(31)
                    .HasColumnName("location");
            });

            modelBuilder.Entity<Classification>(entity =>
            {
                entity.ToTable("classification");

                entity.Property(e => e.Id)
                    .HasMaxLength(6)
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

                entity.HasIndex(e => e.IdCard, "client_id_card_key")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "client_username_key")
                    .IsUnique();

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
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => new { e.IdCard, e.Username })
                    .HasName("employee_pkey");

                entity.ToTable("employee");

                entity.HasIndex(e => e.IdCard, "employee_id_card_key")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "employee_username_key")
                    .IsUnique();

                entity.Property(e => e.IdCard).HasColumnName("id_card");

                entity.Property(e => e.Username)
                    .HasMaxLength(15)
                    .HasColumnName("username");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.CinemaName)
                    .HasMaxLength(32)
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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.TicketNumber).HasColumnName("ticket_number");

                entity.Property(e => e.Total).HasColumnName("total");
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

                entity.Property(e => e.DirectorFirstName)
                    .HasMaxLength(15)
                    .HasColumnName("director_first_name");

                entity.Property(e => e.DirectorLastName)
                    .HasMaxLength(15)
                    .HasColumnName("director_last_name");

                entity.Property(e => e.DirectorMiddleName)
                    .HasMaxLength(15)
                    .HasColumnName("director_middle_name");

                entity.Property(e => e.DirectorSecondLastName)
                    .HasMaxLength(15)
                    .HasColumnName("director_second_last_name");

                entity.Property(e => e.ElderPrice).HasColumnName("elder_price");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.KidPrice).HasColumnName("kid_price");

                entity.Property(e => e.Name)
                    .HasMaxLength(31)
                    .HasColumnName("name");

                entity.Property(e => e.TimeLength).HasColumnName("time_length");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => new { d.DirectorFirstName, d.DirectorMiddleName, d.DirectorLastName, d.DirectorSecondLastName })
                    .HasConstraintName("movie_director");
            });

            modelBuilder.Entity<MovieClassification>(entity =>
            {
                entity.HasKey(e => new { e.MovieOriginalName, e.ClassificationId })
                    .HasName("movie_classification_pkey");

                entity.ToTable("movie_classification");

                entity.Property(e => e.MovieOriginalName)
                    .HasMaxLength(31)
                    .HasColumnName("movie_original_name");

                entity.Property(e => e.ClassificationId)
                    .HasMaxLength(6)
                    .HasColumnName("classification_id");

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

                entity.Property(e => e.Id).HasColumnName("id");

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
                    .HasMaxLength(32)
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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => new { e.CinemaName, e.Number })
                    .HasName("room_pkey");

                entity.ToTable("room");

                entity.Property(e => e.CinemaName)
                    .HasMaxLength(32)
                    .HasColumnName("cinema_name");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Columns).HasColumnName("columns");

                entity.Property(e => e.RestrictionPercent).HasColumnName("restriction_percent");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.HasOne(d => d.CinemaNameNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.CinemaName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_cinema");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(e => new { e.ProjectionId, e.SeatNumber })
                    .HasName("seat_pkey");

                entity.ToTable("seat");

                entity.Property(e => e.ProjectionId).HasColumnName("projection_id");

                entity.Property(e => e.SeatNumber).HasColumnName("seat_number");

                entity.HasOne(d => d.Projection)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.ProjectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("seat_projection");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
