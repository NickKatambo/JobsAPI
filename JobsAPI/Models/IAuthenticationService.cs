using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Models
{
    public interface IAuthenticationService
    {
        ApplicationUser Authenticate(string userName, string password);
    }
}
