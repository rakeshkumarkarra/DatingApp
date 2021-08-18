using Dating.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating.API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
