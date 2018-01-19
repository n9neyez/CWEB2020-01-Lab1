using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // DECLARATIONS
            string QUIT = "quit";
            string name; // primer

            
            // housekeeping
            name = housekeeping();
            while (name != QUIT)
            {
                examResult(name); // where all the magic happens

                Console.WriteLine("\nIf you want to start the program again, enter your name or {0} to exit.", QUIT); //example of using a placeholder =)
                name = Console.ReadLine();
            }
            goodbye();

        } //end main

        //housekeeping
        public static string housekeeping()
        {
            string name = "";

            // welcome user
            Console.WriteLine("Welcome to your Driver's License Exam answer program\n\n");
            Console.WriteLine("Program is paired with the question sheet provided by your DMV.\n");

            ConsoleKeyInfo start;
            Console.WriteLine("To start press ENTER\nOR\nPress any key to exit the program");
            start = Console.ReadKey();
            if (start.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("This program will track your answers for each of the 20 questions on the test" +
                                  " and give you a pass or fail.\n");
                // ask primer
                Console.WriteLine("Please enter your name: ");
                name = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\n");
                Environment.Exit(0);
            }
            return name;
        }
        public static void examResult(string name)
        {
            // DECLARATIONS
            int[] questions = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }; // questions # array
            // array to store correct answers
            string[] correctAnswers = { "b", "d", "a", "a", "c", "a", "b", "a", "c", "d", "b", "c", "d", "a", "d", "c", "c", "b", "d", "a" };
            // array will store user's answers
            string[] answersArray = new string[20];
            string answer;
                // counter for total points
            int x, scoreCounter = 0, incorrectCounter = 0, PASSING = 15; // 15 or more is passing

            Console.WriteLine("\n" + name + ", please take the time to enter in your answers for each question.\n");
            for (x = 0; x < answersArray.Length; x++)
            {
                Console.WriteLine("Question " + questions[x] + ":");

                Console.WriteLine("Enter your answer: ");
                answer = Console.ReadLine();
                answer  = answer.ToLower(); // allows user to type capital letters

                while (answer != "a" && answer != "b" && answer != "c" && answer != "d") //defensive programming
                {
                    Console.WriteLine("Please enter a valid letter (a - d).");
                    Console.WriteLine("Enter your answer: ");
                    answer = Console.ReadLine();
                    answer = answer.ToLower();

                }
                Console.WriteLine("\n");

                answersArray[x] = answer; // fills the answersArray with for each question

                if (answersArray[x] == correctAnswers[x])
                {
                    scoreCounter += 1;
                }
                /* Doesn't output correctly
                else
                {
                    incorrectCounter += 1;
                }

                questions[x] = questions[x] + incorrectCounter;
                */
            }
            if (scoreCounter >= PASSING)
            {                           
                Console.WriteLine("PASS", ConsoleColor.Green); // colors don't change
            }
            else
            {                                       
                Console.WriteLine("Sorry, please take the test another time!\n", ConsoleColor.Red); // colors don't change
            }
            Console.WriteLine(name + " you scored " + scoreCounter + " out of 20");
            /* Doesn't output correctly
            Console.WriteLine("Here are the questions you missed: ");
            for (x = 0; x < questions.Length; x++)
            {
                if (questions[x] > 0)
                {
                    Console.WriteLine(questions[x]);
                }
            }
            */
            return;
        }
        public static void goodbye()
        {
            Console.WriteLine("\nThank you for using this test.\n" +
                "Program has concluded.\n\n");
        }
    }
}
