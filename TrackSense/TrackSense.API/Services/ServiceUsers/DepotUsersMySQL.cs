using TrackSense.API.Entities;
using TrackSense.API.Entities.Interfaces;

namespace TrackSense.API.Services.ServiceUsers
{
    public class DepotUsersMySQL
        : IDepotUsers
    {
        public void AddUser(User p_user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int p_userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User? GetUserByUserLogin(string p_userLogin)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User p_user)
        {
            throw new NotImplementedException();
        }

        void IDepotUsers.AddUserContact(UserContact p_userContact, string p_userLogin)
        {
            throw new NotImplementedException();
        }

        void IDepotUsers.AddUserInterestPoint(UserInterestPoint p_interestPoint, string p_userLogin)
        {
            throw new NotImplementedException();
        }

        void IDepotUsers.AddUserTrackSense(UserTrackSense p_trackSense, string p_userLogin)
        {
            throw new NotImplementedException();
        }

        bool IDepotUsers.CheckUserPassword(string p_userLogin, string p_userPassword)
        {
            throw new NotImplementedException();
        }

        bool IDepotUsers.CheckUserToken(UserToken p_userToken)
        {
            throw new NotImplementedException();
        }

        UserToken? IDepotUsers.ConnectUser(string p_userLogin, string p_userPassword)
        {
            throw new NotImplementedException();
        }

        void IDepotUsers.DeleteAllUserTokens(string p_userLogin)
        {
            throw new NotImplementedException();
        }

        void IDepotUsers.DeleteUser(string p_userLogin)
        {
            throw new NotImplementedException();
        }

        void IDepotUsers.DeleteUserContact(int p_contactId)
        {
            throw new NotImplementedException();
        }

        void IDepotUsers.DeleteUserInterestPoint(int p_intersetPointId)
        {
            throw new NotImplementedException();
        }

        void IDepotUsers.DeleteUserToken(UserToken p_userToken)
        {
            throw new NotImplementedException();
        }

        void IDepotUsers.DeleteUserTrackSense(string p_trackSenseId, string p_userLogin)
        {
            throw new NotImplementedException();
        }

        IEnumerable<UserTrackSense>? IDepotUsers.GetAllUserTrackSenses(string p_userLogin)
        {
            throw new NotImplementedException();
        }

        bool IDepotUsers.GetAvailabilityUserLogin(string p_userLogin)
        {
            throw new NotImplementedException();
        }

        UserContact? IDepotUsers.GetUserContactById(int p_userLogin)
        {
            throw new NotImplementedException();
        }

        IEnumerable<UserContact> IDepotUsers.GetUserContacts(string p_userLogin)
        {
            throw new NotImplementedException();
        }

        UserInterestPoint? IDepotUsers.GetUserIntersetPointById(int p_interestPointId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<UserInterestPoint> IDepotUsers.GetUserIntersetPoints(string p_userLogin)
        {
            throw new NotImplementedException();
        }

        UserStatistics? IDepotUsers.GetUserStatistics(string p_userLogin)
        {
            throw new NotImplementedException();
        }

        UserTrackSense? IDepotUsers.GetUserTrackSense(string p_userLogin)
        {
            throw new NotImplementedException();
        }

        void IDepotUsers.UpdateUserContact(UserContact p_UserContact)
        {
            throw new NotImplementedException();
        }

        void IDepotUsers.UpdateUserInterestPoint(UserInterestPoint p_intersetPoint)
        {
            throw new NotImplementedException();
        }

        void IDepotUsers.UpdateUserPassword(string p_userLogin, string p_oldPassword, string p_newPassword)
        {
            throw new NotImplementedException();
        }

        void IDepotUsers.UpdateUserTrackSense(UserTrackSense p_userTrackSense)
        {
            throw new NotImplementedException();
        }
    }
}
