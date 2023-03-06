// Nigel Maynard
using System;
using System.IO;
using System.Threading;


namespace Nigel_Maynard
{


    

    // Struct: This will be used for each player getting info from .txt file
    public struct Players
    {
        public string firstName, lastName, intrest;
        public int id, sortId;
    }


    class Program
    {
        // This will be used for the Game
        public static Players chosenPlayer;
        
        
        public static Players[] finalTen = new Players[10];


        // Utility Can be Reused by anything
        public static string GetString() => Console.ReadLine();

        // Menu System, calls different methods for the option you pick
        public static void Menu()
        {
            Players[] pool = new Players[40];
            Players[] sorted = new Players[40];
            int[] randTen = new int[10];
            bool run = true, inputRight = true;
            int userInput;
            string menuMessage = "Type:\n1 To get players:\n2 To update player interest:\n3 To pick 10 Finalists\n4 To pick a Finalist to Play\n5 To Start Deal or No Deal:\n6 To Shutdown";

            do
            {
                userInput = GetInt(ref inputRight, menuMessage);

            } while (inputRight);

            inputRight = true;
            
            if (userInput != 0)
            {
                do
                {
                    
                    switch (userInput)
                    {
                        // Loads and Displays Players
                        case 1:
                            StreamReader sr = new StreamReader(@"../../../DealOrNoDeal.txt");
                            Console.Clear();
                            Console.WriteLine("Task 1\nLoading Contestants from file");
                            ArrFill(ref pool, ref sr);
                            sr.Close();

                            Thread.Sleep(2000);
                            Console.Clear();
                            Console.WriteLine("Players in sorted order of Last Name\n");
                            Thread.Sleep(1000);
                            sorted = Sort(pool);
                            Intro.TitleHead();
                            Intro.TitleScreen(sorted);
                            Console.WriteLine("\n\n");
                            Thread.Sleep(1000);
                            userInput = GetInt(ref inputRight, menuMessage);
                            break;

                            // Edits
                        case 2:
                            Console.Clear();
                            Intro.Edit(ref sorted, ref pool);
                            userInput = GetInt(ref inputRight, menuMessage);
                            break;

                            // Picks 10 Players
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Task 3\nPicking 10 Players\n\n");
                            randTen = Intro.PickTen(sorted);
                            Thread.Sleep(1000);
                            Intro.TitleHead();
                            for (int i = 0; i < randTen.Length; i++)
                            {
                                Thread.Sleep(130);
                                Intro.PrintPlayer(sorted[randTen[i]]);
                            }
                            Console.WriteLine("\nThese are 10 Contestants picked at random\n");
                            Thread.Sleep(1000);
                            userInput = GetInt(ref inputRight, menuMessage);
                            break;



                        case 4:
                            // Picks 1 player for Deal or No Deal
                            Console.Clear();
                            Console.WriteLine("Task 4\nPick 1 Player from the list of 10 Contestents");
                            int num = Intro.PickOne();
                            Console.WriteLine("The Contestent picked to play\nDeal or No Deal is");
                            Program.chosenPlayer = sorted[randTen[num]];
                            Intro.TitleHead();
                            Intro.PrintPlayer(sorted[randTen[num]]);
                            Thread.Sleep(2000);
                            userInput = GetInt(ref inputRight, menuMessage);

                            break;
                        case 5:
                            // Plays Game
                            Console.Clear();
                            Console.WriteLine("Task 5");
                            DoND.GameIntro();
                            userInput = GetInt(ref inputRight, menuMessage);
                            break;
                        case 6:
                            // Closes Program
                            run = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Error Menu input wrong");
                            userInput = GetInt(ref inputRight, menuMessage);
                            break;
                    }
                } while (run);
            }
            

        }

        

        // Checks if input is correct, repeats until correct input given.
        public static int GetInt(ref bool inputRight, string words, bool notEdit = true, int num = 0)
        {
            if (notEdit)
            {
                Console.WriteLine(words);
                int result;
                bool isItANum = Int32.TryParse(GetString(), out result);
                if (result == 1 || result == 2 || result == 3 || result == 4 || result == 5 || result == 6)
                {
                    inputRight = false;
                    Console.WriteLine("Input accepted");
                    Thread.Sleep(500);
                    return result;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Input not valid, Try again");
                    return 0;
                }
            } else {
                Console.WriteLine(words);
                int result;
                bool isItANum = Int32.TryParse(GetString(), out result);
                if (result > 0 && result < num)
                {
                    result--;
                    inputRight = false;
                    Console.WriteLine("Input accepted");
                    Thread.Sleep(500);
                    return result;
                }
                else
                {
                    //Console.Clear();
                    Console.WriteLine("Input not valid, Try again");
                    return 0;
                }
            }
            
        }



        // Fills Array, from txt file
        public static void ArrFill(ref Players[] arr, ref StreamReader sr)
        {
            int index = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].firstName = sr.ReadLine();
                arr[i].lastName = sr.ReadLine();
                arr[i].intrest = sr.ReadLine();
                arr[i].id = index;
                index++;
            }

        }


        
        // Used to sort players by last name, returns new sorted array
        public static Players[] Sort(Players[] players)
        {
            Players[] sorted = new Players[40];
            
            char check1 = 'A';
            int sortedCount = 0, id = 0;
            while (check1 != 'a')
            {
                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i].lastName.ToUpper()[0] == check1)
                    {
                        sorted[sortedCount] = players[i];
                        sorted[sortedCount].sortId = id;
                        id++;
                        sortedCount++;
                    }
                }
                check1++;
            }
            return sorted;
        }



        




        static void Main(string[] args)
        {

            // Default person to play game if you don't do steps 1-4
            Program.chosenPlayer.firstName = "Samanth";
            Program.chosenPlayer.lastName = "Maynard";
            Program.chosenPlayer.intrest = "Poneys";
            // Starts Program
            Intro.Start();
            Thread.Sleep(4000);
            Console.WriteLine("Good Bye");
            Thread.Sleep(4500);
        }
    }
}

