using System;
using System.Collections.Generic;

namespace TrackSense.API.Services.DTOs;

public partial class PlannedRide
{
    public Guid PlannedRideId { get; set; }

    public string UserLogin { get; set; }

    public string? Name { get; set; }

    public bool? IsFavorite { get; set; }

    public virtual ICollection<CompletedRide> CompletedRides { get; set; } = new List<CompletedRide>();

    public virtual ICollection<PlannedRidePoint> PlannedRidePoints { get; set; } = new List<PlannedRidePoint>();

    public virtual PlannedRideStatistic? PlannedRideStatistic { get; set; }

    public virtual User? UserLoginNavigation { get; set; }

    public PlannedRide()
    {
        
    }
    public PlannedRide(Entities.PlannedRide p_plannedRide)
    {
        if (string.IsNullOrEmpty(p_plannedRide.UserLogin))
        {
            throw new ArgumentNullException(nameof(p_plannedRide.UserLogin));
        }
        if (p_plannedRide.PlannedRideId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(p_plannedRide.PlannedRideId));
        }
        this.PlannedRideId = p_plannedRide.PlannedRideId;
        this.UserLogin = p_plannedRide.UserLogin;
        this.Name = p_plannedRide.Name;
        this.IsFavorite = p_plannedRide.IsFavorite;
    }

    public Entities.PlannedRide ToEntity()
    {
        return new Entities.PlannedRide()
        {
            PlannedRideId = this.PlannedRideId,
            UserLogin = this.UserLogin,
            Name = this.Name,
            IsFavorite = this.IsFavorite,
        };
    }
}
