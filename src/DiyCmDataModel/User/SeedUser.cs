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
                    Email = "kchow@diycm.net",
                    Username = "kchow",
                    FirstName = "Kevin",
                    LastName = "Chow",
                    Password = "P@$$w0rd"
                });
                db.Users.Add(new User
                {
                    Email = "jsaini@diycm.net",
                    Username = "jsaini",
                    FirstName = "Jessica",
                    LastName = "Saini",
                    Password = "P@$$w0rd"
                });
                db.Users.Add(new User
                {
                    Email = "melmasry@diycm.net",
                    Username = "melmasry",
                    FirstName = "Medhat",
                    LastName = "Elmasry",
                    Password = "P@$$w0rd"
                });
                db.Users.Add(new User
                {
                    Email = "rchen@diycm.net",
                    Username = "rchen",
                    FirstName = "Ricky",
                    LastName = "Chen",
                    Password = "P@$$w0rd"
                });
                db.SaveChanges();
            }
        }
    }
}
