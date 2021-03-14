using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceCRUDTokaMVC.Models.Request;
using WebServiceCRUDTokaMVC.Models.Response;

namespace WebServiceCRUDTokaMVC.Services
{
    public interface IUserServices
    {
        UserResponse Auth(AuthRequest model);
    }
}
