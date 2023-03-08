using System;
using System.Runtime.ExceptionServices;

namespace MyNamespace
{
    partial class Programm
    {

        static void Main(string[] args)
        {
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                // Generate CNP
                int gender = rand.Next(1, 3);
                int birthYear = rand.Next(1, 100);
                int birthMonth = rand.Next(1, 13);
                int birthDay = rand.Next(1, DateTime.DaysInMonth(2000, birthMonth) + 1);
                int areaCode = rand.Next(1, 53);
                int orderNumber = rand.Next(1000);

                // Calculate control digit
                int[] cnp = new int[12];
                cnp[0] = gender;
                cnp[1] = birthYear / 10;
                cnp[2] = birthYear % 10;
                cnp[3] = birthMonth / 10;
                cnp[4] = birthMonth % 10;
                cnp[5] = birthDay / 10;
                cnp[6] = birthDay % 10;
                cnp[7] = areaCode / 10;
                cnp[8] = areaCode % 10;
                cnp[9] = orderNumber / 100;
                cnp[10] = (orderNumber / 10) % 10;
                cnp[11] = orderNumber % 10;

                int[] weights = { 2, 7, 9, 1, 4, 6, 3, 5, 8, 2, 7, 9 };
                int sum = 0;
                for (int j = 0; j < 12; j++)
                {
                    sum += cnp[j] * weights[j];
                }
                int controlDigit = sum % 11;
                if (controlDigit == 10)
                {
                    controlDigit = 1;
                }

                // Output
                Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}",
                    gender, birthYear / 10, birthYear % 10, birthMonth / 10, birthMonth % 10,
                    birthDay / 10, birthDay % 10, areaCode / 10, areaCode % 10,
                    orderNumber / 100, (orderNumber / 10) % 10, orderNumber % 10, controlDigit);
            }
        }
    }
}