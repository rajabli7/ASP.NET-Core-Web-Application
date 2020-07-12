using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataLayer.Entities
{
    public partial class PhotoAndVideoServicesContext : DbContext
    {
        public PhotoAndVideoServicesContext()
        {
        }

        public PhotoAndVideoServicesContext(DbContextOptions<PhotoAndVideoServicesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Additions> Additions { get; set; }
        public virtual DbSet<DepartmentInfomations> DepartmentInfomations { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<EmployeeOrders> EmployeeOrders { get; set; }
        public virtual DbSet<OrderAdditions> OrderAdditions { get; set; }
        public virtual DbSet<OrderStatuses> OrderStatuses { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<ServiceAdditions> ServiceAdditions { get; set; }
        public virtual DbSet<ServiceTypes> ServiceTypes { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\MSSQL;Database=PhotoAndVideoServices;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Additions>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<DepartmentInfomations>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdDepartment).HasColumnName("id_department");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartmentNavigation)
                    .WithMany(p => p.DepartmentInfomations)
                    .HasForeignKey(d => d.IdDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentInfomations_Departments");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeOrders>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.OrderId });

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeOrders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeOrders_Users");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.EmployeeOrders)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_EmployeeOrders_Orders");
            });

            modelBuilder.Entity<OrderAdditions>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.AdditionId });

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.AdditionId).HasColumnName("addition_id");

                entity.HasOne(d => d.Addition)
                    .WithMany(p => p.OrderAdditions)
                    .HasForeignKey(d => d.AdditionId)
                    .HasConstraintName("FK_OrderAdditions_Additions");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderAdditions)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderAdditions_Orders");
            });

            modelBuilder.Entity<OrderStatuses>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectDate)
                    .HasColumnName("project_date")
                    .HasColumnType("date");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Services");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_OrderStatuses");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orders_clients");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ServiceAdditions>(entity =>
            {
                entity.HasKey(e => new { e.ServiceId, e.AdditionId })
                    .HasName("PK_ServicesTypesAdditions");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.AdditionId).HasColumnName("addition_id");

                entity.HasOne(d => d.Addition)
                    .WithMany(p => p.ServiceAdditions)
                    .HasForeignKey(d => d.AdditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceAdditions_Additions");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceAdditions)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceAdditions_Services");
            });

            modelBuilder.Entity<ServiceTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceTypes_Services");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("middle_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Users_Roles");
            });
        }
    }
}
