// Nigel Maynard
using System;
using System.Threading;
using System.IO;

namespace Nigel_Maynard
{
	public class Intro
	{
		// This is the stat of the program and displays a message then calls the menu method, that is where everthing else is called from for the most part
		public static void Start()
        {
			Console.WriteLine("IN510- Assignment\nNigel Maynard\n\n\n\n");
			Thread.Sleep(3000);
			Console.Clear();
			Program.Menu();
			
			

        }

		// Displays Head of players table
		public static void TitleHead(bool withNum = false)
        {
			if (withNum == false)
            {
				string last = "LAST NAME", first = "FIRST NAME", intrest = "INTEREST";
				Console.WriteLine($"|============================================================================================|");
				Console.WriteLine($"|{last.PadRight(25)}|{first.PadRight(25)}|{intrest.PadRight(40)}|");
				Console.WriteLine($"|============================================================================================|");
			} else if (withNum == true)
            {
				string last = "LAST NAME", first = "FIRST NAME", intrest = "INTEREST", id = "ID";
				Console.WriteLine($"|==================================================================================================|");
				Console.WriteLine($"|{id.PadRight(5)}|{last.PadRight(25)}|{first.PadRight(25)}|{intrest.PadRight(40)}|");
				Console.WriteLine($"|==================================================================================================|");
			}
			
		}

		// Displays Body of players table
		public static void TitleScreen(Players[] arr, bool withNum = false)
		{
			for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].lastName == null)
                {
                    break;
                }
                Thread.Sleep(130);
                PrintPlayer(arr[i], withNum);
            }
        }

		// prints players to the screen
        public static void PrintPlayer(Players player, bool withNum = false)
        {
			if (withNum == false)
            {
				Console.WriteLine($"|--------------------------------------------------------------------------------------------|");
				Console.WriteLine($"|{player.lastName.PadRight(25)}|{player.firstName.PadRight(25)}|{player.intrest.PadRight(40)}|");
				Console.WriteLine($"|--------------------------------------------------------------------------------------------|");
			} else if (withNum == true)
            {
				Console.WriteLine($"|--------------------------------------------------------------------------------------------------|");
				Console.WriteLine($"|{(player.sortId + 1).ToString().PadRight(5)}|{player.lastName.PadRight(25)}|{player.firstName.PadRight(25)}|{player.intrest.PadRight(40)}|");
				Console.WriteLine($"|--------------------------------------------------------------------------------------------------|");
			}

            
        }

        // Picks 10 random numbers between 0 and length of Array, then sorts and returns
        public static int[] PickTen(Players[] arr)
        {
			int[] tenNums = {100, 100, 100, 100, 100, 100, 100, 100, 100, 100};
			Random rand = new Random();
			int tempIndex = 0;
			do
			{
				for (int i = 0; i < arr.Length; i++)
                {
					int temp = rand.Next(arr.Length);
					if (tenNums[0] != temp && tenNums[1] != temp && tenNums[2] != temp && tenNums[3] != temp && tenNums[4] != temp && tenNums[5] != temp && tenNums[6] != temp && tenNums[7] != temp && tenNums[8] != temp && tenNums[9] != temp)
					{
						if (tempIndex >= 10)
						{
							break;
						}
						tenNums[tempIndex] = temp;
						tempIndex++;
					}
				} 
			} while (tempIndex < 10);

			Array.Sort(tenNums);
			return tenNums;
        }

		// Edits player interests field, then changes them in text file so changes are saved
		public static void Edit(ref Players[] arr, ref Players[] ogArr)
		{
			TitleHead(true);
			TitleScreen(arr, true);
			string message = "Enter the ID of any Contestent to Change there intrest";
			bool passes = true;
			int userInput, arrLength = (arr.Length + 1);
			do
			{
				userInput = Program.GetInt(ref passes, message, false, arrLength);
			} while (passes);

			Console.WriteLine($"Old intrest is: {arr[userInput].intrest}");
			Console.WriteLine("Change to:");
			string newIntrest = Console.ReadLine();
			Console.WriteLine($"index of {userInput}");

			arr[userInput].intrest = newIntrest;
			for (int i = 0; i < ogArr.Length; i++)
			{
				if (ogArr[i].id == arr[userInput].id)
				{
					ogArr[i].intrest = newIntrest;

				}
			}
			Console.Clear();
			Console.WriteLine("Changing and Saving\nPlease Wait");
			Thread.Sleep(1500);

			StreamWriter sr = new StreamWriter(@"../../../DealOrNoDeal.txt");
			for (int i = 0; i < ogArr.Length; i++)
            {
				sr.WriteLine(ogArr[i].firstName);
				sr.WriteLine(ogArr[i].lastName);
				sr.WriteLine(ogArr[i].intrest);
            }
			Console.WriteLine("Intrest Changed and Saved");
			Intro.TitleHead();
			Intro.PrintPlayer(arr[userInput]);
			sr.Close();
			Thread.Sleep(2000);
			Console.Clear();
		}

		// picks 1 out of 10 for the game
		public static int PickOne()
        {
			Random rand = new Random();
			int num = rand.Next(0, 10);
			return num;
        }

	}
}

