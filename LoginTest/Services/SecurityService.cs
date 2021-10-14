using LoginTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginTest.Services
{
    public class SecurityService
    {
        UsersDAO userDAO = new UsersDAO();
        
        public SecurityService()
        {
            
        }

        public bool IsValid(UserModel user) 
        {
            return userDAO.findUserByNameAndPassword(user);
        }
    }
    
}
