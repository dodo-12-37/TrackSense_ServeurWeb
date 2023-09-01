namespace TrackSense.API.Entities
{
    public interface IDepotUsers
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserByUserLogin(string p_userLogin);
        void UpdateUser(User p_user);
        void DeleteUser(int p_userId);
        void AddUser(User p_user);
    }
}
