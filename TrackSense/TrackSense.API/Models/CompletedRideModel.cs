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
        public string CompletedRideId { get; set; } = Guid.NewGuid().ToString(); 
        public PlannedRideModel? PlannedRideModel { get; set; } 
        public List<CompletedRidePointModel> CompletedRidePointsModel { get; set; } = new List<CompletedRidePointModel>();
        
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
                this.PlannedRideModel = new PlannedRideModel(p_completedRide.PlannedRide);
            }
            else
            {
                this.PlannedRideModel = null;
            }

            if (p_completedRide.CompletedRidePoints != null)
            {
                this.CompletedRidePointsModel = p_completedRide.CompletedRidePoints
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

            /*      CompletedRide completedRide = new CompletedRide();
                  completedRide.CompletedRideId = this.CompletedRideId;

                  completedRide.UserLogin = this.UserLogin;


                  if(this.PlannedRideModel != null)
                  {
                      completedRide.PlannedRide = this.PlannedRideModel.ToEntity();

                      completedRide.PlannedRide.PlannedRideId = plannedRideId;
                      completedRide.PlannedRide.PlannedRidePoints.ToList().ForEach(p => p.PlannedRideId =plannedRideId);

                  }

                  completedRide.CompletedRidePoints = this.CompletedRidePointsModel.Select(p => p.ToEntity()).ToList();   

                  completedRide.CompletedRidePoints.ForEach(p => p.CompletedRideId=completedRideId);

                  completedRide.Statistics =  new CompletedRideStatistics(completedRide.CompletedRidePoints);
      */
            return new CompletedRide()
            {
                UserLogin = this.UserLogin,
                CompletedRideId = this.CompletedRideId,
                PlannedRide = this.PlannedRideModel?.ToEntity(),
                CompletedRidePoints = this.CompletedRidePointsModel.Select(p => p.ToEntity()).ToList(),
                Statistics = this.Statistics?.ToEntity()

            };
            
        }
    }

}
