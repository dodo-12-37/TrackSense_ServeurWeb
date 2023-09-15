using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTOs;
[Table("User")]
public class User
{
    [Key]
    public string UserLogin { get; set; } = null!;

    public int? AddressId { get; set; }

    public string? UserLastName { get; set; }

    public string? UserFirstName { get; set; }

    public string? UserEmail { get; set; }

    public string? UserCodePostal { get; set; }

    public string? UserPhoneNumber { get; set; }

    [ForeignKey(nameof(AddressId))]
    public virtual Address Address { get; set; } = new Address();

    public virtual Credential Credential { get; set; } = new Credential();
    public virtual UserStatistic UserStatistic { get; set; } = new UserStatistic();
    public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
    public virtual ICollection<Tracksense> Tracksenses { get; set; }=new List<Tracksense>();
    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    public virtual ICollection<CompletedRide> CompletedRides { get; set; } = new List<CompletedRide>();
    public virtual ICollection<PlannedRide> PlannedRides { get; set; } = new List<PlannedRide>();
    public virtual ICollection<InterestPoint> InterestPoints { get; set; } = new List<InterestPoint>();

}