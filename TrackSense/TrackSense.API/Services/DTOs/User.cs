using System;
using System.Collections.Generic;

namespace TrackSense.API.Services.DTOs;

public partial class User
{
    public string UserLogin { get; set; } = null!;

    public Guid? AddressId { get; set; }

    public string? UserLastName { get; set; }

    public string? UserFirstName { get; set; }

    public string? UserEmail { get; set; }

    public string? UserCodePostal { get; set; }

    public string? UserPhoneNumber { get; set; }

    public virtual ICollection<CompletedRide> CompletedRides { get; set; } = new List<CompletedRide>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual Credential? Credential { get; set; }

    public virtual ICollection<InterestPoint> InterestPoints { get; set; } = new List<InterestPoint>();

    public virtual ICollection<PlannedRide> PlannedRides { get; set; } = new List<PlannedRide>();

    public virtual Tracksense? Tracksense { get; set; }

    public virtual UserStatistic? UserStatistic { get; set; }

    public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
}
