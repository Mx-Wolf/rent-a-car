using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Esx.Application.AuditTrail;
using Esx.Domain.AuditTrailEntity;

namespace Esx.Controllers;
public class UserNameService : IUserNameService
{
    public UserInfo GetUserInfo()
    {
        return new UserInfo("Mr X", "rmx@exampl.com");
    }
}
