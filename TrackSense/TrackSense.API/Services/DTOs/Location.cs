using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TrackSense.API.Services.DTOs;
[Table("Location")]
public class Location
{
    [Key]
    public int LocationId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public double? Altitude { get; set; }

    public double? Speed { get; set; }

    public virtual Address Address { get; set; } = new Address();

    public virtual ICollection<PlannedRidePoint> PlannedRidePoints { get; set; } = new List<PlannedRidePoint>();

    public virtual ICollection<CompletedRidePoint> CompletedRidePoints { get; set; } = new List<CompletedRidePoint>();

    public Location()
    {
        
    }
    public Location(Entities.Location p_location)
    {
        if (p_location.Address!=null)
        {
            this.Address = new Address( p_location.Address);
        }
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
            Speed = this.Speed,
            Address = this.Address.ToEntity()
        };
    }
}
