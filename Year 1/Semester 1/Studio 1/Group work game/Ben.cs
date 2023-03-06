using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Nigel_Ben_Declan_Zach
{
    internal class Ben
    {
        //public static void Story()
        //{
        //    Console.WriteLine("Adventure Haunted Mansion Game");
        //    Console.WriteLine("The story beings by you the player are a paranormal investigator who is looking into a case of missing people who have been lost for decades and the only clue to any of there disappearance was them last going to this Mansion. \nYou walk up the steps feeling anxious and slowly open the big massive doors. As soon as you walk in the doors slam shut and won't open back up.");
        //    Console.ReadLine();
        //}

        public static int x, y, maxXOfRoom, maxYOfRoom, minXOfRoom, minYOfRoom, exitOfLevelX, exitOfLevelY;
        public static string lvl;
        public static bool woodenKey = false, metalKey = false, boneKey = false, key = false, food = false, water = false, playGame = true;

        //this determines the starting point and the end point of the level
        public static void Level2(bool isStartOfLevel = true)
        {
            if (isStartOfLevel)
            {
                Console.WriteLine("Level 2 Start at beginning");
                Ben.lvl = "Level 2";
                Ben.x = 1;
                Ben.y = 1;
                Ben.exitOfLevelX = 4;
                Ben.exitOfLevelY = 5;
                Ben.maxXOfRoom = 4;
                Ben.maxYOfRoom = 9;
                Ben.minXOfRoom = 1;
                Ben.minYOfRoom = 1;
            }
            else
            {
                Console.WriteLine("Level 1 Start at end");
                Nigel.lvl = "Level 1";
                Ben.x = 2;
                Ben.y = 7;
                Ben.exitOfLevelX = 4;
                Ben.exitOfLevelY = 5;
                Ben.maxXOfRoom = 4;
                Ben.maxYOfRoom = 9;
                Ben.minXOfRoom = 1;
                Ben.minYOfRoom = 1;
            }
        }
        //this method involves the "Help" method for when something needs help with something
        public static void Help()
        {
            Console.WriteLine("The Help info");
            Console.WriteLine();
            Console.WriteLine("The Basic Movements involve moving North, South, East, West. \nTo input these Movements just type in the corresponding direction or beginning or letter (eg. West or W) ");
            Console.WriteLine();
            Console.WriteLine("You are able to grab various objects. Throughout the game we will hint towards certain objects in room, you may be able to grab it and it may help you in the future. \nTry the command 'Grab *blank*'");
            Console.WriteLine("You do have a limited inventory space, so be careful!");
            Console.WriteLine("You can always check your inventory at any time! Just type 'Inventory' to check.");
            Console.WriteLine();
            Console.WriteLine("Unlocking locks is an option in this game, if you think you have a 'Key' you can try to unlock it using 'Unlock Lock'.");
            Console.WriteLine("It may ask you for which key if you happen to have multiple. Just type the Key you have to try it.");
        }
        //the inventory system which determines if you have the item
        public static void inventory()
        {
            Console.WriteLine("The items in your inventory include:");
            if (woodenKey == true)
            {
                Console.WriteLine("Wooden Key");
            }
            if (boneKey == true)
            {
                Console.WriteLine("Bone Key");
            }
            if (metalKey == true)
            {
                Console.WriteLine("Metal Key");
            }
        }
        //the main code for the floor calling all of the static voids
        public static void Floor2(ref bool isStartOfLevel, ref int level)
        {
            string Staircase;
            Staircase = "You reached the top of the staircase, you look around and see...";
            bool keepGoing = true;
            Console.WriteLine("You entered the second story of the mansion, the floor boards creek as you look around.");
            Ben.Level2(isStartOfLevel);
            do
            {
                string input = Nigel.GetInput("==============================\nMovement\n==============================\nType either\nN for North\nS for South\nE for East\nW for West");
                //movement system

                // Magic Potion Feature call
                Nigel.PotionMovement(ref input);

                switch (input)
                {
                    case "n":
                        Ben.North();
                        L1R1();
                        break;

                    case "s":
                        Ben.South();
                        L1R1();
                        break;
                    case "e":
                        Ben.East();
                        L1R1();
                        break;
                    case "w":
                        Ben.West();
                        L1R1();
                        break;

                    case "help":
                        Ben.Help();
                        break;

                    case "inventory":
                        Ben.inventory();
                        break;
                        //grab command this determines if in the correct room can grab a certain object
                    case "grab":
                        if (Ben.x == 4 && Ben.y == 1)
                        {
                            Console.WriteLine("You grabbed the wooden key");
                            Console.WriteLine("The key says '11'");
                            woodenKey = true;
                        }
                        else if (Ben.x == 2 && Ben.y == 9)
                        {
                            Console.WriteLine("You grabbed the metal key");
                            Console.WriteLine("The key says '8'");
                            metalKey = true;
                        }
                        else if (Ben.x == 1 && Ben.y == 5)
                        {
                            Console.WriteLine("You grabbed the bone key");
                            Console.WriteLine("The key says '26'");
                            boneKey = true;
                        }
                        else if (Ben.x == 1 && Ben.y == 4)
                        {
                            food = true;
                            water = true;
                        }
                        else
                        {
                            Console.WriteLine("Didn't grab anything");
                        }
                        break;
                        //error
                    default:
                        Console.WriteLine("Sorry???");
                        Console.WriteLine("Look if you are seeing this then you typed something wrong,\nTry again.");
                        break;
                }
                //if the level is beaten
                if (Ben.x == Ben.exitOfLevelX && Ben.y == Ben.exitOfLevelY)
                {
                    Console.WriteLine($"You have Cleared {Ben.lvl}");
                    Console.ReadLine();
                    level = 3;
                    isStartOfLevel = true;
                    keepGoing = false;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (keepGoing);
        }
        //all of the places to go and where you can go
        public static void L1R1()
        {
            Thread.Sleep(2000);
            Console.Clear();
            if (Ben.x == 1 && Ben.y == 1)
            {
                    Nigel.canNorth = true;
                    Nigel.canSouth = false;
                    Nigel.canEast = true;
                    Nigel.canWest = false;
                Console.WriteLine("There is a door North of you");
                Console.WriteLine("The hall goes on East");
            }
            else if (Ben.x == 2 && Ben.y == 1)
            {
                    Nigel.canNorth = true;
                    Nigel.canSouth = false;
                    Nigel.canEast = true;
                    Nigel.canWest = true;
                Console.WriteLine("You stare at the long hallway in front of you.");
                Console.WriteLine("The hall goes on North and West.");
                Console.WriteLine("There is a door to your East.");
            }
            else if (Ben.x == 3 && Ben.y == 1)
            {
                Console.WriteLine("You enter a pitch black room. It is too dark to see anything.");
                    Nigel.canNorth = false;
                    Nigel.canSouth = false;
                    Nigel.canEast = true;
                    Nigel.canWest = false;
            }
            else if (Ben.x == 4 && Ben.y == 1)
            {
                Console.WriteLine("You enter a dimly light room, there is something shining on the ground... it looks like a Wooden Key.");
                Console.WriteLine("You notice there is no where else to go but back where you came from.");
                    Nigel.canNorth = true;
                    Nigel.canSouth = false;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
            }
            else if (Ben.x == 1 && Ben.y == 2)
            {
                    Nigel.canNorth = false;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
                Console.WriteLine("You enter a nearly dark room. The only thing you can see is a faint trace of a curtain.");
            }
            else if (Ben.x == 2 && Ben.y == 2)
            {
                Console.WriteLine("The hall goes on North and South");
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
            }
            else if (Ben.x == 3 && Ben.y == 2)
            {
                Console.WriteLine("You enter a very dead empty room.");
                    Nigel.canNorth = true;
                    Nigel.canSouth = false;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
                
            }
            else if (Ben.x == 4 && Ben.y == 2)
            {
                Console.WriteLine("You enter threw the door and notice another door.");
                Console.WriteLine("There is a door to your North and your South");
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
                Nigel.IfInMagicRoom();
                Nigel.PotionInRoom();
                // room with Magic Potion
            }
            else if (Ben.x == 1 && Ben.y == 3)
            {
                    Nigel.canNorth = false;
                    Nigel.canSouth = false;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
            }
            else if (Ben.x == 2 && Ben.y == 3)
            {
                Console.WriteLine("The hall goes on North, East, and South");
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = true;
                    Nigel.canWest = false;
            }
            else if (Ben.x == 3 && Ben.y == 3)
            {
                Console.WriteLine("You turned down the hallway.");
                Console.WriteLine("The hall goes on East and West");
                Console.WriteLine("There is a door South of you.");
                    Nigel.canNorth = false;
                    Nigel.canSouth = true;
                    Nigel.canEast = true;
                    Nigel.canWest = true;
            }
            else if (Ben.x == 4 && Ben.y == 3)
            {
                Console.WriteLine("You reach the end of this hallway.");
                Console.WriteLine("The hall goes on West");
                Console.WriteLine("There is a door to your North and your South");
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = true;
            }
            else if (Ben.x == 1 && Ben.y == 4)
            {
                Console.WriteLine("You entered the room, it was lighted and all you see is a bottle of water, and some food.");
                Console.WriteLine("You can only go back the way you came.");
                    Nigel.canNorth = false;
                    Nigel.canSouth = false;
                    Nigel.canEast = true;
                    Nigel.canWest = false;
            }
            else if (Ben.x == 2 && Ben.y == 4)
            {
                Console.WriteLine("You are about halfway down the long hallway.");
                Console.WriteLine("The hall goes on North and South of you");
                Console.WriteLine("There is a door to the East and West");
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = true;
                    Nigel.canWest = true;
            }
            else if (Ben.x == 3 && Ben.y == 4)
            {
                Console.WriteLine("You entered a dark pitch black room. You can't see anything.");
                    Nigel.canNorth = false;
                    Nigel.canSouth = false;
                    Nigel.canEast = false;
                    Nigel.canWest = true;
            }
            else if (Ben.x == 4 && Ben.y == 4)
            {
                Console.WriteLine("You entered a room, it was lighted up, but there was nothing to be seen.");
                    Nigel.canNorth = false;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
            }
            else if (Ben.x == 1 && Ben.y == 5)
            {
                Console.WriteLine("You entered a dimly lighted room. You notice some bones on the ground, until you realize some of them form a key.");
                    Nigel.canNorth = false;
                    Nigel.canSouth = false;
                    Nigel.canEast = true;
                    Nigel.canWest = false;
            }
            else if (Ben.x == 2 && Ben.y == 5)
            {
                Console.WriteLine("The hallway seems to get closer to the end.");
                Console.WriteLine("The hall goes on North and South of you");
                Console.WriteLine("There is a door to your East and West");
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = true;
                    Nigel.canWest = true;
            }
            else if (Ben.x == 3 && Ben.y == 5)
            {
                Console.WriteLine("You entered a larger than normal room. Its a wide room, empty with tables and chairs.");
                Console.WriteLine("You see 2 big doors to your East, you can also go North");
                    Nigel.canNorth = true;
                    Nigel.canSouth = false;
                if (woodenKey == true)
                {
                    Nigel.canEast = true;
                }
                else
                {
                    Console.WriteLine("The door is locked, there is a riddle on the door.");
                    Console.WriteLine("It reads, 'How many letters are in The Alphabet?'");
                    Nigel.canEast = false;
                }
                    Nigel.canWest = true;
            }
            else if (Ben.x == 4 && Ben.y == 5)
            {
                    Nigel.canNorth = true;
                    Nigel.canSouth = false;
                    Nigel.canEast = false;
                    Nigel.canWest = true;
            }
            else if (Ben.x == 1 && Ben.y == 6)
            {
                    Nigel.canNorth = false;
                    Nigel.canSouth = false;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
            }
            else if (Ben.x == 2 && Ben.y == 6)
            {
                Console.WriteLine("The hallway continues.");
                Console.WriteLine("The hall goes on North and South");
                Console.WriteLine("There is a door to your East");
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = true;
                    Nigel.canWest = false;
            }
            else if (Ben.x == 3 && Ben.y == 6)
            {
                Console.WriteLine("You entered a larger than normal room. Its a wide room empty with tables and chairs.");
                Console.WriteLine("You see 2 big doors to your East, you can also go South");
                    Nigel.canNorth = false;
                    Nigel.canSouth = true;
                    Nigel.canEast = true;
                    Nigel.canWest = true;
            }
            else if (Ben.x == 4 && Ben.y == 6)
            {
                    Nigel.canNorth = false;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = true;
            }
            else if (Ben.x == 1 && Ben.y == 7)
            {
                Console.WriteLine("You enter a dimly lighted room. You look around to see what looks like nothing.");
                    Nigel.canNorth = true;
                    Nigel.canSouth = false;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
                Nigel.IfInMagicRoom();
                Nigel.PotionInRoom();
                // room with Magic Potion
            }
            else if (Ben.x == 2 && Ben.y == 7)
            {
                Console.WriteLine("You are almost at the end of the hallway.");
                Console.WriteLine("The hall goes on North and South");
                Console.WriteLine("There is a door to your East");
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = true;
                    Nigel.canWest = false;
            }
            else if (Ben.x == 3 && Ben.y == 7)
            {
                Console.WriteLine("The room is pitch black, you can't see anything.");
                    Nigel.canNorth = false;
                    Nigel.canSouth = false;
                    Nigel.canEast = false;
                    Nigel.canWest = true;
                Nigel.IfInMagicRoom();
                Nigel.PotionInRoom();
                // room with Magic Potion
            }
            else if (Ben.x == 4 && Ben.y == 7)
            {
                Console.WriteLine("A bright light fills the room, but you seem nothing helpful.");
                    Nigel.canNorth = true;
                    Nigel.canSouth = false;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
                Console.WriteLine("While digging in the room you found a clue to who is behind the disappearances and put it in your bag. \n The clue is:\n 'Was in a comic'");
            }
            else if (Ben.x == 1 && Ben.y == 8)
            {
                Console.WriteLine("You reach the end of the hallway");
                Console.WriteLine("There is a door to your North and South");
                Console.WriteLine("The hall goes on East");
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = true;
                    Nigel.canWest = false;
            }
            else if (Ben.x == 2 && Ben.y == 8)
            {
                Console.WriteLine("The hall goes on East, South and West");
                Console.WriteLine("There is a door to your North");
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = true;
                    Nigel.canWest = true;
            }
            else if (Ben.x == 3 && Ben.y == 8)
            {
                Console.WriteLine("You continue down the hallway.");
                Console.WriteLine("The hall goes on East and West");
                    Nigel.canNorth = false;
                    Nigel.canSouth = false;
                    Nigel.canEast = true;
                    Nigel.canWest = true;
            }
            else if (Ben.x == 4 && Ben.y == 8)
            {
                Console.WriteLine("Theres a wall to your right.");
                Console.WriteLine("The hall goes on North and West");
                Console.WriteLine("There is a door to your South");
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = true;
            }
            else if (Ben.x == 1 && Ben.y == 9)
            {
                Console.WriteLine("You enter a pitch black room. You can't see anything, no visible doors, or windows, or items around you.");
                    Nigel.canNorth = false;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
            }
            else if (Ben.x == 2 && Ben.y == 9)
            {
                Console.WriteLine("You enter a pitch black room, you can faintly make out something metal at the edge of the room.");
                    Nigel.canNorth = false;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
            }
            else if (Ben.x == 3 && Ben.y == 9)
            {
                Console.WriteLine("The room you entered has a bright light but you see nothing of use in here.");
                    Nigel.canNorth = false;
                    Nigel.canSouth = false;
                    Nigel.canEast = true;
                    Nigel.canWest = false;
            }
            else if (Ben.x == 4 && Ben.y == 9)
            {
                Console.WriteLine("You reached the end of the hallway.");
                Console.WriteLine("The hall goes on South");
                Console.WriteLine("There is a door to your West");
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

        // Move North
        // Only Moves North if you can move that way
        public static void North()
        {
            if (Ben.y < Ben.maxYOfRoom && Nigel.canNorth)
            {
                Ben.y++;
                Console.WriteLine("You moved North");
            }
            else
            {
                Console.WriteLine("You Walked straight into the wall,\nReal Smart Move there");
            }
        }

        // Move South
        // Only Moves South if you can move that way
        public static void South()
        {
            if (Ben.y > Ben.minYOfRoom && Nigel.canSouth)
            {
                Ben.y--;
                Console.WriteLine("You moved South");
            }
            else
            {
                Console.WriteLine("You Walked straight into the wall,\nReal Smart Move there");
            }
        }

        // Move East
        // Only Moves East if you can move that way
        public static void East()
        {
            if (Ben.x < Ben.maxXOfRoom && Nigel.canEast)
            {
                Ben.x++;
                Console.WriteLine("You moved East");
            }
            else
            {
                Console.WriteLine("You Walked straight into the wall,\nReal Smart Move there");
            }
        }

        // Move West
        // Only Moves West if you can move that way
        public static void West()
        {
            if (Ben.x > Ben.minXOfRoom && Nigel.canWest)
            {
                Ben.x--;
                Console.WriteLine("You moved West");
            }
            else
            {
                Console.WriteLine("You Walked straight into the wall,\nReal Smart Move there");
            }
        }
    }
}
