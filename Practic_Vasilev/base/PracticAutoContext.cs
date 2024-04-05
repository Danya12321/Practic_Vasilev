using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practic_Vasilev.@base;

public partial class PracticAutoContext : DbContext
{
    public PracticAutoContext()
    {
    }

    public PracticAutoContext(DbContextOptions<PracticAutoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Carservicehistory> Carservicehistories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Customerreview> Customerreviews { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Sparepart> Spareparts { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Supplyorder> Supplyorders { get; set; }

    public virtual DbSet<Testdrive> Testdrives { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Useraccount> Useraccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Practic_Auto;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.IdAuto).HasName("car_pkey");

            entity.ToTable("car");

            entity.HasIndex(e => e.Vin, "car_vin_key").IsUnique();

            entity.Property(e => e.IdAuto).HasColumnName("id_auto");
            entity.Property(e => e.Brand)
                .HasMaxLength(255)
                .HasColumnName("brand");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.Mileage).HasColumnName("mileage");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasColumnName("model");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Vin)
                .HasMaxLength(255)
                .HasColumnName("vin");
            entity.Property(e => e.Warranty).HasColumnName("warranty");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<Carservicehistory>(entity =>
        {
            entity.HasKey(e => e.IdHistory).HasName("carservicehistory_pkey");

            entity.ToTable("carservicehistory");

            entity.Property(e => e.IdHistory).HasColumnName("id_history");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdAuto).HasColumnName("id_auto");
            entity.Property(e => e.IdService).HasColumnName("id_service");
            entity.Property(e => e.Servicedate).HasColumnName("servicedate");

            entity.HasOne(d => d.IdAutoNavigation).WithMany(p => p.Carservicehistories)
                .HasForeignKey(d => d.IdAuto)
                .HasConstraintName("carservicehistory_id_auto_fkey");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("client_pkey");

            entity.ToTable("client");

            entity.HasIndex(e => e.Useraccountid, "client_useraccountid_key").IsUnique();

            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.Contactinfo).HasColumnName("contactinfo");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Middlename)
                .HasMaxLength(255)
                .HasColumnName("middlename");
            entity.Property(e => e.Useraccountid).HasColumnName("useraccountid");
        });

        modelBuilder.Entity<Customerreview>(entity =>
        {
            entity.HasKey(e => e.Reviewid).HasName("customerreviews_pkey");

            entity.ToTable("customerreviews");

            entity.Property(e => e.Reviewid).HasColumnName("reviewid");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdAuto).HasColumnName("id_auto");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdTransaction).HasColumnName("id_transaction");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.IdAutoNavigation).WithMany(p => p.Customerreviews)
                .HasForeignKey(d => d.IdAuto)
                .HasConstraintName("customerreviews_id_auto_fkey");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Customerreviews)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("customerreviews_id_client_fkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Employeeid).HasName("employee_pkey");

            entity.ToTable("employee");

            entity.HasIndex(e => e.Useraccountid, "employee_useraccountid_key").IsUnique();

            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Hiredate).HasColumnName("hiredate");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Middlename)
                .HasMaxLength(255)
                .HasColumnName("middlename");
            entity.Property(e => e.Performancerating).HasColumnName("performancerating");
            entity.Property(e => e.Positionid).HasColumnName("positionid");
            entity.Property(e => e.Salary)
                .HasPrecision(10, 2)
                .HasColumnName("salary");
            entity.Property(e => e.Useraccountid).HasColumnName("useraccountid");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Positionid)
                .HasConstraintName("fk_employee_position");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Positionid).HasName("positions_pkey");

            entity.ToTable("positions");

            entity.Property(e => e.Positionid).HasColumnName("positionid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Positiontitle)
                .HasMaxLength(255)
                .HasColumnName("positiontitle");
            entity.Property(e => e.Salaryrange)
                .HasMaxLength(255)
                .HasColumnName("salaryrange");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Permissions).HasColumnName("permissions");
            entity.Property(e => e.Rolename)
                .HasMaxLength(255)
                .HasColumnName("rolename");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.IdService).HasName("service_pkey");

            entity.ToTable("service");

            entity.Property(e => e.IdService).HasColumnName("id_service");
            entity.Property(e => e.Cost)
                .HasPrecision(10, 2)
                .HasColumnName("cost");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.IdAuto).HasColumnName("id_auto");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Servicetype)
                .HasMaxLength(255)
                .HasColumnName("servicetype");

            entity.HasOne(d => d.IdAutoNavigation).WithMany(p => p.Services)
                .HasForeignKey(d => d.IdAuto)
                .HasConstraintName("service_id_auto_fkey");
        });

        modelBuilder.Entity<Sparepart>(entity =>
        {
            entity.HasKey(e => e.IdPart).HasName("spareparts_pkey");

            entity.ToTable("spareparts");

            entity.Property(e => e.IdPart).HasColumnName("id_part");
            entity.Property(e => e.Instock).HasColumnName("instock");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(255)
                .HasColumnName("manufacturer");
            entity.Property(e => e.Partname)
                .HasMaxLength(255)
                .HasColumnName("partname");
            entity.Property(e => e.Partnumber)
                .HasMaxLength(255)
                .HasColumnName("partnumber");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Supplierid).HasName("suppliers_pkey");

            entity.ToTable("suppliers");

            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Companyname)
                .HasMaxLength(255)
                .HasColumnName("companyname");
            entity.Property(e => e.Contactinfo).HasColumnName("contactinfo");
            entity.Property(e => e.Contactname)
                .HasMaxLength(255)
                .HasColumnName("contactname");
        });

        modelBuilder.Entity<Supplyorder>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("supplyorders_pkey");

            entity.ToTable("supplyorders");

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.Dateordered).HasColumnName("dateordered");
            entity.Property(e => e.Expecteddelivery).HasColumnName("expecteddelivery");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Supplyorders)
                .HasForeignKey(d => d.Supplierid)
                .HasConstraintName("fk_supplier");
        });

        modelBuilder.Entity<Testdrive>(entity =>
        {
            entity.HasKey(e => e.IdTestdrive).HasName("testdrive_pkey");

            entity.ToTable("testdrive");

            entity.Property(e => e.IdTestdrive).HasColumnName("id_testdrive");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Feedback).HasColumnName("feedback");
            entity.Property(e => e.IdAuto).HasColumnName("id_auto");
            entity.Property(e => e.IdClient).HasColumnName("id_client");

            entity.HasOne(d => d.IdAutoNavigation).WithMany(p => p.Testdrives)
                .HasForeignKey(d => d.IdAuto)
                .HasConstraintName("testdrive_id_auto_fkey");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Testdrives)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("testdrive_id_client_fkey");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.IdTransaction).HasName("transaction_pkey");

            entity.ToTable("transaction");

            entity.Property(e => e.IdTransaction).HasColumnName("id_transaction");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Financingdetails).HasColumnName("financingdetails");
            entity.Property(e => e.IdAuto).HasColumnName("id_auto");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.Paymentmethod)
                .HasMaxLength(50)
                .HasColumnName("paymentmethod");

            entity.HasOne(d => d.IdAutoNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.IdAuto)
                .HasConstraintName("transaction_id_auto_fkey");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("transaction_id_client_fkey");
        });

        modelBuilder.Entity<Useraccount>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("useraccounts_pkey");

            entity.ToTable("useraccounts");

            entity.HasIndex(e => e.Username, "useraccounts_username_key").IsUnique();

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Passwordhash).HasColumnName("passwordhash");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");

            entity.HasOne(d => d.Client).WithMany(p => p.Useraccounts)
                .HasForeignKey(d => d.Clientid)
                .HasConstraintName("useraccounts_clientid_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.Useraccounts)
                .HasForeignKey(d => d.Employeeid)
                .HasConstraintName("useraccounts_employeeid_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Useraccounts)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("fk_useraccount_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
