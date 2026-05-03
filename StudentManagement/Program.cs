using StudentManagement.Services;
using StudentManagement.UI;

namespace StudentManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentService service = new StudentService();
            int userChoice = -1;


            while (userChoice != 0)
            {
                Console.WriteLine("  ╔══════════════════════════════════╗");
                Console.WriteLine("  ║    Student Management System     ║");
                Console.WriteLine("  ╚══════════════════════════════════╝");

                OutputHandler.PrintMainMenu();
                userChoice = InputHandler.GetValidUserChoiceFromMenu(0, 7);

                Console.WriteLine();

                switch (userChoice)
                {
                    case 1:
                        service.AddStudent();
                        break;

                    case 2:
                        Console.Write("  Enter Student ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                            service.UpdateStudent(updateId);
                        else
                            Console.WriteLine("  Invalid ID. Please enter a number.");
                        break;

                    case 3:
                        Console.Write("  Enter Student ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                            service.DeleteStudent(deleteId);
                        else
                            Console.WriteLine("  Invalid ID. Please enter a number.");
                        break;

                    case 4:
                        Console.Write("  Enter Student ID to calculate average: ");
                        if (int.TryParse(Console.ReadLine(), out int avgId))
                            service.CalculateAverage(avgId);
                        else
                            Console.WriteLine("  Invalid ID. Please enter a number.");
                        break;

                    case 5:
                        Console.Write("  Enter Student ID to search: ");
                        if (int.TryParse(Console.ReadLine(), out int searchId))
                            service.SearchStudent(searchId);
                        else
                            Console.WriteLine("  Invalid ID. Please enter a number.");
                        break;

                    case 6:
                        Console.Write("  Enter Student Name to search: ");
                        string? searchName = Console.ReadLine()?.Trim();
                        if (!string.IsNullOrEmpty(searchName))
                            service.SearchStudent(searchName);
                        else
                            Console.WriteLine("  Name cannot be empty.");
                        break;

                    case 7:
                        service.View_All_Students();
                        break;

                    case 0:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("  Goodbye!");
                        Console.ResetColor();
                        break;
                }

                if (userChoice != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
