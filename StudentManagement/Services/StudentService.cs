using StudentManagement.Models;
using StudentManagement.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    public enum Operation_Status
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

        List<Student> All_Students = new List<Student>();

        public Operation_Status Add_Student ()
        {
            idCounter++;
            Student new_student = InputHandler.Get_New_Student_Data();
            new_student.Id = idCounter;
            All_Students.Add(new_student);

            return Operation_Status.SUCCESS;
        }

        public Operation_Status View_All_Students()
        {
            if(All_Students.Count == 0)
            {
                return Operation_Status.EMPTY_LIST;
            }
            for (int i = 0; i < All_Students.Count; i++)
            {
                Console.WriteLine(All_Students[i]);
            }
            return Operation_Status.SUCCESS;

        }

        public void Update_Student(int std_id)
        {

        }

        public void Delete_Student(int std_id)
        {

        }
    }
}
