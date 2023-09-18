using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSense.API.Services.DTOs;
[Table("completedridepoint")]
[PrimaryKey(nameof(CompletedRideId),nameof(LocationId))]
public class CompletedRidePoint
{
    public string CompletedRideId { get; set; }

    public string LocationId { get; set; }

    public int? RideStep { get; set; }

    public double? Temperature { get; set; }

    public DateTime Date { get; set; }

    [ForeignKey(nameof(CompletedRideId))]
    public virtual CompletedRide CompletedRide { get; set; } = null!;
    
    [ForeignKey(nameof(LocationId))]
    public virtual Location? Location { get; set; } = null!;
    public CompletedRidePoint()
    {
        
    }
    public CompletedRidePoint(Entities.CompletedRidePoint p_completedRidePoint)
    {
        if(p_completedRidePoint == null)
        {
            throw new ArgumentException(nameof(p_completedRidePoint));
        }
        this.CompletedRideId = p_completedRidePoint.CompletedRideId;
        this.LocationId = p_completedRidePoint.LocationId;
        this.RideStep = p_completedRidePoint.RideStep;
        this.Temperature = p_completedRidePoint.Temperature;
        this.Date = p_completedRidePoint.Date;

    }

    public Entities.CompletedRidePoint ToEntity()
    {
        return new Entities.CompletedRidePoint()
        {
            LocationId = this.LocationId,
            CompletedRideId = this.CompletedRideId,
            Date = this.Date,
            RideStep = this.RideStep,
            Temperature = this.Temperature
        };
    }
}
