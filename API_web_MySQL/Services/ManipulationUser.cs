
namespace API_web_MySQL.Services
{
    public class ManipulationUser
    {
        IDepotUsers m_depotUsers;
        public ManipulationUser(IDepotUsers p_depotUsers)
        {
             if(p_depotUsers is null)
             {
                    throw new ArgumentNullException();
             }
             this.m_depotUsers = p_depotUsers;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return m_depotUsers.GetAllUsers();
        }

        public User? GetUserById(int p_userId)
        {
            if(p_userId <0)
            {
                throw new InvalidOperationException("User Id must be greater than 0");
            }
           return m_depotUsers.GetUserById(p_userId);
        }

        public void UpdateUser(User p_user)
        {
            if(p_user is null)
            {
                throw new ArgumentNullException();
            }
            if(this.GetUserById(p_user.UserId)== null)
            {
                throw new InvalidOperationException("userId is invalid");
            }
            m_depotUsers.UpdateUser(p_user);
        }

        public void DeleteUser(int p_userId)
        {
            
            User ? userToDelete = m_depotUsers.GetUserById(p_userId);
            if (userToDelete is null)
            {
                throw new InvalidOperationException("userId is invalid");
            }
            m_depotUsers.DeleteUser(p_userId);
        }

        public void AddUser(User p_user)
        {
            if (p_user is null)
            {
                throw new ArgumentNullException();
            }

            if(p_user.UserEmail == null||p_user.UserName==String.Empty)
            {
                throw new InvalidOperationException();
            }
            User? activeUser = this.GetAllUsers().First(u => u.UserEmail == p_user.UserEmail);

            if(activeUser != null)
            {
                throw new InvalidOperationException("The user's email address already exists!");
            }

        }
    }
}
