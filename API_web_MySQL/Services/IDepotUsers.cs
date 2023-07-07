namespace API_web_MySQL.Services
{
    public interface IDepotUsers
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int p_userId);
        void UpdateUser(User p_user);
        void DeleteUser(int p_userId);
        void AddUser(User p_user);
    }
}
