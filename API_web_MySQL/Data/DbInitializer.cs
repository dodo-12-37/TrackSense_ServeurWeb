namespace API_web_MySQL.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            // look for any users.
            if (context.Users.Any())
            {
                return; // DB has been seeded
            }
            var users = new List<User>()
            {
                new User()
                {
                    UserName="Carson",
                    UserAddress="1565, Rue du Godendard, Drummondville, Quartier Saint-Charles-de-Drummond",
                    UserCodePostal="J2B7T5",
                    UserEmail="carson@email.com"
                },
                new User()
                {
                    UserName="Meredith",
                    UserAddress="2535 Rue Gregg, Québec",
                    UserCodePostal="G1W1J5",
                    UserEmail="Meredith@email.com"

                },
                new User()
                {
                    UserName="Arturo",
                    UserAddress="6860 Av. Doucet,Québec (Charlesbourg)",
                    UserCodePostal="G1H5N2",
                    UserEmail="Arturo@email.com"
                }
            };
            context.AddRange(users);
            context.SaveChanges();
            context.ChangeTracker.Clear();
        }
    }
}
