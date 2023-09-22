using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Text.Json.Serialization;
using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class CompletedRideModel
    {
        [DefaultValue("admin")]
        public string UserLogin { get; set; } = null!;

        [DefaultValue("b0f07b65-3055-4f99-bc09-91829ca16fdb")]
        public string CompletedRideId { get; set; } =null!;
        
        public PlannedRideModel? PlannedRide { get; set; } 
        public List<CompletedRidePointModel> CompletedRidePoints { get; set; } =null!;
        
        public CompletedRideStatisticsModel? Statistics { get;set; } = null;

        public CompletedRideModel()
        {
            ;
        }

        public CompletedRideModel(CompletedRide p_completedRide)
        {
            this.UserLogin = p_completedRide.UserLogin;

            this.CompletedRideId = p_completedRide.CompletedRideId;

            if (p_completedRide.PlannedRide != null)
            {
                this.PlannedRide = new PlannedRideModel(p_completedRide.PlannedRide);
            }
            else
            {
                this.PlannedRide = null;
            }

            if (p_completedRide.CompletedRidePoints != null)
            {
                this.CompletedRidePoints = p_completedRide.CompletedRidePoints
                    .Select(point => new CompletedRidePointModel(point))
                    .ToList();
            }

            if(!string.IsNullOrEmpty(p_completedRide.Statistics?.CompletedRideId))
            {

                this.Statistics = new CompletedRideStatisticsModel(p_completedRide.Statistics);
            }
            else
            {
                this.Statistics = new CompletedRideStatisticsModel(new CompletedRideStatistics(p_completedRide.CompletedRidePoints!,p_completedRide.CompletedRideId));
            }
        }

        public CompletedRide ToEntity()
        {

            return new CompletedRide()
            {
                UserLogin = this.UserLogin,
                CompletedRideId = this.CompletedRideId,
                PlannedRide = this.PlannedRide?.ToEntity(),
                CompletedRidePoints = this.CompletedRidePoints.Select(p => p.ToEntity()).ToList(),
                Statistics = this.Statistics?.ToEntity()

            };
            
        }
    }

}
