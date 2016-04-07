using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiyCmDataModel.User
{
    public class SeedUser
    {
        public static void InitializeUsers(UserContext db)
        {
            if (!db.Users.Any())
            {
                db.Users.Add(new User
                {
                    Username = "kchow",
                    FirstName = "Kevin",
                    LastName = "Chow",
                    Password = "P@$$w0rd"
                });

                db.SaveChanges();
            }
        }
    }
}
