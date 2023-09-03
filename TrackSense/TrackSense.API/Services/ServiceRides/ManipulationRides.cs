using System.Globalization;
using TrackSense.API.Entities;
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

        public void AddCompletedRide(string p_userLogin, CompletedRide p_completedRide)
        {
            if (m_depotRides == null)
            {
                throw new ArgumentNullException("CompletedRide ne doit pas etre null - ManipulationRides.AddCompletedRide");
            }
            if (String.IsNullOrEmpty(p_userLogin))
            {
                throw new ArgumentNullException($"{nameof(p_userLogin)} ne doit pas etre null ni vide - ManipulationRides.AddCompletedRide");
            }

            this.m_depotRides.AddCompletedRide(p_userLogin, p_completedRide);
        }

        public CompletedRide? GetCompletedRide(Guid p_completedRideId)
        {
            return this.m_depotRides.GetCompletedRideById(p_completedRideId);
        }
    }
}
