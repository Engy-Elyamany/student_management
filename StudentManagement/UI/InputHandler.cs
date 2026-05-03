using StudentManagement.Models;
using StudentManagement.Helpers;

namespace StudentManagement.UI
{
    internal class InputHandler
    {
         // Collects all required fields from the user and returns a fully built Student object.
        // ID is not set here — it is assigned by StudentService when the student is added.
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


            Console.WriteLine("Enter Student Grades (comma-separated, e.g. 80,90,75)");
            List<int> std_grades = Validator.GetValidGrades();

            Student new_student = new Student(std_name, std_age, std_email, course_name);
            new_student.Grades = std_grades;
            return new_student;
        }

        // Reads a menu choice from the user within the given range (inclusive).
        // Keeps prompting until a valid integer within range is entered.
        public static int GetValidUserChoiceFromMenu(int menuStart, int menuRangeEnd)
        {
            Console.WriteLine("Please Choose From Menu");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice >= menuStart && choice <= menuRangeEnd)
                        return choice;
                    Console.WriteLine($"  Please enter a number between {menuStart} and {menuRangeEnd}.");
                }
                else
                {
                    Console.WriteLine("  Please enter digits only.");
                }
            }

        }
    }
}
