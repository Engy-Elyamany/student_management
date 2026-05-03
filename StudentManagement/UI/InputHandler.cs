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
        public static Student Get_New_Student_Data()
        {
            Console.WriteLine("Enter Student Name");
            string std_name = Validator.GetValidName();

            Console.WriteLine("Enter Student Age");
            int std_age = Validator.GetValidAge();

            Console.WriteLine("Enter Student Email");
            string std_email = Validator.GetValidEmail();


            Console.WriteLine("Enter Course Name");
            string course_name = Validator.GetValidCourseName();



            List<int> std_grades;
            Console.WriteLine("Enter student Grades");
            std_grades = Validator.GetValidGrades();

            Student new_student = new Student(std_name, std_age, std_email, course_name);
            new_student.Grades = std_grades;
            return new_student;
        }

        public static int GetValidUserChoiceFromMenu(int MenuStart, int MenuRangeEnd)
        {
            Console.WriteLine("Please Choose From Menu");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int Choice))
                {
                    if (Choice > MenuRangeEnd || Choice < MenuStart)
                    {
                        Console.WriteLine("Invalid Input, out of range, Please choose from Menu ");
                        continue;
                    }
                    return Choice;
                }
                else
                {
                    Console.WriteLine("Invalid Input, please enter only digits");
                }
            }

        }
    }
}
