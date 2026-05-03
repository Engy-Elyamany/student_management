using StudentManagement.Models;

namespace StudentManagement.UI
{
    internal class OutputHandler
    {
        // Prints a formatted table of students.
        // Shows a message and returns early if the list is empty.
        public static void ViewListOfStudents(List<Student> Students)
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("  No students to show.");
                return;
            }

            // Table header
            Console.WriteLine();
            Console.WriteLine($"  | {"ID",-4} | {"Name",-20} | {"Age",-3} | {"Email",-25} | {"Course",-20} | {"Avg Grade",-9} |");
            Console.WriteLine($"  {new string('-', 97)}");

            foreach (var student in Students)
                Console.WriteLine("  " + student.ToString());

            Console.WriteLine();
        }

        public static void PrintMainMenu()
        {
            Console.WriteLine(
                "\nMain Menu\n" +
                "1. Add Student\n" +
                "2. Update Student\n" +
                "3. Delete Student\n" +
                "4. Calculate Student Average Grade\n" +
                "5. Search by Student ID\n" +
                "6. Search by Student Name\n" +
                "7. View All Students");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPress 0 to Exit\n");
            Console.ResetColor();
        }

        public static void PrintUpdateMenu()
        {
            Console.WriteLine(
                "\nWhat would you like to update?\n" +
                "1. Name\n" +
                "2. Age\n" +
                "3. Email\n" +
                "4. Course Name\n" +
                "5. Grades\n" +
                "6. All Data");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPress 0 to finish updating\n");
            Console.ResetColor();
        }
    }
}