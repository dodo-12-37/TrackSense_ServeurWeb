using System.Globalization;

namespace TrackSense.API.Entities
{
    public interface IDepotUsers
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserByUserLogin(string p_userLogin);
        void UpdateUser(User p_user);
        void DeleteUser(string p_userLogin);
        void AddUser(User p_user);
        bool GetAvailabilityUserLogin(string p_userLogin);
        bool CheckUserToken(UserToken p_userToken);
        UserToken? ConnectUser(string p_userLogin, string p_userPassword);
        void DeleteUserToken(UserToken p_userToken);
        void DeleteAllUserTokens(string p_userLogin);
        bool CheckUserPassword(string p_userLogin, string p_userPassword);
        void UpdateUserPassword(string p_userLogin, string p_oldPassword, string p_newPassword);
        TrackSense? GetUserTrackSense(string p_userLogin);
        void AddUserTrackSense(TrackSense p_trackSense, string p_userLogin);
        void UpdateUserTrackSense(TrackSense p_userTrackSense);
        void DeleteUserTrackSense(string p_trackSenseId, string p_userLogin);
        UserStatistics? GetUserStatistics(string p_userLogin);
        IEnumerable<UserContact> GetUserContacts(string p_userLogin);
        UserContact? GetUserContactById(int p_userLogin);
        void AddUserContact(UserContact p_userContact, string p_userLogin);
        void UpdateUserContact(UserContact p_UserContact);
        void DeleteUserContact(int p_contactId);
        IEnumerable<IntersetPoint> GetIntersetPoints(string p_userLogin);
        IntersetPoint? GetIntersetPointById(int p_interestPointId);
        void AddInterestPoint(IntersetPoint p_interestPoint, string p_userLogin);
        void UpdateInterestPoint(IntersetPoint p_intersetPoint);
        void DeleteInterestPoint(int p_intersetPointId);
    }
}
