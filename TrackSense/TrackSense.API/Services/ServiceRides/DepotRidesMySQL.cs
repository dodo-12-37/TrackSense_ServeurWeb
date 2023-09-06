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

        public void AddCompletedRide(CompletedRide p_comletedRide)
        {
            if (p_comletedRide == null)
            {
                throw new ArgumentNullException(nameof(p_comletedRide));
            }

            if (!userIsExist(p_comletedRide.UserLogin))
            {
                throw new ArgumentNullException("UserLogin is not exist...");
            }
            if (completedRideIsExist(p_comletedRide.CompletedRideId))
            {
                throw new InvalidOperationException("Completed ride with id = "+p_comletedRide.CompletedRideId+" already exist!");
            }

            CompletedRideDTO completedRideDTO = new CompletedRideDTO(p_comletedRide);
            m_context.CompletedRideDTOs.Add(completedRideDTO);
            m_context.SaveChanges();
            m_context.ChangeTracker.Clear();

        }

        public void AddPlannedRide(PlannedRide p_plannedRide)
        {
            if (p_plannedRide == null)
            {
                throw new ArgumentNullException(nameof(p_plannedRide));
            }

            if (!userIsExist(p_plannedRide.UserLogin))
            {
                throw new ArgumentNullException("UserLogin is not exist...");
            }

            if (plannedRideIsExist(p_plannedRide.PlannedRideId))
            {
                throw new InvalidOperationException("Planned ride with id = "+p_plannedRide.PlannedRideId+" already exist!");
            }

            PlannedRideDTO plannedRideDTO = new PlannedRideDTO(p_plannedRide);
            m_context.PlannedRideDTOs.Add(plannedRideDTO);
            m_context.SaveChanges();
            m_context.ChangeTracker.Clear();

        }

        public IEnumerable<PlannedRide> GetAllPlannedRidesByUser(string p_userLogin)
        {
            if (!userIsExist(p_userLogin))
            {
                throw new ArgumentNullException("UserLogin is not exist...");
            }

            return m_context.PlannedRideDTOs.Where(p => p.UserLogin == p_userLogin)
                                            .Select(p => p.ToEntity());
        }

        public void DeletePlannedRideById(Guid p_plannedRideId)
        {
            PlannedRideDTO? plannedRideDTO = m_context.PlannedRideDTOs.FirstOrDefault(p => p.PlannedRideId==p_plannedRideId);

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
            return m_context.PlannedRideDTOs.FirstOrDefault(p => p.PlannedRideId==p_completedRideId)?.ToEntity();
        }

        public void DeleteCompletedRideById(Guid p_completedRideId)
        {
            if (p_completedRideId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(p_completedRideId));
            }
            CompletedRideDTO? completedRideDTO = m_context.CompletedRideDTOs.FirstOrDefault(p => p.CompletedRideId==p_completedRideId);

            if (completedRideDTO==null)
            {
                throw new InvalidOperationException("Do not found completed ride with id = "+p_completedRideId+"!");
            }
            m_context.CompletedRideDTOs.Remove(completedRideDTO);
            m_context.SaveChanges();
            m_context.ChangeTracker.Clear();
        }

        public IEnumerable<CompletedRide> GetAllCompletedRidesByUser(string p_userLogin)
        {
            if (userIsExist(p_userLogin))
            {
                return m_context.CompletedRideDTOs.Where(p => p.UserLogin==p_userLogin).Select(p => p.ToEntity());
            }
            return new List<CompletedRide>();
        }

        public PlannedRideStatistics? GetAllPlannedRideStatistics(Guid p_plannedRideId)
        {
            throw new NotImplementedException();
        }

        public CompletedRide? GetCompletedRideById(Guid p_completedRideId)
        {
            return m_context.CompletedRideDTOs.FirstOrDefault(p => p.CompletedRideId==p_completedRideId)?.ToEntity();
        }

        public CompletedRideStatistics? GetCompletedRideStatistics(Guid p_completedRideId)
        {
            throw new NotImplementedException();
        }


        public void UpdateCompletedRide(CompletedRide p_completedRide)
        {

            CompletedRideDTO completedRideDTO = m_context.CompletedRideDTOs.FirstOrDefault(p => p.CompletedRideId==p_completedRide.CompletedRideId);
            if (completedRideDTO == null)
            {
                throw new InvalidOperationException("Do not found completed ride with id = "+p_completedRide.CompletedRideId+"!");
            }

            if (p_completedRide.CompletedRidePoints != null)
            {
                completedRideDTO.CompletedRidePoints = p_completedRide.CompletedRidePoints.Select(p => new CompletedRidePointDTO(p)).ToList();
            }

            if (p_completedRide.Statistics != null)
            {
                completedRideDTO.Statistics = new CompletedRideStatisticsDTO(p_completedRide.Statistics);
            }

            if (p_completedRide.PlannedRide != null)
            {
                completedRideDTO.PlannedRide = new PlannedRideDTO(p_completedRide.PlannedRide);
            }

            completedRideDTO.PlannedRideId = p_completedRide?.PlannedRide?.PlannedRideId;
            

            p_completedRide = completedRideDTO.ToEntity();
            m_context.Update(completedRideDTO);
            m_context.SaveChanges();
            m_context.ChangeTracker.Clear();

        }

        public void UpdatePlannedRide(PlannedRide p_plannedRide)
        {

            PlannedRideDTO? plannedRideToUpdate = m_context.PlannedRideDTOs.FirstOrDefault(p => p.UserLogin==p_plannedRide.UserLogin && p.PlannedRideId==p_plannedRide.PlannedRideId);

            if (plannedRideToUpdate == null)
            {
                throw new InvalidOperationException("Do not found planed ride with id = "+p_plannedRide.PlannedRideId+"!");
            }
            PlannedRideDTO updatedPR = new PlannedRideDTO(p_plannedRide);

            if (updatedPR.Statistics != null)
            {
                plannedRideToUpdate.Statistics=updatedPR.Statistics;
            }
            if (string.IsNullOrEmpty(updatedPR.Name))
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

        private bool userIsExist(string p_userLogin)
        {
            if (string.IsNullOrEmpty(p_userLogin))
            {
                throw new ArgumentNullException(nameof(p_userLogin));
            }
            return m_context.UserDTOs.Any(u => u.UserLogin==p_userLogin);
        }

        private bool plannedRideIsExist(Guid p_plannedRideId)
        {
            if (p_plannedRideId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(p_plannedRideId));
            }
            return m_context.PlannedRideDTOs.Any(p => p.PlannedRideId==p_plannedRideId);
        }

        private bool completedRideIsExist(Guid p_completedRideId)
        {
            if (p_completedRideId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(p_completedRideId));
            }
            return m_context.CompletedRideDTOs.Any(p => p.CompletedRideId==p_completedRideId);

        }
    }


}
