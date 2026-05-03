using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Helpers
{

    internal class Validator
    {
        public static string get_valid_string()
        {
            string? value;
            while (true)
            {
                value = Console.ReadLine();

                if (value is null)
                {
                    Console.WriteLine("Error! Can't leave Student Name Empty. Please Try Again");
                    continue;
                }
                return value;
            }
        }
    }
}
