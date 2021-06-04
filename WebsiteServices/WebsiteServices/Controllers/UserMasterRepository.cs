using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteServices.Models;

namespace WebsiteServices.Controllers
{
    public class UserMasterRepository : IDisposable
    {
        // SECURITY_DBEntities it is your context class
        DatabaseContext context = new DatabaseContext();

        //This method is used to check and validate the user credentials
        public User ValidateUser(string username, string password)
        {
            return context.Users.FirstOrDefault(user =>
            user.userEmail.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.passwordHash == password);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
