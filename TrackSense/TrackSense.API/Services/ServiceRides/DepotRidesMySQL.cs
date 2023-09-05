using TrackSense.API.Data;
using TrackSense.API.Entities;
using TrackSense.API.Entities.Interfaces;
using TrackSense.API.Services.DTO;

namespace TrackSense.API.Services.ServiceRides
{
    public class DepotRidesMySQL
        : IDepotRides
    {
        private readonly ApplicationDbContext m_context;
        public DepotRidesMySQL(ApplicationDbContext applicationDbContext) 
        {
             this.m_context = applicationDbContext;
        }
        public void AddCompletedRide(string p_userLogin, CompletedRide p_comletedRide)
        {
            throw new NotImplementedException();
        }

        public void AddPlannedRide(PlannedRide p_plannedRide)
        {
            if (p_plannedRide == null)
            {
                throw new ArgumentNullException(nameof(p_plannedRide));
            }
            if (string.IsNullOrEmpty(p_plannedRide.UserLogin))
            {
                throw new ArgumentNullException("UserLogin cannot be empty...");
            }
            if(p_plannedRide.PlannedRideId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(p_plannedRide.PlannedRideId));
            }

            PlannedRideDTO plannedRideDTO = new PlannedRideDTO(p_plannedRide);
            m_context.PlannedRideDTOs.Add(plannedRideDTO);
            m_context.SaveChanges();
            m_context.ChangeTracker.Clear();

        }

        public IEnumerable<PlannedRide> GetAllPlannedRides(string p_userLogin)
        {
            if (string.IsNullOrEmpty(p_userLogin))
            {
                throw new ArgumentNullException(nameof (p_userLogin));
            }
            return m_context.PlannedRideDTOs.Where(p => p.UserLogin == p_userLogin)
                                            .Select(p => p.ToEntity());
        }

        public void DeletePlannedRide(Guid p_plannedRideId)
        {
            PlannedRideDTO? plannedRideDTO = m_context.PlannedRideDTOs.FirstOrDefault(p=>p.PlannedRideId==p_plannedRideId);
           
            if (plannedRideDTO==null)
            {
                throw new InvalidOperationException("Do not found planed ride with id = "+p_plannedRideId+"!");
            }
            m_context.PlannedRideDTOs.Remove(plannedRideDTO);
            m_context.SaveChanges();
            m_context.ChangeTracker.Clear();
        }
        public PlannedRide? GetPlannedRideById(Guid p_completedRideId)
        {
            return m_context.PlannedRideDTOs.FirstOrDefault(p=>p.PlannedRideId==p_completedRideId)?.ToEntity();
        }
        public void DeleteCompletedRide(Guid p_completedRideId)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<CompletedRide> GetAllCompletedRides(string p_userLogin)
        {
            throw new NotImplementedException();
        }

        public PlannedRideStatistics? GetAllPlannedRideStatistics(Guid p_plannedRideId)
        {
            throw new NotImplementedException();
        }

        public CompletedRide? GetCompletedRideById(Guid p_completedRideId)
        {
            throw new NotImplementedException();
        }

        public CompletedRideStatistics? GetCompletedRideStatistics(Guid p_completedRideId)
        {
            throw new NotImplementedException();
        }


        public void UpdateCompletedRide(CompletedRide p_completedRide)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlannedRide(PlannedRide p_plannedRide)
        {
            IEnumerable<PlannedRide> plannedRidesByUser = GetAllPlannedRides(p_plannedRide.UserLogin);

            PlannedRideDTO? plannedRideToUpdate = m_context.PlannedRideDTOs.FirstOrDefault(p=>p.UserLogin==p_plannedRide.UserLogin && p.PlannedRideId==p_plannedRide.PlannedRideId);    

            if(plannedRideToUpdate == null)
            {
                throw new InvalidOperationException("Do not found planed ride with id = "+p_plannedRide.PlannedRideId+"!");
            }
            PlannedRideDTO updatedPR = new PlannedRideDTO(p_plannedRide);

            if(updatedPR.Statistics != null)
            {
                plannedRideToUpdate.Statistics=updatedPR.Statistics;
            }
            if(string.IsNullOrEmpty( updatedPR.Name))
            {
                plannedRideToUpdate.Name = updatedPR.Name;
            }
            if (updatedPR.RidePoints != null)
            {
                plannedRideToUpdate.RidePoints=updatedPR.RidePoints;
            }
            plannedRideToUpdate.IsFavorite = updatedPR.IsFavorite;

            m_context.Update(plannedRideToUpdate);
            m_context.SaveChanges();
            m_context.ChangeTracker.Clear();
        }
     
    }
}
