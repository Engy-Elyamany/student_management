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

        string? name;
        public string? Name
        {
            get { return name; }
            set
            {
                Name = (name?.Length >= 3) ? value : "Default Name";
            }
        }

        int age;
        public int Age
        {
            get { return age; }

            set
            {
                Age = (age >= 16 && age <= 60) ? value : 0;
            }
        }

        string? email;
        public string? Email
        {
            get { return email; }
            set
            {
                Email = (email.Contains('@') && email.Contains('.')) ? value : "default@gmail.com";
            }

        }

        string? course_name;
        public string? Course_Name
        {
            get
            {
                return course_name;
            }
            set
            {
                Course_Name = value ;
            }
        }

        List<int> Grades = new List<int>();

        private int average_grade;

        public int Average_Grade
        {
            get
            {
                int sum_grade = 0;
                for (int i = 0; i <= Grades.Count; i++)
                {
                    sum_grade += Grades[i];
                }
                average_grade = sum_grade / Grades.Count;
                return average_grade;


            }
            set { average_grade = value; }
        }

        public override string ToString()
        {
            StringBuilder std_info = new StringBuilder();
            std_info.Append(Id);
            std_info.Append(Name);
            std_info.Append(Age);
            std_info.Append(Email);
            std_info.Append(Course_Name);
            std_info.Append(Average_Grade);
            return std_info.ToString();
        }
        public Student()
        {
            Name = name;
            Age = age;
            Email = email;
            Course_Name = course_name;
        }

        public Student(string name, int age, string email, string course_name, int id = 0)
        {
            Id = id;
            Name = name;
            Age = age;
            Email = email;
            Course_Name = course_name;
        }
    }


}
