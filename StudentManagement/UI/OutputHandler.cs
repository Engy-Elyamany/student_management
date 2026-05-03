using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.UI
{
    internal class OutputHandler
    {
        public static void ViewListOfStudents(List<Student> All_Students)
        {
            if (All_Students.Count == 0)
            {
                Console.WriteLine("     Empty List! Nothing to show");
            }
            foreach (var student in All_Students)
            {
                Console.WriteLine(student);
            }
            //return Operation_Status.SUCCESS;

        }

        public static void PrintMainMenu()
        {
            Console.WriteLine(
            "\n" +
            "Main Menu" +
            "\n1. Add Student" +
            "\n2. Update Student" +
            "\n3. Delete Student" +
            "\n4. Calculate Student Average Grades" +
            "\n5. Search By Student Id" +
            "\n6. Search By Student Name" +
            "\n7. View All Students");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
            "\nTo Exit press 0" +
            "\n");
            Console.ResetColor();

        }
        public static void PrintUpdateMenu()
        {
            Console.WriteLine(
            "\n" +
            "Choose What to update from Menu" +
            "\n1. Update Name" +
            "\n2. Update Age" +
            "\n3. Update Email" +
            "\n4. Update Course Name" +
            "\n5. Update Grades" +
            "\n6. Update All Data");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
            "\nTo Exit press 0" +
            "\n");
            Console.ResetColor();
        }


    }
}
