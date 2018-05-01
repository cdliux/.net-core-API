using System;
using System.Collections.Generic;
using System.Text;
using New3C_Model.User;
using New3C_Service;
using New3C_DataService;

namespace New3C_Servicelmpl
{
    public class LoginServicelmpl:LoginService
    {
        private readonly LoginDataService _loginDataService;

        public LoginServicelmpl(LoginDataService loginDataService)
        {
            _loginDataService = loginDataService;
        }

        public  User Authenticate(User login)
        {
            return _loginDataService.Authenticate(login);
        }
    }
}
