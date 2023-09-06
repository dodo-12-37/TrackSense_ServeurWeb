using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class UserInterestPointModel
    {
        public int InterestPointID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public UserInterestPointModel()
        {
            ;
        }

        public UserInterestPointModel(UserInterestPoint p_userInterestPoint)
        {
            this.InterestPointID = p_userInterestPoint.InterestPointID;
            this.Name = p_userInterestPoint.Name;
            this.Description = p_userInterestPoint.Description;
        }

        public UserInterestPoint ToEntity()
        {
            return new UserInterestPoint
            {
                InterestPointID = this.InterestPointID,
                Name = this.Name,
                Description = this.Description
            };
        }
    }

}
