namespace TrackSense.API.Models
{
    public class AvailibilityModel
    {
        public bool IsAvailable { get; set; }

        public AvailibilityModel(bool p_isAvailable)
        {
            IsAvailable = p_isAvailable;
        }
    }
    
}
