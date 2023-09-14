using System;
using System.Collections.Generic;

namespace TrackSense.API.Services.DTOs;

public partial class Location
{
    public int LocationId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public double? Altitude { get; set; }

    public double? Speed { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<PlannedRidePoint> PlannedRidePoints { get; set; } = new List<PlannedRidePoint>();

    public virtual ICollection<CompletedRidePoint> CompletedRidePoints { get; set; } = new List<CompletedRidePoint>();

    public Location()
    {
        
    }
    public Location(Entities.Location p_location)
    {
        this.LocationId = p_location.LocationId;
        this.Latitude = p_location.Latitude;
        this.Longitude = p_location.Longitude;
        this.Altitude = p_location.Altitude;
        this.Speed = p_location.Speed;
    }
    public Entities.Location ToEntity()
    {
        return new Entities.Location()
        {
            LocationId = this.LocationId,
            Latitude = this.Latitude,
            Longitude = this.Longitude,
            Altitude = this.Altitude,
            Speed = this.Speed
        };
    }
}
