namespace StudentManagement.Helpers
{
    internal static class Validator
    {
        // Returns true if the string contains any digit or any non-letter non-space character.
        // Used to reject names and course names that contain numbers or special characters.
        public static bool IsContainDigitsOrChar(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    return true;
            }
            return false;
        }

        // Keeps prompting until the user enters a non-empty, non-whitespace string.
        private static string GetValidString(string fieldName)
        {
            while (true)
            {
                string? value = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(value))
                    return value;
                Console.WriteLine($"  {fieldName} cannot be empty. Try again: ");
            }
        }

        // Name must be at least 3 characters, letters and spaces only
        public static string GetValidName()
        {
            while (true)
            {
                string name = GetValidString("Name");
                if (IsContainDigitsOrChar(name) || name.Length < 3)
                {
                    Console.WriteLine("  Name must be at least 3 characters and contain letters only. Try again: ");
                    continue;
                }
                return name;
            }
        }

        // Course name must contain only letters and spaces, no digits or special characters.
        public static string GetValidCourseName()
        {
            while (true)
            {
                string name = GetValidString("Course Name");
                if (IsContainDigitsOrChar(name))
                {
                    Console.WriteLine("  Course name must contain letters only. Try again: ");
                    continue;
                }
                return name;
            }
        }

        // Age must be an integer between 16 and 60
        public static int GetValidAge()
        {
            int age;
            while (!int.TryParse(Console.ReadLine(), out age) || age < 16 || age > 60)
                Console.WriteLine("  Age must be a number between 16 and 60. Try again: ");
            return age;
        }

        // Email must contain '@' and '.'
        public static string GetValidEmail()
        {
            while (true)
            {
                string email = GetValidString("Email");
                if (email.Contains('@') && email.Contains('.'))
                    return email;
                Console.WriteLine("  Email must contain '@' and '.'. Try again: ");
            }
        }

        // Grades are entered as comma-separated values e.g. 80,90,75
        // Each grade must be a whole number between 0 and 100.
        public static List<int> GetValidGrades()
        {
            while (true)
            {
                string input = GetValidString("Grades");
                string[] parts = input.Split(',');
                List<int> grades = new List<int>();
                bool valid = true;

                foreach (string part in parts)
                {
                    if (int.TryParse(part.Trim(), out int g) && g >= 0 && g <= 100)
                        grades.Add(g);
                    else
                    {
                        Console.WriteLine($"  '{part.Trim()}' is not valid. Each grade must be a number between 0 and 100. Try again: ");
                        valid = false;
                        break;
                    }
                }

                if (valid) return grades;
            }
        }

    }
}