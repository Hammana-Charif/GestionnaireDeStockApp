using DataLayer;
using DataTransfertObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BusinessLogicLayer
{
    public class LoginManager
    {
        public static LoginSession LoginSession { get; set; } = new LoginSession();

        private LoginManager() { }

        public static LoginSession TryToConnect(string username, string password)
        {
            User newUserIdentification = null;
            StockContext dbContext = new StockContext();
            newUserIdentification = dbContext.Users.Where(c => c.Username == username && c.Password == password).FirstOrDefault();
            if (newUserIdentification != null)
            {
                DbSet<LoginSession> loginSessions = dbContext.LoginSessions;
                LoginSession = new LoginSession
                {
                    UserName = newUserIdentification.Username,
                    ConnectionState = true,
                    ConnectionDate = DateTime.Now
                };
                _ = loginSessions.Add(LoginSession);
                _ = dbContext.SaveChanges();
                return LoginSession;
            }
            else
            {
                return null;
            }
        }
    }
}
