using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using VIC.DataAccess.Abstraction;
using VIC.DataAccess.Config;
using VIC.DataAccess.MSSql;
using New3C_Model;
using New3C_DataService;


namespace New3C_DataServicelmpl
{
    public class StudentDataServicelmpl:StudentDataServices
    {
        private static IDbManager _DB;

        public StudentDataServicelmpl(IDbManager dbManager)
        {
            _DB = dbManager;
        }

        public List<Student> GetDb()
        {
            var command = _DB.GetCommand("SelectAll");
            List<Student> students = command.ExecuteEntityList<Student>();
            return students;
        }
       
    }
}
