using API_web_MySQL.Services;

namespace API_web_MySQL.Data
{
    public class DepotUsersMySQL : IDepotUsers
    {
        ApplicationDbContext dbContext;
        public DepotUsersMySQL(ApplicationDbContext p_dbContext)
        {
            if (p_dbContext == null)
            {
                throw new ArgumentNullException();
            }
            this.dbContext = p_dbContext;
        }
        public void AddUser(Services.User p_user)
        {
            Data.User newUser = new User(p_user);
            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();
            p_user.UserId = newUser.UserId;

            dbContext.ChangeTracker.Clear();
        }

        public void DeleteUser(int p_userId)
        {
            Data.User ? userToDelete = SearchUserById(p_userId)?? throw new ArgumentNullException("User id is invalid");
           
            dbContext.Users.Remove(userToDelete);
            dbContext.SaveChanges();
            dbContext.ChangeTracker.Clear();
        }

        public IEnumerable<Services.User> GetAllUsers()
        {
            IQueryable<User>request = dbContext.Users.AsQueryable();
            return request.Select(u => u.ToEntity()).ToList();
        }

        public Services.User? GetUserById(int p_userId)
        {
            IQueryable<User> request = dbContext.Users.AsQueryable();

            return request.FirstOrDefault(u => u.UserId== p_userId)?.ToEntity();
        }

        public void UpdateUser(Services.User p_user)
        {
            Data.User ? userToUpdate = SearchUserById(p_user.UserId)??throw new InvalidOperationException();

            userToUpdate.UserAddress = p_user.UserAddress;
            userToUpdate.UserName = p_user.UserName;
            userToUpdate.UserCodePostal =p_user.UserCodePostal;

            dbContext.Users.Update(userToUpdate);
            dbContext.SaveChanges();
            dbContext.ChangeTracker.Clear();
        }
        private Data.User ? SearchUserById(int p_userId)
        {
            IQueryable<User> request = dbContext.Users;
            return request.SingleOrDefault(u=>u.UserId == p_userId); 
        }
    }
}
