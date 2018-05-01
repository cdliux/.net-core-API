using System;
using New3C_Service;
using New3C_Model;
using New3C_DataService;
using System.Collections.Generic;

namespace New3C_Servicelmpl
{
    public class StudentServicelmpl:StudentService
    {
        private readonly StudentDataServices _studentDataServices;

        public StudentServicelmpl(StudentDataServices studentDataServices)
        {
            _studentDataServices = studentDataServices;
        }

        public List<Student> GetDb()
        {
            return _studentDataServices.GetDb();
        }
    }
}
