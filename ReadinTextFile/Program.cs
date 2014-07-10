using System;

namespace ReadingTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;

            // Read the file and display it line by line.
            var file = new System.IO.StreamReader("data.dat");

            //assigns variable to an empty string
            var previousStudentNumber = String.Empty;
            var previousClassCode = String.Empty;
            var sum = 0;

            //loops through file if file not null
            while ((line = file.ReadLine()) != null)
            {
                //splits string into separate string variables when a comma is found.
                var tokens = line.Split(',');

                //places variables into array as specified
                var studentNumber = tokens[0];
                var name = tokens[1];
                var classCode = tokens[2];
                var finalGrade = int.Parse(tokens[4]);

                if (classCode != previousClassCode && previousClassCode != string.Empty)
                {
                    Console.WriteLine("   {0,15}, Final Grade =  {1, 3}%", previousClassCode, sum);
                    sum = 0;
                }

                if (studentNumber != previousStudentNumber)
                {
                    Console.WriteLine();
                    Console.WriteLine("{0}, {1}", studentNumber, name);
                }

                sum += finalGrade;

                previousStudentNumber = studentNumber;
                previousClassCode = classCode;
            }
            file.Close();

            // Suspend the screen.
            Console.ReadLine();
        }
    }
}
