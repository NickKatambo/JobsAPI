using JobsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        public AuthenticationService()
        {

        }

        public ApplicationUser Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
