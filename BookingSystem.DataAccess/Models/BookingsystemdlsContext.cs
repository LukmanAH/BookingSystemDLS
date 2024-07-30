using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemDLS.DataAccess.Models;

public partial class BookingSystemDlsContext : DbContext
{
    public BookingSystemDlsContext()
    {
    }

    public BookingSystemDlsContext(DbContextOptions<BookingSystemDlsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GlobalSetup> GlobalSetups { get; set; }

    public virtual DbSet<MstBookingCode> MstBookingCodes { get; set; }

    public virtual DbSet<MstEmail> MstEmails { get; set; }

    public virtual DbSet<MstLocation> MstLocations { get; set; }

    public virtual DbSet<MstMenu> MstMenus { get; set; }

    public virtual DbSet<MstResource> MstResources { get; set; }

    public virtual DbSet<MstResourceDetail> MstResourceDetails { get; set; }

    public virtual DbSet<MstRole> MstRoles { get; set; }

    public virtual DbSet<MstRoleMenu> MstRoleMenus { get; set; }

    public virtual DbSet<MstRoom> MstRooms { get; set; }

    public virtual DbSet<MstUser> MstUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BookingSystemDLS;Username=postgres;Password=indocyber");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GlobalSetup>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("GlobalSetup_pkey");

            entity.ToTable("GlobalSetup");

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Desc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Value).HasMaxLength(500);
        });

        modelBuilder.Entity<MstBookingCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstBookingCode_pkey");

            entity.ToTable("MstBookingCode");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.BookingCode).HasMaxLength(20);
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Delby).HasColumnName("delby");
            entity.Property(e => e.Deldate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deldate");
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<MstEmail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstEmail_pkey");

            entity.ToTable("MstEmail");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Createddate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Delby).HasColumnName("delby");
            entity.Property(e => e.Deldate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deldate");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Updateddate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<MstLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstLocation_pkey");

            entity.ToTable("MstLocation");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Createddate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Delby).HasColumnName("delby");
            entity.Property(e => e.Deldate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deldate");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Updateddate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<MstMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Menu_pkey");

            entity.ToTable("MstMenu");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Delby).HasColumnName("delby");
            entity.Property(e => e.Deldate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deldate");
            entity.Property(e => e.NavigationTo).HasMaxLength(100);
            entity.Property(e => e.ParentMenuId).HasColumnName("ParentMenuID");
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.ParentMenu).WithMany(p => p.InverseParentMenu)
                .HasForeignKey(d => d.ParentMenuId)
                .HasConstraintName("FK_ParentMenu");
        });

        modelBuilder.Entity<MstResource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstResource_pkey");

            entity.ToTable("MstResource");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Createddate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Delby).HasColumnName("delby");
            entity.Property(e => e.Deldate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deldate");
            entity.Property(e => e.IconPath).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Updateddate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<MstResourceDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstResourceDetail_pkey");

            entity.ToTable("MstResourceDetail");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Delby).HasColumnName("delby");
            entity.Property(e => e.Deldate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deldate");
            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Resource).WithMany(p => p.MstResourceDetails)
                .HasForeignKey(d => d.ResourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResourceDetail");
        });

        modelBuilder.Entity<MstRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Role_pkey");

            entity.ToTable("MstRole");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<MstRoleMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstRoleMenu_pkey");

            entity.ToTable("MstRoleMenu");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Delby).HasColumnName("delby");
            entity.Property(e => e.Deldate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deldate");
            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Menu).WithMany(p => p.MstRoleMenus)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MENU_ID");

            entity.HasOne(d => d.Role).WithMany(p => p.MstRoleMenus)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROLE_ID");
        });

        modelBuilder.Entity<MstRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MstRoom_pkey");

            entity.ToTable("MstRoom");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.AttachmentFileName).HasMaxLength(500);
            entity.Property(e => e.Color).HasMaxLength(15);
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Delby).HasColumnName("delby");
            entity.Property(e => e.Deldate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deldate");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Location).WithMany(p => p.MstRooms)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LOCATION_ID");
        });

        modelBuilder.Entity<MstUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("MstUser");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("timestamp(6) without time zone");
            entity.Property(e => e.DelDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.LoginName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(500);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UpdatedDate).HasColumnType("timestamp(6) without time zone");

            entity.HasOne(d => d.Role).WithMany(p => p.MstUsers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserRole");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
