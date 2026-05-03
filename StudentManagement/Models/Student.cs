namespace StudentManagement.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string CourseName { get; set; }

        // Grades are stored as a list of integers, populated after construction.
        public List<int> Grades { get; set; } = new List<int>();

        // Computed from Grades on demand. Returns 0 if no grades have been entered.
        public double AverageGrade
        {
            get
            {
                return Grades.Count == 0 ? 0 : Grades.Average();
            }
        }

        // Formats one student as a fixed-width table row for consistent console display.
        public override string ToString()
        {
            return $"| {Id,-4} | {Name,-20} | {Age,-3} | {Email,-25} | {CourseName,-20} | {AverageGrade,-9:F1} |";
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
