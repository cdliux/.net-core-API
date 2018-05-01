using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using New3C_DataService;
using New3C_Model.User;
using VIC.DataAccess.Abstraction;
using VIC.DataAccess.Config;
using VIC.DataAccess.MSSql;

namespace New3C_DataServicelmpl
{
    public class LoginDataServicelmpl:LoginDataService
    {
        private static IDbManager _DB;

        public LoginDataServicelmpl(IDbManager dbManager)
        {
            _DB = dbManager;
        }
        
        public User Authenticate(User login)
        {
            var command = _DB.GetCommand("ConfirmUserLogin");
            User userInfo = command.ExecuteEntity<User>(new { Name=login.UserName,Pwd=login.Password});
            return userInfo;
        }
    }
}
