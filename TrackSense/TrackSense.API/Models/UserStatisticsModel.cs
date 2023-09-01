using TrackSense.API.Entities;

namespace TrackSense.API.ViewModels
{
    public class UserStatisticsViewModel
    {
        public double AverageSpeed { get; set; }
        public double MaximumSpeed { get; set; }
        public double Distance { get; set; }
        public DateTime Duration { get; set; }
        public int Calories { get; set; }
        public int Falls { get; set; }

        public UserStatisticsViewModel()
        {
            ;
        }

        public UserStatisticsViewModel(UserStatistics p_userStatistics)
        {
            this.AverageSpeed = p_userStatistics.AverageSpeed;
            this.MaximumSpeed = p_userStatistics.MaximumSpeed;
            this.Distance = p_userStatistics.Distance;
            this.Duration = p_userStatistics.Duration;
            this.Calories = p_userStatistics.Calories;
            this.Falls = p_userStatistics.Falls;
        }

        public UserStatistics ToEntity()
        {
            return new UserStatistics
            {
                AverageSpeed = this.AverageSpeed,
                MaximumSpeed = this.MaximumSpeed,
                Distance = this.Distance,
                Duration = this.Duration,
                Calories = this.Calories,
                Falls = this.Falls
            };
        }
    }

}
