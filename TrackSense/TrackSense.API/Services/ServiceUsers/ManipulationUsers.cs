using TrackSense.API.Entities.Interfaces;

namespace TrackSense.API.Services.ServiceUsers
{
    public class ManipulationUsers
    {
        private IDepotUsers m_depotUsers;

        public ManipulationUsers(IDepotUsers p_depotUsers)
        {
            if (p_depotUsers == null)
            {
                throw new ArgumentNullException();
            }

            this.m_depotUsers = p_depotUsers;
        }
    }
}
