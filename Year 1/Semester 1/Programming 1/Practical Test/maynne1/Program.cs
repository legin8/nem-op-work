// Nigel Maynard
using System;
using System.Threading;

namespace maynne1
{
    internal class Program
    {

        public static int NumOfMatches(string input)
        {
            return int.Parse(input);
            
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Matchstick Game");
            Random rand = new Random();
            int startNumMatchsticks = rand.Next(40, 61);


            Console.WriteLine("You may only take 1, 2 or 3 matchsticks each turn");
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();


            int matchsticks = startNumMatchsticks;
            Console.WriteLine($"You start with {startNumMatchsticks} Matchsticks");
            Thread.Sleep(2000);
            int userCount = 0, cpuCount = 0;
            int cpu = rand.Next(1, 4);
            int userNum = 0;

            do
            {
                //Console.Clear();
                Console.WriteLine($"There are, {matchsticks} Matchsticks left");
                Console.WriteLine("How many matches would you like to play");
                userNum = NumOfMatches(Console.ReadLine());
                



                if (userNum > 0 && userNum < 4)
                {
                    matchsticks -= userNum;
                    Console.WriteLine($"User plays {userNum} Matchticks");
                    Console.WriteLine($"{matchsticks} Matchsticks left");
                    userCount++;
                    cpu = rand.Next(1, 4);
                    Thread.Sleep(700);
                    matchsticks -= cpu;
                    Console.WriteLine($"Computer plays {cpu} Matchsticks");
                    Console.WriteLine($"{matchsticks} Matchsticks left");
                    cpuCount++;
                    Thread.Sleep(700);

                } else
                {
                    Console.WriteLine($"That wasn't 1, 2 or 3");
                    Console.WriteLine($"Press Enter and Try again");
                    Console.ReadLine ();
                }

                if (matchsticks > 0 && matchsticks < 2)
                {
                    if (userCount == cpuCount)
                    {
                        Console.WriteLine("User picks 1 Match");
                        matchsticks--;
                        Thread.Sleep(700);
                        Console.WriteLine("The winer is Computer");
                        Console.WriteLine($"The Computer played {userCount} turns");
                        Console.WriteLine($"User played {cpuCount} turns");
                        Console.WriteLine($"The average of turns is {startNumMatchsticks / (userCount + cpuCount):d2}");
                    } else
                    {
                        Console.WriteLine("Computer picks 1 Match");
                        matchsticks--;
                        cpuCount++;
                        Thread.Sleep(700);
                        Console.WriteLine("The winer is User");
                        Console.WriteLine($"The User played {userCount} turns");
                        Console.WriteLine($"Computer played {cpuCount} turns");
                        Console.WriteLine($"The average of turns is {startNumMatchsticks / (userCount + cpuCount):d2}");
                    }
                }

                if (matchsticks < 5 && matchsticks > 0)
                {
                    if (userCount == cpuCount)
                    {
                        if (matchsticks > 1 && matchsticks < 6)
                        {

                            //Console.Clear();
                            Console.WriteLine($"There is only {matchsticks} Matchsticks left, so you picks {matchsticks - 1}");
                            matchsticks -= matchsticks -1;
                            Console.WriteLine($"{matchsticks} Matchsticks left");
                            Thread.Sleep(700);
                            Console.WriteLine($"Computer plays {userNum} Matchsticks");
                            Console.WriteLine($"{matchsticks} Matchsticks left");
                            cpuCount++;
                            Thread.Sleep(700);
                            Console.WriteLine("The winer is User");
                            Console.WriteLine($"The User played {userCount} turns");
                            Console.WriteLine($"Computer played {cpuCount} turns");
                            Console.WriteLine($"The average of turns is {startNumMatchsticks / (userCount + cpuCount):d2}");

                            
                        } else
                        {
                            //Console.Clear();
                            Console.WriteLine($"There is only {matchsticks} Matchsticks left, so the Computer picks {matchsticks - 1}");
                            matchsticks -= matchsticks -1;
                            Console.WriteLine($"{matchsticks} Matchsticks left");
                            Thread.Sleep(700);
                            Console.WriteLine($"User plays {userNum} Matchsticks");
                            Console.WriteLine($"{matchsticks} Matchsticks left");
                            cpuCount++;
                            Thread.Sleep(700);
                            Console.WriteLine("The winer is Computer");
                            Console.WriteLine($"The Computer played {userCount} turns");
                            Console.WriteLine($"User played {cpuCount} turns");
                            Console.WriteLine($"The average of turns is {startNumMatchsticks / (userCount + cpuCount):d2}");
                        }
                    }
                }
            } while (matchsticks > 0);


        }
    }
}
