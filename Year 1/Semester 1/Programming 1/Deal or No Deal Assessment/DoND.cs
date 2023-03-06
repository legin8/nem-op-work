// Nigel Maynard
using System;
using System.Threading;

namespace Nigel_Maynard
{
	public class DoND
	{

		public static int gameCounter = 0, indexOfPlayerSuitcase;
		public static double dondTotal = 0;
		public static bool playGame = true, pickCaseStart = true;
		public static string playerSuitcase;

		// Title screen, It will flash a few times
		public static void GameIntro()
        {
			for (int i = 0; i < 4; i++)
            {
				Console.WriteLine("            =====     ======         ==         ==     ");
				Console.WriteLine("            ==   =    ==            ====        ==     ");
				Console.WriteLine("            ==    =   ==           ==  ==       ==     ");
				Console.WriteLine("            ==    =   ======      ==    ==      ==     ");
				Console.WriteLine("            ==    =   ==         ==========     ==     ");
				Console.WriteLine("            ==   =    ==        ==        ==    ==     ");
				Console.WriteLine("            =====     ======   ==          ==   =======");
				Console.WriteLine();
				Console.WriteLine("              ====      =====     ");
				Console.WriteLine("            ==    ==    ==  ==    ");
				Console.WriteLine("           ==      ==   ==  ==    ");
				Console.WriteLine("           ==      ==   =====     ");
				Console.WriteLine("           ==      ==   ==   ==   ");
				Console.WriteLine("            ==    ==    ==    ==  ");
				Console.WriteLine("              ====      ==    ==  ");
				Console.WriteLine();
				Console.WriteLine("            ===     ==      ====    ");
				Console.WriteLine("            ====    ==    ==    ==  ");
				Console.WriteLine("            == ==   ==   ==      == ");
				Console.WriteLine("            ==  ==  ==   ==      == ");
				Console.WriteLine("            ==   == ==   ==      == ");
				Console.WriteLine("            ==    ====    ==    ==  ");
				Console.WriteLine("            ==     ===      ====    ");
				Console.WriteLine();
				Console.WriteLine("            =====    ======        ==        ==     ");
				Console.WriteLine("            ==   =   ==           ====       ==     ");
				Console.WriteLine("            ==    =  ==          ==  ==      ==     ");
				Console.WriteLine("            ==    =  ======     ==    ==     ==     ");
				Console.WriteLine("            ==    =  ==        ==========    ==     ");
				Console.WriteLine("            ==   =   ==       ==        ==   ==     ");
				Console.WriteLine("            =====    ======  ==          ==  =======");
				Thread.Sleep(1000);
				Console.Clear();
				Thread.Sleep(500);
			}
			DoND.DoNDGameLoop();
		}


		// This will keep us playing and asking for us to pick a suitcase each time
		public static void DoNDGameLoop()
        {
			double[] prizes = DoND.InfoPrizes();
			int[] randIndexs = GetRandNums();
			double[] mixedPrizesValues = MixValues(prizes, randIndexs);
			//string[] prizeValuesDisplay = Values();
			string[] suitcasesNumsDisplay = DoND.GetSuit();
			

			do
			{
				DoND.Display(ref suitcasesNumsDisplay, ref mixedPrizesValues);
				DoND.YourCase(ref mixedPrizesValues, ref suitcasesNumsDisplay);
				
			} while (DoND.pickCaseStart);

			

			do
			{

				DoND.Display(ref suitcasesNumsDisplay, ref mixedPrizesValues);
				
				DoND.CheckInputGame(ref mixedPrizesValues, ref suitcasesNumsDisplay);
				Console.Clear();
				// Get input here after showing screen
			} while (DoND.playGame);
        }

		// Is used for picking the players first case to hold on to, before they start going through the rest of them.
		public static void YourCase(ref double[] prizeValue, ref string[] suitcaseValues)
        {
			Console.WriteLine($"Pick your case");
			string input = Console.ReadLine();
			
			switch (input)
			{
				case "1":
				case "2":
				case "3":
				case "4":
				case "5":
				case "6":
				case "7":
				case "8":
				case "9":
				case "10":
				case "11":
				case "12":
				case "13":
				case "14":
				case "15":
				case "16":
				case "17":
				case "18":
				case "19":
				case "20":
				case "21":
				case "22":
				case "23":
				case "24":
				case "25":
				case "26":
					int currentNum = int.Parse(input);
					currentNum = currentNum - 1;
					Console.WriteLine($"You picked suitcase {input}.");
					DoND.playerSuitcase = suitcaseValues[currentNum];
					DoND.indexOfPlayerSuitcase = currentNum;
					suitcaseValues[currentNum] = "";
					DoND.dondTotal += prizeValue[currentNum];
					DoND.gameCounter++;
					DoND.pickCaseStart = false;
					break;
				case "":

					break;
				default:
					Console.WriteLine("Number Not Valid,\nTry again");
					break;
			}
			Thread.Sleep(3500);
			Console.Clear();
		}


		// Mix up prizes
		public static double[] MixValues(double[] prizeArr, int[] indexArr)
        {
			double[] tempArr = new double[26];
			for (int i = 0; i < tempArr.Length; i++)
            {
				tempArr[i] = prizeArr[indexArr[i]];
            }

			return tempArr;
        }

		// pick random nums for index of prizes
		public static int[] GetRandNums()
        {
			int[] tenNums = { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
			Random rand = new Random();
			int tempIndex = 0;
			do
			{
				for (int i = 0; i < tenNums.Length; i++)
				{
					int temp = rand.Next(tenNums.Length);
					if (tenNums[0] != temp && tenNums[1] != temp && tenNums[2] != temp && tenNums[3] != temp && tenNums[4] != temp && tenNums[5] != temp && tenNums[6] != temp && tenNums[7] != temp && tenNums[8] != temp && tenNums[9] != temp && tenNums[10] != temp && tenNums[11] != temp && tenNums[12] != temp && tenNums[13] != temp && tenNums[14] != temp && tenNums[15] != temp && tenNums[16] != temp && tenNums[17] != temp && tenNums[18] != temp && tenNums[19] != temp && tenNums[20] != temp && tenNums[21] != temp && tenNums[22] != temp && tenNums[23] != temp && tenNums[24] != temp && tenNums[25] != temp)
					{
						if (tempIndex > 25)
						{
							break;
						}
						tenNums[tempIndex] = temp;
						tempIndex++;
					}
				}
			} while (tempIndex < 26);
			return tenNums;
		}

		

		// contains suitcase numbers
		public static string[] GetSuit()
        {
			string[] suitcases = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26" };
			return suitcases;
		}

		// contains prize info
		public static double[] InfoPrizes()
        {
			// 26 prizes
			double[] prizes = { 0.50, 1, 2, 5, 10, 20, 50, 100, 150, 200, 250, 500, 750, 1000, 2000, 3000, 4000, 5000, 10000, 15000, 20000, 50000, 75000, 100000, 200000, 250000 };
			return prizes;
        }

		// Fills the Screen with suitcases to pick from
		public static void Display(ref string[] arr, ref double[] prizeValue)
        {
			Console.WriteLine($"Contestent: {Program.chosenPlayer.firstName} {Program.chosenPlayer.lastName}.\nHas an interest in {Program.chosenPlayer.intrest}");
            Console.WriteLine($"      {arr[0].PadLeft(10).PadRight(10)}      {arr[1].PadLeft(10).PadRight(10)}      {arr[2].PadLeft(10).PadRight(10)}");
			Console.WriteLine($"                                                 ");
            Console.WriteLine($"      {arr[3].PadLeft(10).PadRight(10)}      {arr[4].PadLeft(10).PadRight(10)}      {arr[5].PadLeft(10).PadRight(10)}");
			Console.WriteLine($"                                                 ");
			Console.WriteLine($"      {arr[6].PadLeft(10).PadRight(10)}      {arr[7].PadLeft(10).PadRight(10)}      {arr[8].PadLeft(10).PadRight(10)}");
			Console.WriteLine($"                                                 ");
			Console.WriteLine($"      {arr[9].PadLeft(10).PadRight(10)}      {arr[10].PadLeft(10).PadRight(10)}      {arr[11].PadLeft(10).PadRight(10)}");
			Console.WriteLine($"                                                 ");
			Console.WriteLine($"      {arr[12].PadLeft(10).PadRight(10)}      {arr[13].PadLeft(10).PadRight(10)}      {arr[14].PadLeft(10).PadRight(10)}");
			Console.WriteLine($"                                                              ");
			Console.WriteLine($"      {arr[15].PadLeft(10).PadRight(10)}      {arr[16].PadLeft(10).PadRight(10)}      {arr[17].PadLeft(10).PadRight(10)}");
			Console.WriteLine($"                                                             ");
			Console.WriteLine($"      {arr[18].PadLeft(10).PadRight(10)}      {arr[19].PadLeft(10).PadRight(10)}      {arr[20].PadLeft(10).PadRight(10)}");
			Console.WriteLine($"                                                             ");
			Console.WriteLine($"      {arr[21].PadLeft(10).PadRight(10)}      {arr[22].PadLeft(10).PadRight(10)}      {arr[23].PadLeft(10).PadRight(10)}");
			Console.WriteLine($"                                                             ");
			Console.WriteLine($"      {arr[24].PadLeft(10).PadRight(10)}      {arr[25].PadLeft(10).PadRight(10)}                           ");
			Console.WriteLine($"                                                             ");
			Console.WriteLine($"                                                             ");
			
			if (DoND.pickCaseStart == false)
            {
				Console.WriteLine($"Your case number is: {DoND.playerSuitcase}");

            }
		}

		// gets string input for picking a suitcase to open
		public static string GetInput()
        {
			Console.WriteLine("What suitcase do you want to open?");
			string tempNum = Console.ReadLine();
			return tempNum;
        }

		// checks input from user for picking a suitcase to open
		public static void CheckInputGame(ref double[] prizeValue, ref string[] remainingValues)
        {
			Random rand = new Random();
			int tempEndCon = rand.Next(DoND.gameCounter, prizeValue.Length);
			string input = DoND.GetInput();
			
			switch (input)
            {
				case "1":
				case "2":
				case "3":
				case "4":
				case "5":
				case "6":
				case "7":
				case "8":
				case "9":
				case "10":
				case "11":
				case "12":
				case "13":
				case "14":
				case "15":
				case "16":
				case "17":
				case "18":
				case "19":
				case "20":
				case "21":
				case "22":
				case "23":
				case "24":
				case "25":
				case "26":
					int currentNum = int.Parse(input);
					currentNum = currentNum - 1;
					if (remainingValues[currentNum] == "")
					{
						Console.WriteLine("You have already picked that one,\nTry again.");
						input = "";
						break;
					}
					Console.WriteLine($"You picked suitcase {input},\nIt contains {prizeValue[currentNum]:c2}.");
					remainingValues[currentNum] = "";
					DoND.dondTotal += prizeValue[currentNum];
					prizeValue[currentNum] = 0;
					DoND.gameCounter++;
					break;
				case "":
					break;
				default:
					Console.WriteLine("Number Not Valid,\nTry again");
					break;
			}

			if (DoND.gameCounter > 5 && DoND.gameCounter == tempEndCon)
            {
				Banker(prizeValue);
				
            }

			if (DoND.gameCounter == 26)
            {
                DoND.EndsGame(prizeValue[indexOfPlayerSuitcase]);
            }
			Thread.Sleep(3500);
        }

		// Decides what the banker offers each time and ends game if you take deal
		public static void Banker(double[] arr)
        {
			double total = 0;
			for (int i = 0; i < arr.Length; i++)
            {
				total += arr[i];
            }
			double offer = total / arr.Length;
			
			bool tempRun = true;
			do
			{
				Console.WriteLine($"The Banker offers you {offer:c2}");
				Console.WriteLine("Will you take it?\nYes or No");
				string yesOrNo = Console.ReadLine();
				if (yesOrNo.ToLower() == "yes")
				{
					Console.WriteLine($"You take {offer:c2}");
					DoND.playGame = false;
					tempRun = false;
					Console.WriteLine($"Congratulations {Program.chosenPlayer.firstName} {Program.chosenPlayer.lastName}.");
					

				}
				else if (yesOrNo.ToLower() == "no")
				{
					Console.WriteLine("You keep playing");
					tempRun = false;
                }
                else
                {
					Console.WriteLine("Error,\nYes or No only please");
                }
			} while (tempRun);

        }

		// Ends without the banker
		public static void EndsGame(double prize)
        {
			Console.WriteLine($"You take {prize:c2}");
			DoND.playGame = false;
			Console.WriteLine($"Congratulations {Program.chosenPlayer.firstName} {Program.chosenPlayer.lastName}.");
			Thread.Sleep(4000);
		}

	}
}

