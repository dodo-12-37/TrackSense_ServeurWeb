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
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CompletedRideStatistic>()
            .Property(e => e.Duration)
            .HasColumnType("TIME");

        modelBuilder.Entity<UserStatistic>()
            .Property(e => e.Duration)
            .HasColumnType("TIME");
    }

    /* protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
         // Configure User entity
         modelBuilder.Entity<User>()
             .HasKey(u => u.UserLogin);

         // Configure Tracksense entity
         modelBuilder.Entity<Tracksense>()
             .HasKey(t => t.TracksenseId);
         modelBuilder.Entity<Tracksense>()
             .HasOne(t => t.User)
             .WithOne(u => u.TrackSense)
             .HasForeignKey<Tracksense>(t => t.UserLogin);

         // Configure Contact entity
         modelBuilder.Entity<Contact>()
             .HasKey(c => c.ContactId);
         modelBuilder.Entity<Contact>()
             .HasOne(c => c.User)
             .WithMany(u => u.Contacts)
             .HasForeignKey(c => c.UserLogin);

         // Configure UserStatistics entity
         modelBuilder.Entity<UserStatistic>()
             .HasKey(us => us.UserLogin);

         // Configure CompletedRideStatistics entity
         modelBuilder.Entity<CompletedRideStatistic>()
             .HasKey(crs => crs.CompletedRideId);

         // Configure CompletedRide entity
         modelBuilder.Entity<CompletedRide>()
             .HasKey(cr => cr.CompletedRideId);
         modelBuilder.Entity<CompletedRide>()
             .HasOne(cr => cr.User)
             .WithMany(u => u.CompletedRides)
             .HasForeignKey(cr => cr.UserLogin);

         // Configure CompletedRidePoint entity
         modelBuilder.Entity<CompletedRidePoint>()
             .HasKey(cr => new { cr.CompletedRideId, cr.LocationId });

         // Configure PlannedRide entity
         modelBuilder.Entity<PlannedRide>()
             .HasKey(pr => pr.PlannedRideId);
         modelBuilder.Entity<PlannedRide>()
             .HasOne(pr => pr.UserLoginNavigation)
             .WithMany(u => u.PlannedRides)
             .HasForeignKey(pr => pr.UserLogin);

         // Configure PlannedRidePoint entity
         modelBuilder.Entity<PlannedRidePoint>()
             .HasKey(prp => new { prp.PlannedRideId, prp.LocationId });

         // Configure InterestPoint entity
         modelBuilder.Entity<InterestPoint>()
             .HasKey(ip => ip.InterestPointId);
         modelBuilder.Entity<InterestPoint>()
             .HasOne(ip => ip.User)
             .WithMany(u => u.InterestPoints)
             .HasForeignKey(ip => ip.UserLogin);
         modelBuilder.Entity<InterestPoint>()
             .HasOne(ip => ip.Address)
             .WithMany()
             .HasForeignKey(ip => ip.AddressId);

         // Configure PlannedRideStatistics entity
         modelBuilder.Entity<PlannedRideStatistic>()
             .HasKey(prs => prs.PlannedRideId);

         // Configure Address entity
         modelBuilder.Entity<Address>()
             .HasKey(a => a.AddressId);
         modelBuilder.Entity<Address>()
             .HasIndex(a => a.LocationId)
             .IsUnique();
         modelBuilder.Entity<Address>()
             .HasOne(a => a.Location)
             .WithOne()
             .HasForeignKey<Address>(a => a.LocationId);
         modelBuilder.Entity<Address>()
             .HasOne(a => a.User)
             .WithOne(u => u.Address);

         // Configure Credential entity
         modelBuilder.Entity<Credential>()
             .HasKey(c => c.UserLogin);

         // Configure UserToken entity
         modelBuilder.Entity<UserToken>()
             .HasKey(ut => ut.UserTokenId);

         // Configure ApplicationToken entity
         modelBuilder.Entity<ApplicationToken>()
             .HasKey(at => at.ApplicationTokenId);

         // Configure Location entity
         modelBuilder.Entity<Location>()
             .HasKey(l => l.LocationId);
     }*/
}


