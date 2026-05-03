using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string CourseName { get; set; }
        public List<int> Grades { get; set; } = new List<int>();

       
        public double AverageGrade
        {
            get
            {
                return Grades.Average();
            }
        }

        public override string ToString()
        {
            return $"| {Id} | {Name} | {Age} | {Email} | {CourseName} | {AverageGrade} |";
        }


        public Student(string name, int age, string email, string course_name, int id = 0)
        {
            Id = id;
            Name = name;
            Age = age;
            Email = email;
            CourseName = course_name;
        }
    }


}
