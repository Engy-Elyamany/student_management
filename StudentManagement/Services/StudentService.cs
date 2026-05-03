using StudentManagement.Helpers;
using StudentManagement.Models;
using StudentManagement.UI;

namespace StudentManagement.Services
{
    internal class StudentService
    {
        // Auto-increments with each new student. 
        int idCounter = 0;

        // The in-memory list that holds all students for the duration of the program.
        public List<Student> All_Students = new List<Student>();


        // ── PRIVATE HELPERS ──────────────────────────────────────────────────
        // Returns the student with the given ID, or null if not found.
        private Student? FindById(int std_id)
        {
            foreach (var student in All_Students)
            {
                if (student.Id == std_id)
                    return student;
            }

            return null;
        }

        // ── VIEW ALL ─────────────────────────────────────────────────────────
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
            Console.WriteLine("  Student added successfully.");
        }


        // ── SEARCH ───────────────────────────────────────────────────────────

        // Searches by exact ID match.
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
                Console.WriteLine("  Student not found.");
                return;
            }

            Console.WriteLine("  Search results:");
            OutputHandler.ViewListOfStudents(matchedStudents);
        }

        // Searches by partial name match, case-insensitive.
        // Returns all students whose name contains the search term.
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
                Console.WriteLine("  Student not found.");
                return;
            }

            Console.WriteLine("  Search results:");
            OutputHandler.ViewListOfStudents(matchedStudents);

        }


        

        // ── UPDATE ───────────────────────────────────────────────────────────
        public void UpdateStudent(int std_id)
        {
            Student? currentStudent = FindById(std_id);
            if (currentStudent == null)
            {
                Console.WriteLine("  Student not found.");
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
                        Console.WriteLine("Enter new Name");
                        currentStudent.Name = Validator.GetValidName();
                        break;
                    case 2:
                        Console.WriteLine("Enter new Age");
                        currentStudent.Age = Validator.GetValidAge();
                        break;
                    case 3:
                        Console.WriteLine("Enter new Email");
                        currentStudent.Email = Validator.GetValidEmail();
                        break;
                    case 4:
                        Console.WriteLine("Enter new Course Name");
                        currentStudent.CourseName = Validator.GetValidCourseName();
                        break;
                    case 5:
                        Console.WriteLine("Enter new Grades");
                        currentStudent.Grades = Validator.GetValidGrades();
                        break;
                    case 6:
                        // Collect a full new set of data, then copy each field onto the
                        // existing student object so its ID and list reference stay intact.
                        Student updatedData = InputHandler.Get_New_Student_Data();
                        currentStudent.Name = updatedData.Name;
                        currentStudent.Age = updatedData.Age;
                        currentStudent.Email = updatedData.Email;
                        currentStudent.CourseName = updatedData.CourseName;
                        currentStudent.Grades = updatedData.Grades;
                        break;
                }
            }

            Console.WriteLine("  Student updated successfully."); ;
        }

        // ── DELETE ───────────────────────────────────────────────────────────

        public void DeleteStudent(int std_id)
        {
            Student? currentStudent = FindById(std_id);
            if (currentStudent == null)
            {
                Console.WriteLine("  Student not found.");
                return;
            }

            Console.WriteLine($"  Are you sure you want to delete {currentStudent.Name}? (Y/N)");
            char userChoice;

            // Loop until the user enters Y or N. The AND condition ensures the loop
            // exits only when the input is exactly one of the two accepted characters.
            while (!char.TryParse(Console.ReadLine()?.Trim().ToUpper(), out userChoice)
                   || (userChoice != 'Y' && userChoice != 'N'))
            {
                Console.WriteLine("  Invalid input. Please enter Y or N.");
            }

            if (userChoice == 'Y')
            {
                All_Students.Remove(currentStudent);

                // Re-sync IDs so the list stays sequential after the deletion gap.
                for (int i = 0; i < All_Students.Count; i++)
                    All_Students[i].Id = i + 1;

                // Reset counter to match the new count so next Add gets the correct ID
                idCounter = All_Students.Count;

                Console.WriteLine("  Student deleted successfully.");
                return;
            }

            Console.WriteLine("  Deletion cancelled.");
        }

        // ── CALCULATE AVERAGE ────────────────────────────────────────────────
        public void CalculateAverage(int std_id)
        {
            Student? student = FindById(std_id);
            if (student == null)
            {
                Console.WriteLine("  Student not found.");
                return;
            }

            if (student.Grades.Count == 0)
            {
                Console.WriteLine($"  {student.Name} has no grades recorded.");
                return;
            }

            Console.WriteLine($"  Average grade for {student.Name}: {student.AverageGrade:F1}");
        }


    }
}
