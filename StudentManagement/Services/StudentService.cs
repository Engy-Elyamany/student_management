using StudentManagement.Helpers;
using StudentManagement.Models;
using StudentManagement.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    internal class StudentService
    {
        int idCounter = 0;

        public List<Student> All_Students = new List<Student>();

        public void View_All_Students()
        {
            OutputHandler.ViewListOfStudents(All_Students);
        }

        // ── ADD ──────────────────────────────────────────────────────────────
        public void AddStudent()
        {
            Student newStudent = InputHandler.Get_New_Student_Data();
            newStudent.Id = ++idCounter;
            All_Students.Add(newStudent);
            Console.WriteLine("     Student added successfully.");
        }


        public void SearchStudent(int std_id)
        {
            List<Student> matchedStudents = new List<Student>();

            foreach (var student in All_Students)
            {
                if (student.Id == std_id)
                    matchedStudents.Add(student);
            }

            if (matchedStudents.Count == 0)
            {
                Console.WriteLine("Student Not Found");
                return;
            }

            Console.WriteLine("Matched Result To Yor Search: ");
            OutputHandler.ViewListOfStudents(matchedStudents);
        }

        // case-insensitive comparison so "ahmed" matches "Ahmed"
        public void SearchStudent(string name)
        {
            List<Student> matchedStudents = new List<Student>();

            foreach (var student in All_Students)
            {
                if (student.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                    matchedStudents.Add(student);
            }

            if (matchedStudents.Count == 0)
            {
                Console.WriteLine("Student Not Found");
                return;
            }



            Console.WriteLine("Matched Result To Yor Search: ");
            OutputHandler.ViewListOfStudents(matchedStudents);

        }



        private Student? FindById(int std_id)
        {
            foreach (var student in All_Students)
            {
                if (student.Id == std_id)
                    return student;
            }

            return null;
        }

        public void UpdateStudent(int std_id)
        {
            Student? currentStudent = FindById(std_id);
            if (currentStudent == null)
            {
                Console.WriteLine("  [!] Student not found.");
                return;
            }

            int userChoice = -1;
            while (userChoice != 0)
            {
                OutputHandler.PrintUpdateMenu();
                userChoice = InputHandler.GetValidUserChoiceFromMenu(0, 6);

                switch (userChoice)
                {
                    case 1:
                        Console.Write("  New Name: ");
                        currentStudent.Name = Validator.GetValidName();
                        break;
                    case 2:
                        Console.Write("  New Age: ");
                        currentStudent.Age = Validator.GetValidAge();
                        break;
                    case 3:
                        Console.Write("  New Email: ");
                        currentStudent.Email = Validator.GetValidEmail();
                        break;
                    case 4:
                        Console.Write("  New Course Name: ");
                        currentStudent.CourseName = Validator.GetValidCourseName();
                        break;
                    case 5:
                        Console.Write("  New Grades: ");
                        currentStudent.Grades = Validator.GetValidGrades();
                        break;
                    case 6:
                        // Correct approach: get new data then copy each property onto the existing object
                        Student updatedData = InputHandler.Get_New_Student_Data();
                        currentStudent.Name = updatedData.Name;
                        currentStudent.Age = updatedData.Age;
                        currentStudent.Email = updatedData.Email;
                        currentStudent.CourseName = updatedData.CourseName;
                        currentStudent.Grades = updatedData.Grades;
                        break;
                }
            }

            Console.WriteLine("Update Operation Completed Successfully"); ;
        }
        public void DeleteStudent(int std_id)
        {
            // Bug fixed: guard against null
            Student? currentStudent = FindById(std_id);
            if (currentStudent == null)
            {
                Console.WriteLine("  [!] Student not found.");
                return;
            }

            Console.WriteLine($"  Are you sure you want to delete '{currentStudent.Name}'? (Y/N)");
            char userChoice;

            // Bug fixed: original OR conditions made the loop infinite — any char fails at least one != check
            // Fix: use AND so the loop only continues when the input is not one of the four valid chars
            while (!char.TryParse(Console.ReadLine()?.Trim().ToUpper(), out userChoice)
                   || (userChoice != 'Y' && userChoice != 'N'))
            {
                Console.WriteLine("  [!] Invalid input. Please enter Y or N.");
            }

            if (userChoice == 'Y')
            {
                All_Students.Remove(currentStudent);

                // Re-sync all IDs to stay sequential after the gap left by deletion
                // Note: moved before return — was unreachable in original code
                for (int i = 0; i < All_Students.Count; i++)
                    All_Students[i].Id = i + 1;

                // Reset counter to match the new count so next Add gets the correct ID
                idCounter = All_Students.Count;

                Console.WriteLine("Student deleted successfully.");
                return;
            }

            Console.WriteLine("Deletion cancelled.");
        }

        public void CalculateAverage(int std_id)
        {
            Student? student = FindById(std_id);
            if (student == null)
            {
                Console.WriteLine("  [!] Student not found.");
                return;
            }

            if (student.Grades.Count == 0)
            {
                Console.WriteLine($"  '{student.Name}' has no grades recorded.");
                return;
            }

            Console.WriteLine($"  Average grade for {student.Name}: {student.AverageGrade}");
        }


    }
}
