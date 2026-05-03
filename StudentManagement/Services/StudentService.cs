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
    public enum OperationStatus
    {
        SUCCESS = -5,
        FAILURE,
        VALID,
        INVALID_INPUT,
        EMPTY_LIST,
        NULL_VALUE
    }
    internal class StudentService
    {
        int idCounter = 0;

        public List<Student> All_Students = new List<Student>();

        public void View_All_Students()
        {
            OutputHandler.ViewListOfStudents(All_Students);
        }

        public OperationStatus AddStudent()
        {
            idCounter++;
            Student new_student = InputHandler.Get_New_Student_Data();
            new_student.Id = idCounter;
            All_Students.Add(new_student);

            return OperationStatus.SUCCESS;
        }

       

        public OperationStatus SearchStudent(int std_id)
        {
            List<Student> matchedStudents = new List<Student>();
            foreach (var student in All_Students)
            {
                if (student.Id == std_id)
                    matchedStudents.Append(student);
            }

            if (matchedStudents.Count == 0)
                return OperationStatus.EMPTY_LIST;

            OutputHandler.ViewListOfStudents(matchedStudents);

            return OperationStatus.SUCCESS;
        }

        

        public OperationStatus SearchStudent(string name)
        {
            List<Student> matchedStudents = new List<Student>();
            foreach (var student in All_Students)
            {
                if (student.Name.Contains(name))
                    matchedStudents.Append(student);
            }

            if (matchedStudents.Count == 0)
                return OperationStatus.EMPTY_LIST;

            OutputHandler.ViewListOfStudents(matchedStudents);

            return OperationStatus.SUCCESS;
        }

        private Student FindById(int std_id)
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
            Student currentStudent = FindById(std_id);
            int userChoice = 1;
            while (userChoice != 0)
            {
                userChoice = InputHandler.GetValidUserChoiceFromMenu(0, 6);

                switch (userChoice)
                {

                    case 1:
                        Console.WriteLine("Enter Updated Name");
                        string newName = Validator.GetValidName();
                        currentStudent.Name = newName;
                        break;
                    case 2:
                        Console.WriteLine("Enter Updated Age");
                        int newAge = Validator.GetValidAge();
                        currentStudent.Age = newAge;
                        break;
                    case 3:
                        Console.WriteLine("Enter Updated Email");
                        string newEmail = Validator.GetValidEmail();
                        currentStudent.Email = newEmail;
                        break;
                    case 4:
                        Console.WriteLine("Enter Updated Course Name");
                        string newCourse = Validator.GetValidCourseName();
                        currentStudent.CourseName = newCourse;
                        break;
                    case 5:
                        Console.WriteLine("Enter Updated Grades");
                        List<int> newGrades = Validator.GetValidGrades();
                        currentStudent.Grades = newGrades;
                        break;
                    case 6:
                        Console.WriteLine("Enter Updated Student Data");
                        Student updatedData = InputHandler.Get_New_Student_Data();
                        updatedData.Id = currentStudent.Id;
                        updatedData = currentStudent;
                        break;
                }

            }

        }

        public OperationStatus DeleteStudent(int std_id)
        {
            Student currentStudent = FindById(std_id);
            Console.WriteLine("Are You Sure? (Y/N)");
            char userChoice;

            while (!char.TryParse(Console.ReadLine(), out userChoice)
                    || userChoice != 'Y'
                    || userChoice != 'y'
                    || userChoice != 'N'
                    || userChoice != 'n'
                    )
            {
                Console.WriteLine("Invalid Input! Please Enter (Y/N)");
            }

            if (userChoice == 'Y' || userChoice == 'y')
            {
                All_Students.Remove(currentStudent);
                return OperationStatus.SUCCESS;
               // Console.WriteLine("User Deleted Successfully");
            }
            else
            {
                return OperationStatus.FAILURE;
                //Console.WriteLine("Deletion Aborted");
            }

            idCounter--;

            //sync all IDs with the new order after deletion
            for (int i = 0; i < All_Students.Count; i++)
            {
                All_Students[i].Id = i + 1;
            }
        }

        
    }
}
