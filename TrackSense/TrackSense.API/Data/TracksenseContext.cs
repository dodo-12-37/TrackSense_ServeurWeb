using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TrackSense.API.Services.DTOs;

namespace TrackSense.API.Data;

public partial class TracksenseContext : DbContext
{
    public TracksenseContext()
    {
    }

    public TracksenseContext(DbContextOptions<TracksenseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<ApplicationToken> ApplicationTokens { get; set; }

    public virtual DbSet<CompletedRide> CompletedRides { get; set; }

    public virtual DbSet<CompletedRidePoint> CompletedRidePoints { get; set; }

    public virtual DbSet<CompletedRideStatistic> CompletedRideStatistics { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Credential> Credentials { get; set; }

    public virtual DbSet<InterestPoint> InterestPoints { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<PlannedRide> PlannedRides { get; set; }

    public virtual DbSet<PlannedRidePoint> PlannedRidePoints { get; set; }

    public virtual DbSet<PlannedRideStatistic> PlannedRideStatistics { get; set; }

    public virtual DbSet<Tracksense> Tracksenses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserStatistic> UserStatistics { get; set; }

    public virtual DbSet<UserToken> UserTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Address__091C2AFB166146D8");

            entity.ToTable("Address");

            entity.Property(e => e.AddressId).ValueGeneratedNever();
            entity.Property(e => e.AppartmentNumber).HasMaxLength(15);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.StreetName).HasMaxLength(100);
            entity.Property(e => e.StreetNumber).HasMaxLength(15);
            entity.Property(e => e.ZipCode).HasMaxLength(10);

            entity.HasOne(d => d.Location).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Address_Location");
        });

        modelBuilder.Entity<ApplicationToken>(entity =>
        {
            entity.HasKey(e => e.ApplicationTokenId).HasName("PK__Applicat__51EA9096072F9446");

            entity.ToTable("ApplicationToken");

            entity.HasIndex(e => e.Token, "UQ__Applicat__1EB4F8176BA0B319").IsUnique();

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.LastUsedAt).HasColumnType("datetime");
            entity.Property(e => e.Token).HasMaxLength(250);
        });

        modelBuilder.Entity<CompletedRide>(entity =>
        {
            entity.HasKey(e => e.CompletedRideId).HasName("PK__Complete__3D404232BE9BF58B");

            entity.ToTable("CompletedRide");

            entity.Property(e => e.CompletedRideId).ValueGeneratedNever();
            entity.Property(e => e.UserLogin).HasMaxLength(100);
        });

        modelBuilder.Entity<CompletedRidePoint>(entity =>
        {
            entity.HasKey(e => new { e.CompletedRideId, e.LocationId }).HasName("PK__Complete__533FA87BD1669A65");

            entity.ToTable("CompletedRidePoint");

            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");

            // configure many-to-many
            modelBuilder.Entity<CompletedRidePoint>()
                .HasOne(crp => crp.CompletedRide)
                .WithMany(cr => cr.CompletedRidePoints)
                .HasForeignKey(crp => crp.CompletedRideId);

            modelBuilder.Entity<CompletedRidePoint>()
              .HasOne(cr => cr.Location)
              .WithMany(cr => cr.CompletedRidePoints)
              .HasForeignKey(crp => crp.LocationId);
        });

        modelBuilder.Entity<CompletedRideStatistic>(entity =>
        {
            entity.HasKey(e => e.CompletedRideId).HasName("PK__Complete__3D4042327B20BD26");

            entity.Property(e => e.CompletedRideId).ValueGeneratedNever();
            entity.Property(e => e.Duration).HasColumnType("TimeSpan");

            entity.HasOne(d => d.CompletedRide).WithOne(p => p.CompletedRideStatistic)
                .HasForeignKey<CompletedRideStatistic>(d => d.CompletedRideId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompletedRideStatistics_CompletedRide");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK_contact");

            entity.ToTable("Contact");

            entity.Property(e => e.ContactId).ValueGeneratedNever();
            entity.Property(e => e.Fullname).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(12);
            entity.Property(e => e.UserLogin).HasMaxLength(100);

            entity.HasOne(d => d.UserLoginNavigation).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.UserLogin)
                .HasConstraintName("FK_Contact_User");
        });

        modelBuilder.Entity<Credential>(entity =>
        {
            entity.HasKey(e => e.UserLogin).HasName("PK__Credenti__7F8E8D5FB80D981D");

            entity.ToTable("Credential");

            entity.Property(e => e.UserLogin).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(30);

            entity.HasOne(d => d.UserLoginNavigation).WithOne(p => p.Credential)
                .HasForeignKey<Credential>(d => d.UserLogin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Credential_User");
        });

        modelBuilder.Entity<InterestPoint>(entity =>
        {
            entity.HasKey(e => e.InterestPointId).HasName("PK__Interest__E13EB84985BF89F7");

            entity.ToTable("InterestPoint");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UserLogin).HasMaxLength(100);

            entity.HasOne(d => d.Address).WithMany(p => p.InterestPoints)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InterestPoint_Address");

            entity.HasOne(d => d.UserLoginNavigation).WithMany(p => p.InterestPoints)
                .HasForeignKey(d => d.UserLogin)
                .HasConstraintName("FK_InterestPoint_User");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA497B2F12385");

            entity.ToTable("Location");

            entity.Property(e => e.LocationId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PlannedRide>(entity =>
        {
            entity.HasKey(e => e.PlannedRideId).HasName("PK__PlannedR__807DE2956F2B5FAE");

            entity.ToTable("PlannedRide");

            entity.Property(e => e.PlannedRideId).ValueGeneratedNever();
            entity.Property(e => e.IsFavorite).HasColumnName("isFavorite");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UserLogin).HasMaxLength(100);
        });

        modelBuilder.Entity<PlannedRidePoint>(entity =>
        {
            entity.HasKey(e => new { e.PlannedRideId, e.LocationId }).HasName("PK__PlannedR__EE0208DC97FCB4A7");

            entity.ToTable("PlannedRidePoint");

            // configure many-to-many
            modelBuilder.Entity<PlannedRidePoint>()
                .HasOne(crp => crp.PlannedRide)
                .WithMany(cr => cr.PlannedRidePoints)
                .HasForeignKey(crp => crp.PlannedRideId);

            modelBuilder.Entity<PlannedRidePoint>()
              .HasOne(cr => cr.Location)
              .WithMany(cr => cr.PlannedRidePoints)
              .HasForeignKey(crp => crp.LocationId);
        });

        modelBuilder.Entity<PlannedRideStatistic>(entity =>
        {
            entity.HasKey(e => e.PlannedRideId).HasName("PK__PlannedR__807DE295481CB488");

            entity.Property(e => e.PlannedRideId).HasMaxLength(36);
            entity.Property(e => e.Duration).HasColumnType("datetime");
        });

        modelBuilder.Entity<Tracksense>(entity =>
        {
            entity.HasKey(e => e.TracksenseId).HasName("PK__Tracksen__6AF72C603CA58608");

            entity.ToTable("Tracksense");

            entity.HasIndex(e => e.UserLogin, "UQ__Tracksen__7F8E8D5EC0100CC1").IsUnique();

            entity.Property(e => e.TracksenseId).ValueGeneratedNever();
            entity.Property(e => e.IsFallen).HasColumnName("isFallen");
            entity.Property(e => e.IsStolen).HasColumnName("isStolen");
            entity.Property(e => e.LastAltitude).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LastCommunication).HasColumnType("datetime");
            entity.Property(e => e.LastLatitude).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LastLongitude).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserLogin).HasMaxLength(100);

            entity.HasOne(d => d.UserLoginNavigation).WithOne(p => p.Tracksense)
                .HasForeignKey<Tracksense>(d => d.UserLogin)
                .HasConstraintName("FK_Tracksense_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserLogin);

            entity.ToTable("user");

            entity.HasIndex(e => e.UserLogin, "UQ__user__7F8E8D5EC31A1ED4").IsUnique();

            entity.Property(e => e.UserLogin).HasMaxLength(100);
            entity.Property(e => e.UserCodePostal).HasMaxLength(12);
            entity.Property(e => e.UserEmail).HasMaxLength(100);
            entity.Property(e => e.UserFirstName).HasMaxLength(100);
            entity.Property(e => e.UserLastName).HasMaxLength(100);
            entity.Property(e => e.UserPhoneNumber).HasMaxLength(12);
        });

        modelBuilder.Entity<UserStatistic>(entity =>
        {
            entity.HasKey(e => e.UserLogin).HasName("PK__UserStat__7F8E8D5FF90916AF");

            entity.Property(e => e.UserLogin).HasMaxLength(100);
            entity.Property(e => e.Duration).HasColumnType("datetime");

            entity.HasOne(d => d.UserLoginNavigation).WithOne(p => p.UserStatistic)
                .HasForeignKey<UserStatistic>(d => d.UserLogin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserStatistics_User");
        });

        modelBuilder.Entity<UserToken>(entity =>
        {
            entity.HasKey(e => e.UserTokenId).HasName("PK__UserToke__BD92DEDB60619A76");

            entity.ToTable("UserToken");

            entity.HasIndex(e => e.Token, "UQ__UserToke__1EB4F817FB3EA34C").IsUnique();

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.LastUsedAt).HasColumnType("datetime");
            entity.Property(e => e.Token).HasMaxLength(250);
            entity.Property(e => e.UserLogin).HasMaxLength(100);

            entity.HasOne(d => d.UserLoginNavigation).WithMany(p => p.UserTokens)
                .HasForeignKey(d => d.UserLogin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserToken_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
