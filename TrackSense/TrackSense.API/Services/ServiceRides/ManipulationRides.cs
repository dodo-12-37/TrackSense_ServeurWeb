using TrackSense.API.Entities.Interfaces;

namespace TrackSense.API.Services.ServiceRides
{
    public class ManipulationRides
    {
        private IDepotRides m_depotRides;

        public ManipulationRides(IDepotRides p_depotRides)
        {
            if (p_depotRides == null)
            {
                throw new ArgumentNullException();
            }

            this.m_depotRides = p_depotRides;
        }
    }
}
