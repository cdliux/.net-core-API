using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model.User;

namespace New3C_DataService
{
    public interface LoginDataService
    {
        User Authenticate(User login);
    }
}
