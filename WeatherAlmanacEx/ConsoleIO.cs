using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAlmanac.UI
{
   
        class ConsoleIO
        {
            public int GetInt(string prompt)
            {
                int result = -1;
                bool valid = false;
                while (!valid)
                {
                    Console.Write($"{prompt}: ");
                    if (!int.TryParse(Console.ReadLine(), out result))
                    {
                        Error("Please input a proper integer\n\n");
                    }
                    else
                    {
                        valid = true;
                    }
                }
                return result;
            }
        public DateTime GetDateTime(string prompt)
        {
            DateTime result = new DateTime();
            bool valid = false;
            while (!valid)
            {
                Console.Write($"{prompt}: ");
                if (!DateTime.TryParse(Console.ReadLine(), out result))
                {
                    Error("Please input a proper integer\n\n");
                }
                else
                {
                    valid = true;
                }
            }
            return result;
        }
            public decimal GetDecimal(string prompt)
        {
            decimal result = -1;
            bool valid = false;
            while (!valid)
            {
                Console.Write($"{prompt}: ");
                if (!decimal.TryParse(Console.ReadLine(), out result))
                {
                    Error("Please input a proper integer\n\n");
                }
                else
                {
                    valid = true;
                }
            }
            return result;
        }
            public void Display(string message)
            {
                Console.WriteLine(message);
            }
            public void Error(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Display(message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            public void Warn(string message)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Display(message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
}
