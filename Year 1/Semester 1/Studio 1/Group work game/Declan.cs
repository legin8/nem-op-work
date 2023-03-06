using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nigel_Ben_Declan_Zach
{
    internal class Declan
    {
        //This allows us to use these anywhere in the code to help us move around the level
        public static int x, y, maxXOfRoom, maxYOfRoom, minXOfRoom, minYOfRoom, exitOfLevelX, exitOfLevelY;
        //This turns all text to lower case
        public static string GetInput(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine().ToLower();
        }
        //This is the base movement of the floor and size.
        public static void Floor3(ref bool isStartOfLevel, ref int level)
        {
            bool keepGoing = true;
            if (isStartOfLevel)
            {
                Console.WriteLine("Level 3 Start at beginning");
                Nigel.lvl = "Level 3";
                Declan.x = 4;
                Declan.y = 1;
                Declan.exitOfLevelX = 4;
                Declan.exitOfLevelY = 4;
                Declan.maxXOfRoom = 4;
                Declan.maxYOfRoom = 9;
                Declan.minXOfRoom = 1;
                Declan.minYOfRoom = 1;
            }
            else
            {
                Console.WriteLine("Level 3 Start at end");
                Nigel.lvl = "Level 3";
                Declan.x = 4;
                Declan.y = 4;
                Declan.exitOfLevelX = 4;
                Declan.exitOfLevelY = 5;
                Declan.maxXOfRoom = 4;
                Declan.maxYOfRoom = 9;
                Declan.minXOfRoom = 1;
                Declan.minYOfRoom = 1;
            }

            do
            {
                string input = GetInput("==============================\nMovement\n==============================\nType either\nN for North\nS for South\nE for East\nW for West");

                // Magic Potion Feature call
                Nigel.PotionMovement(ref input);

                switch (input)
                {
                    case "n":

                        Nigel.North();
                        L3();
                        break;

                    case "s":

                        Nigel.South();
                        L3();
                        break;
                    case "e":

                        Nigel.East();
                        L3();
                        break;
                    case "w":

                        Nigel.West();
                        L3();
                        break;

                    case "help":
                        Ben.Help();
                        break;

                    default:
                        Console.WriteLine("Sorry???");
                        Console.WriteLine("Look if you are seeing this then you typed something wrong,\nTry again.");
                        break;
                }

                if (Nigel.x == Nigel.exitOfLevelX && Nigel.y == Nigel.exitOfLevelY)
                {
                    Console.WriteLine("You have Cleared Level 2");
                    Console.ReadLine();
                    level = 2;
                    isStartOfLevel = true;
                    keepGoing = false;
                }
                //Console.WriteLine($"\nNorth: {canNorth}\nSouth: {canSouth}\nEast: {canEast}\nWest: {canWest}\n");
                Thread.Sleep(1000);

            } while (keepGoing);

        }
        //This is how you move around the floor to get around the level
        public static void L3()
        {
            int randdoor;
            Random rand = new Random();
            randdoor = rand.Next(4);

            if (Declan.x == 1 && Declan.y == 1)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = false;
                Nigel.canEast = false;
                Nigel.canWest = false;
                Console.WriteLine("While digging in the room you found a clue to who is behind the disappearances and put it in your bag. The clue is:\nWas a living Being");
                
            }
            else if (Declan.x == 2 && Declan.y == 1)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = false;
                Nigel.canEast = false;
                Nigel.canWest = false;
                Console.WriteLine("There is moonlight seeping through the curtain.\nMoonlight illuminated the room.");

            }
            else if (Declan.x == 3 && Declan.y == 1)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = false;
                Nigel.canEast = true;
                Nigel.canWest = false;
                
            }
            else if (Declan.x == 4 && Declan.y == 1)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = false;
                Nigel.canEast = false;
                Nigel.canWest = true;
                
            }
            else if (Declan.x == 1 && Declan.y == 2)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = false;
                Nigel.IfInMagicRoom();
                Nigel.PotionInRoom();
                // room with Magic Potion
            }
            else if (Declan.x == 2 && Declan.y == 2)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = true;
            }
            else if (Declan.x == 3 && Declan.y == 2)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = false;
                Nigel.canEast = true;
                Nigel.canWest = true;
            }
            else if (Declan.x == 4 && Declan.y == 2)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = true;
            }
            else if (Declan.x == 1 && Declan.y == 3)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = false;
                Nigel.canEast = true;
                Nigel.canWest = false;
            }
            else if (Declan.x == 2 && Declan.y == 3)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = true;
            }
            else if (Declan.x == 3 && Declan.y == 3)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = false;
                Nigel.canEast = false;
                Nigel.canWest = true;
            }
            else if (Declan.x == 4 && Declan.y == 3)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = false;
                Nigel.IfInMagicRoom();
                Nigel.PotionInRoom();
                // room with Magic Potion
            }
            else if (Declan.x == 1 && Declan.y == 4)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = false;
                Nigel.canEast = true;
                Nigel.canWest = false;
            }
            else if (Declan.x == 2 && Declan.y == 4)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = false;
            }
            else if (Declan.x == 3 && Declan.y == 4)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = false;
                Nigel.canEast = false;
                Nigel.canWest = false;
                Nigel.IfInMagicRoom();
                Nigel.PotionInRoom();
                // room with Magic Potion
            }
            else if (Declan.x == 4 && Declan.y == 4)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = false;
            }
            else if (Declan.x == 1 && Declan.y == 5)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = false;
                Nigel.canEast = true;
                Nigel.canWest = false;
            }
            else if (Declan.x == 2 && Declan.y == 5)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = true;
            }
            else if (Declan.x == 3 && Declan.y == 5)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = true;
            }
            else if (Declan.x == 4 && Declan.y == 5)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = false;
                Nigel.canEast = false;
                Nigel.canWest = true;
            }
            else if (Declan.x == 1 && Declan.y == 6)
            {
                if (randdoor == 0)
                {
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
                } 
                else
                {
                    Nigel.canNorth = false;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
                }
            }
            else if (Declan.x == 2 && Declan.y == 6)
            {
                if (randdoor == 1)
                {
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
                }
                else
                {
                    Nigel.canNorth = false;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
                }
            }
            else if (Declan.x == 3 && Declan.y == 6)
            {
                if (randdoor == 2)
                {
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
                }
                else
                {
                    Nigel.canNorth = false;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
                }
            }
            else if (Declan.x == 4 && Declan.y == 6)
            {
                if (randdoor == 3)
                {
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
                }
                else
                {
                    Nigel.canNorth = false;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
                }
                //this is now one room that you can move around in called the Library
            }
            else if (Declan.x == 1 && Declan.y == 7)
            {
                if (randdoor == 0)
                {
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = true;
                    Nigel.canWest = false;
                }
                else
                {
                    Nigel.canNorth = false;
                    Nigel.canSouth = true;
                    Nigel.canEast = true;
                    Nigel.canWest = false;
                }
            }
            else if (Declan.x == 2 && Declan.y == 7)
            {
                if (randdoor == 0)
                {
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = true;
                    Nigel.canWest = true;
                }
                else
                {
                    Nigel.canNorth = true;
                    Nigel.canSouth = false;
                    Nigel.canEast = true;
                    Nigel.canWest = true;
                }
            }
            else if (Declan.x == 3 && Declan.y == 7)
            {
                if (randdoor == 0)
                {
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = true;
                    Nigel.canWest = true;
                }
                else
                {
                    Nigel.canNorth = true;
                    Nigel.canSouth = false;
                    Nigel.canEast = true;
                    Nigel.canWest = true;
                }
            }
            else if (Declan.x == 4 && Declan.y == 7)
            {
                if (randdoor == 0)
                {
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = true;
                }
                else
                {
                    Nigel.canNorth = true;
                    Nigel.canSouth = false;
                    Nigel.canEast = false;
                    Nigel.canWest = true;
                }
            }
            else if (Declan.x == 1 && Declan.y == 8)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = false;
            }
            else if (Declan.x == 2 && Declan.y == 8)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = true;
            }
            else if (Declan.x == 3 && Declan.y == 8)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = true;
            }
            else if (Declan.x == 4 && Declan.y == 8)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = true;
            }
            else if (Declan.x == 1 && Declan.y == 9)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = true;
            }
            else if (Declan.x == 2 && Declan.y == 9)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = true;
            }
            else if (Declan.x == 3 && Declan.y == 9)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = true;
            }
            else if (Declan.x == 4 && Declan.y == 9)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = true;
            }
            else
            {
                Console.WriteLine("Error x and y, check bools");
            }
        }   
    }
}
