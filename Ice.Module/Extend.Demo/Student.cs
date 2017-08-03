using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend.Demo
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public Student() { }
        public Student(int _id, string _name, string _email)
        {
            id = _id;
            name = _name;
            email = _email;
        }       
    }
    public static class isEmailExt
    {
        public static bool isValidEmail(this Student stu)
        {
            int i = stu.email.LastIndexOf('@');
            int j = stu.email.LastIndexOf('.');

            if (i > j) return true;
            else return false;
        }
    }

}
