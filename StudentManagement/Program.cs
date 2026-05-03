using Microsoft.VisualBasic;

namespace StudentManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Services.StudentService service = new Services.StudentService();
            service.Add_Student();
            service.View_All_Students();

        }
    }
}
