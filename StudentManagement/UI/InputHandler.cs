using StudentManagement.Models;
using StudentManagement.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.UI
{
    internal class InputHandler
    {
        public static Student  Get_New_Student_Data()
        {
            Console.WriteLine("Enter Student Name");
            string std_name = Validator.get_valid_string();

            Console.WriteLine("Enter Student Age");
            int std_age;
            while (!int.TryParse(Console.ReadLine(), out std_age))
            {
                Console.WriteLine("Invalid Age! Please Enter integers only");
            }

            Console.WriteLine("Enter Student Email");
            string std_email = Validator.get_valid_string();


            Console.WriteLine("Enter Course Name");
            string course_name = Validator.get_valid_string();


            
            string std_grades;
            Console.WriteLine("Enter student Grades");
            std_grades = Validator.get_valid_string();

            return new Student(std_name, std_age, std_email, course_name);
        }

    }
}
