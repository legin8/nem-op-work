using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/*
 * What do we want on screen at any given time.
 * Show Inv and Where you are. Show stuff within a distance.
 * 
 * Tutorial?
 * Just a help/ info command all commands.
 * 
 * 
 * How will we interact with the inventory/ pick things up and put them down and use them, Carry limit?
 * Pick up only some items, who you are depends what you can pick up. Carry limit?
 * 
 * What code goes in the Program.cs? utility only?
 * Still to decide, Keep seperate for now.
 * 
 * 
 * Make a Timeline for what we should be doing.
 * 
 * Start by making the utility code that we can all use and understand it.
 * 
 * Or Colaborate by copying your own code and pasting it in someone elses file, Only with permission and saying when you are doing it.
 * 
 * Should we write a script?
 * What happens before, how we got there, the story of the house and how we get out.
 * 
 * Intro, Middnight, howling wolves ect.
 * The goal could be to get to the roof, still to figure out lore.
 * 
 * 
 * 
 * 
 * 
 * 
 * 
*/


namespace Nigel_Ben_Declan_Zach
{
    internal class Nigel
    {
        // static class variables, not sure if any of you want to use these or make your own. Its up to you as will
        // reassign when, my code needs them.
        // Location ints
        public static int x, y, exitOfLevelX, exitOfLevelY, maxXOfRoom, maxYOfRoom, minXOfRoom, minYOfRoom;
        // Magic Potion Feature
        public static int magicDrinkCount;
        // strings needed for level main
        public static string lvl;
        //Navigation bools
        public static bool canWest = true, canEast = true, canSouth = true, canNorth = true;
        // GameLoop, Keys and Food
        public static bool playGame = true, level1hasKey = false, FoodLevel1 = true;
        // Magic Potion Feature bools
        public static bool hasUsedMagicDrink = false, isMagicRoom = false;
        

        // Helper function for GameLoop
        // gets input from user and returns as lower case text string
        public static string GetInput(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine().ToLower();
        }







        // Declan this is what you need in your class file to run your level, just refactor it.
        // Declan us this method below-----------------------------

        // This is the Game Loop that will keep asking for input and let the player use commands to move and interact with food and keys
        // Also help and inventory commands

        public static void Floor1(ref bool isStartOfLevel, ref int level)
        {
            bool keepGoing = true;

            Nigel.Level1(isStartOfLevel);
            if (isStartOfLevel)
            {
                Zach.intro();
                Console.Clear();
                Console.WriteLine("You Stand just inside the front door of the mansion\nThere is a door to you left and a hallway in front of you.");
            } else
            {
                Console.WriteLine("You return to the first floor from the second floor and enter the Hallway");
            }
            
            do
            {
                string input = Nigel.GetInput("==============================\nMovement\n==============================\nType either\nN for North\nS for South\nE for East\nW for West");
                // This calls the methods for the Magic Potion Feature (Made by Nigel Maynard)
                PotionMovement(ref input);

                switch (input)
                {
                    case "n":
                    case "north":
                        Nigel.North();
                        Floor1Positions();
                        break;
                    
                    case "s":
                    case "south":
                        Nigel.South();
                        Floor1Positions();
                        break;
                    case "e":
                    case "east":
                        Nigel.East();
                        Floor1Positions();
                        break;
                    case "w":
                    case "west":
                        Nigel.West();
                        Floor1Positions();
                        break;
                    case "inventory":
                    case "inv":
                    case "i":
                        Ben.inventory();
                        break;

                    case "help":
                    case "h":
                    case "?":
                        Ben.Help();
                        break;
                    case "grab":
                    case "pick up":
                    case "take key":
                    case "take":
                    case "get key":
                    case "get":
                        if (!level1hasKey && Nigel.x == 2 && Nigel.y == 1)
                        {
                            Console.WriteLine("You pick up the key");
                            Nigel.level1hasKey = true;
                        } else
                        {
                            Console.WriteLine("You have already picked up the key");
                        }
                        if (FoodLevel1 && Nigel.x == 3 && Nigel.y == 2)
                        {
                            Console.WriteLine("You eat the food");
                            Nigel.FoodLevel1 = false;
                        }

                        break;
                    case "ml":
                        Console.WriteLine($"You have Cleared {Nigel.lvl}");
                        Console.WriteLine("You find yourself in the attic");
                        Console.ReadLine();
                        level = 4;
                        isStartOfLevel = true;
                        keepGoing = false;
                        break;
                        // All of these up until the break are options for calling the Method that will Start my feature if in a room with,
                        // a magic potion.
                        // There are so many options so the game play is less restrictive.
                    case "drink":
                    case "drink magic potion":
                    case "drink magic":
                    case "drink potion":
                    case "use magic potion":
                    case "use magic":
                    case "use potion":
                    case "swallow potion":
                    case "swallow":
                    case "consume magic potion":
                    case "consume potion":
                        Nigel.MagicDrink();
                        break;
                    case "quit":
                        Console.WriteLine("Exiting to Main Menu");
                        Nigel.playGame = false;
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Sorry???");
                        Console.WriteLine("Look if you are seeing this then you typed something wrong,\nTry again.");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }

                if (Nigel.x == Nigel.exitOfLevelX && Nigel.y == Nigel.exitOfLevelY)
                {
                    Console.WriteLine($"You have Cleared {Nigel.lvl}");
                    Console.ReadLine();
                    level = 2;
                    isStartOfLevel = true;
                    keepGoing = false;
                }
                //Console.WriteLine($"\nNorth: {canNorth}\nSouth: {canSouth}\nEast: {canEast}\nWest: {canWest}\n");
                Thread.Sleep(1000);
                
                if (Nigel.magicDrinkCount > 0) Nigel.magicDrinkCount--;
                
            } while (keepGoing);

        }

        // Declan This method above here------------





        // logic for Start of Level 1
        // Sets the default values for the start of the level and the end of the level if we were to ever add the ability to go down It would set the default values
        public static void Level1(bool isStartOfLevel = true)
        {
            if (isStartOfLevel)
            {
                //Console.WriteLine("For Testing Level 1 Start at beginning");
                Nigel.lvl = "Level 1";
                Nigel.x = 4;
                Nigel.y = 1;
                Nigel.exitOfLevelX = 2;
                Nigel.exitOfLevelY = 7;
                Nigel.maxXOfRoom = 4;
                Nigel.maxYOfRoom = 9;
                Nigel.minXOfRoom = 1;
                Nigel.minYOfRoom = 1;
                Nigel.canNorth = true;
                Nigel.canSouth = false;
                Nigel.canEast = false;
                Nigel.canWest = true;

                // example for Declan
                // Random rand = new Random();
                // int roomRand = rand.Next(4);
                // this picks a random number and you can assign each door a number and if the number is it, then unlock the door.
            } else
            {
                Console.WriteLine("Level 1 Start at end");
                Nigel.lvl = "Level 1";
                Nigel.x = 1;
                Nigel.y = 7;
                Nigel.exitOfLevelX = 5;
                Nigel.exitOfLevelY = 4;
                Nigel.maxXOfRoom = 4;
                Nigel.maxYOfRoom = 9;
                Nigel.minXOfRoom = 1;
                Nigel.minYOfRoom = 1;
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = false;
            }


        }

        // Level 1 room 1
        // Changes the bool depending on where you are, Stops you from walking through walls.
        // This is based on a 8 X 8 grid but can be changed for any size.
        // Y 9, X 4
        // 4 across 9 up
        public static void Floor1Positions()
        {
            Thread.Sleep(1100);
            Console.Clear();
            if (Nigel.x == 1 && Nigel.y == 1)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = false;
                Nigel.canEast = true;
                Nigel.canWest = false;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on North of you");
                Nigel.DoorEast();
                // Hall
            }
            else if (Nigel.x == 2 && Nigel.y == 1)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = false;
                Nigel.canEast = false;
                Nigel.canWest = true;
                if (!level1hasKey)
                {
                    Console.WriteLine("You are in a small room");
                    Console.WriteLine("You see a key on the ground\nYou think to yourself, I may need that key");
                    Console.WriteLine("The exit is west of you");
                } else
                {
                    Nigel.EmptyRoom();
                    Console.WriteLine("The exit is west of you");
                }
                // Room with key
            }
            else if (Nigel.x == 3 && Nigel.y == 1)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = false;
                Nigel.canEast = true;
                Nigel.canWest = false;
                Nigel.DarkEmptyRoom();
                Console.WriteLine("The exit is east of you");
                // Room No light
            }
            else if (Nigel.x == 4 && Nigel.y == 1)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = false;
                Nigel.canEast = false;
                Nigel.canWest = true;
                Nigel.Hallway();
                Nigel.DoorWest();
                Console.WriteLine("The hall goes on North of you");
                // Hall / starting point, start of game only
            }
            else if (Nigel.x == 1 && Nigel.y == 2)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = false;
                Nigel.Hallway();
                Nigel.DoorEast();
                Console.WriteLine("The hall goes on North and South of you");
                // hall
            }
            else if (Nigel.x == 2 && Nigel.y == 2)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = false;
                Nigel.canEast = false;
                Nigel.canWest = true;
                Console.WriteLine("The exit is west of you");
                IfInMagicRoom();
                PotionInRoom();
                // room with Magic Potion
            }
            else if (Nigel.x == 3 && Nigel.y == 2)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = false;
                Nigel.canEast = true;
                Nigel.canWest = false;
                if (FoodLevel1)
                {
                    Console.WriteLine("You are in a small room");
                    Console.WriteLine("You see food on the floor");
                    Console.WriteLine("The exit is east of you");
                } else
                {
                    Nigel.EmptyRoom();
                    Console.WriteLine("The exit is west of you");
                }
                // room with food
            }
            else if (Nigel.x == 4 && Nigel.y == 2)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = true;
                Nigel.Hallway();
                Nigel.DoorWest();
                Console.WriteLine("The hall goes on North and South of you");
                // hall
            }
            else if (Nigel.x == 1 && Nigel.y == 3)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = false;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on North, South and East of you");
                // hall
            }
            else if (Nigel.x == 2 && Nigel.y == 3)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = false;
                Nigel.canEast = true;
                Nigel.canWest = true;
                Nigel.Hallway();
                Nigel.DoorNorth();
                Console.WriteLine("The hall goes on East and West of you");
                // hall
            }
            else if (Nigel.x == 3 && Nigel.y == 3)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = false;
                Nigel.canEast = true;
                Nigel.canWest = true;
                Nigel.Hallway();
                Nigel.DoorNorth();
                Console.WriteLine("The hall goes on East and West of you");
                // hall
            }
            else if (Nigel.x == 4 && Nigel.y == 3)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = true;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on North, South and West of you");
                // hall
            }
            else if (Nigel.x == 1 && Nigel.y == 4)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = false;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on North and South of you");
                // hall
            }
            else if (Nigel.x == 2 && Nigel.y == 4)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = false;
                Nigel.EmptyRoom();
                Console.WriteLine("The exit is south of you");
                // room empty
            }
            else if (Nigel.x == 3 && Nigel.y == 4)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = false;
                Console.WriteLine("You find a clue for what haunts this Mansion:\nWas in a popular TV show");
                Console.WriteLine("The exit is south of you");
                // room clue
            }
            else if (Nigel.x == 4 && Nigel.y == 4)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = false;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on North and South of you");
                // hall
            }
            else if (Nigel.x == 1 && Nigel.y == 5)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = false;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on North and South of you");
                // hall
            }
            else if (Nigel.x == 2 && Nigel.y == 5)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = false;
                Nigel.canEast = false;
                Nigel.canWest = false;
                Console.WriteLine("The exit is north of you");
                IfInMagicRoom();
                PotionInRoom();
                // room with Magic Potion
            }
            else if (Nigel.x == 3 && Nigel.y == 5)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = false;
                Nigel.canEast = false;
                Nigel.canWest = false;
                Nigel.EmptyRoom();
                Console.WriteLine("The exit is north of you");
                // empty room
            }
            else if (Nigel.x == 4 && Nigel.y == 5)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = false;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on North and South of you");
                // hall
            }
            else if (Nigel.x == 1 && Nigel.y == 6)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = false;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on North, South and East of you");
                // hall
            }
            else if (Nigel.x == 2 && Nigel.y == 6)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = true;
                Nigel.Hallway();
                Nigel.DoorSouth();
                Console.WriteLine("The hall goes on East and West of you");
                // hall
            }
            else if (Nigel.x == 3 && Nigel.y == 6)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = true;
                Nigel.Hallway();
                Nigel.DoorSouth();
                Console.WriteLine("The hall goes on East and West of you");
                // hall
            }
            else if (Nigel.x == 4 && Nigel.y == 6)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = true;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on North, South and West of you");
                // hall
            }
            else if (Nigel.x == 1 && Nigel.y == 7)
            {
                if (level1hasKey)
                {
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = true;
                    Nigel.canWest = false;
                    Nigel.Hallway();
                    Nigel.DoorEast();
                    Console.WriteLine("The hall goes on North and South of you");

                } else
                {
                    Nigel.canNorth = true;
                    Nigel.canSouth = true;
                    Nigel.canEast = false;
                    Nigel.canWest = false;
                    Nigel.Hallway();
                    Console.WriteLine("The hall goes on North and South of you");
                    Nigel.DoorEast();
                    Console.WriteLine("The door is locked");
                }
                
                // hall --- east goes into locked room
            }
            else if (Nigel.x == 2 && Nigel.y == 7)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = false;
                Nigel.canEast = false;
                Nigel.canWest = true;

                // room with stairs to floor 2 ------------------------
            }
            else if (Nigel.x == 3 && Nigel.y == 7)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = false;
                Nigel.canEast = true;
                Nigel.canWest = false;
                Console.WriteLine("The exit is east of you");
                IfInMagicRoom();
                PotionInRoom();
                // room with Magic Potion
            }
            else if (Nigel.x == 4 && Nigel.y == 7)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = true;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on North and South of you");
                // hall
            }
            else if (Nigel.x == 1 && Nigel.y == 8)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = false;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on North and South of you");
                Nigel.DoorEast();
                // hall
            }
            else if (Nigel.x == 2 && Nigel.y == 8)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = false;
                Nigel.canEast = false;
                Nigel.canWest = true;
                Nigel.EmptyRoom();
                Console.WriteLine("The exit is west of you");
                // empty room
            }
            else if (Nigel.x == 3 && Nigel.y == 8)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = false;
                Nigel.canEast = true;
                Nigel.canWest = false;
                Nigel.DarkEmptyRoom();
                Console.WriteLine("The exit is east of you");
                // room No light
            }
            else if (Nigel.x == 4 && Nigel.y == 8)
            {
                Nigel.canNorth = true;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = true;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on North and South of you");
                // hall
            }
            else if (Nigel.x == 1 && Nigel.y == 9)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = true;
                Nigel.canEast = true;
                Nigel.canWest = false;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on East and South of you");
                // hall
            }
            else if (Nigel.x == 2 && Nigel.y == 9)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = false;
                Nigel.canEast = true;
                Nigel.canWest = true;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on West and East of you");
                // hall
            }
            else if (Nigel.x == 3 && Nigel.y == 9)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = false;
                Nigel.canEast = true;
                Nigel.canWest = true;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on West and East of you");
                // hall
            }
            else if (Nigel.x == 4 && Nigel.y == 9)
            {
                Nigel.canNorth = false;
                Nigel.canSouth = true;
                Nigel.canEast = false;
                Nigel.canWest = true;
                Nigel.Hallway();
                Console.WriteLine("The hall goes on West and South of you");
                // hall
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
            if (Nigel.y < Nigel.maxYOfRoom && Nigel.canNorth)
            {
                Nigel.y++;
                Console.WriteLine("You moved North");
            }
            else
            {
                Console.WriteLine("You Walked stright into the wall,\nReal Smart Move there");
            }
        }

        // Move South
        // Only Moves South if you can move that way
        public static void South()
        {
            if (Nigel.y > Nigel.minYOfRoom && Nigel.canSouth)
            {
                Nigel.y--;
                Console.WriteLine("You moved South");
            }
            else
            {
                Console.WriteLine("You Walked stright into the wall,\nReal Smart Move there");
            }
        }

        // Move East
        // Only Moves East if you can move that way
        public static void East()
        {
            if (Nigel.x < Nigel.maxXOfRoom && Nigel.canEast)
            {
                Nigel.x++;
                Console.WriteLine("You moved East");
            }
            else if (Nigel.x == 1 && Nigel.y == 7 && Nigel.level1hasKey)
            {
                Console.WriteLine("The door is locked");
            }
            else if (Nigel.x == 1 && Nigel.y == 7)
            {
                Console.WriteLine("You unlock the door and Enter the room,\nYou find stairs to the second floor and go to the second floor");
                Nigel.x++;
            }
            else
            {
                Console.WriteLine("You Walked stright into the wall,\nReal Smart Move there");
            }
        }

        // Move West
        // Only Moves West if you can move that way
        public static void West()
        {
            if (Nigel.x > Nigel.minXOfRoom && Nigel.canWest == true)
            {
                Nigel.x--;
                Console.WriteLine("You moved West");
            }
            else
            {
                Console.WriteLine("You Walked stright into the wall,\nReal Smart Move there");
            }
        }

        // Can be used by anyone for there dark room, just call it with "Nigel.DarkEmptyRoom();"
        // All other ones are used repeatedly for each location on grid.
        public static void DarkEmptyRoom()
        {
            Console.WriteLine("You enter the room,\nIt's too dark to see anything.");
        }

        public static void EmptyRoom()
        {
            Console.WriteLine("The room is empty");
        }

        public static void Hallway()
        {
            Console.WriteLine("You are in a hallway");
        }

        public static void DoorEast()
        {
            Console.WriteLine("There is a Door east of you");
        }

        public static void DoorWest()
        {
            Console.WriteLine("There is a door west of you");
        }

        public static void DoorNorth()
        {
            Console.WriteLine("There is a door north of you");
        }

        public static void DoorSouth()
        {
            Console.WriteLine("There is a door south of you");
        }
        // Reusable code ends here.


        // moves between levels with this logic.
        // Has default values to start with then the methods it calls can change values to move between levels.
        public static void LevelSelect()
        {
            bool isStartOfLevel = true;
            int level = 1;

            // Intro call needs to go here


            do
            {

                switch (level)
                {

                    case 1:
                        Nigel.Floor1(ref isStartOfLevel, ref level);
                        break;
                    case 2:
                        Ben.Floor2(ref isStartOfLevel, ref level);
                        break;
                    case 3:
                        Declan.Floor3(ref isStartOfLevel, ref level);
                        break;
                    case 4:
                        Zach.attic();
                        break;
                    default:
                        Console.WriteLine("Error in LevelSelect, input/switch");
                        break;
                }



            } while (Nigel.playGame);
            Nigel.playGame = true;
        }

        /* Zach
         * The line just before your Console.ReadLine() or just after it needs to be
         * Nigel.playGame = false;
         * This will let the game stop other wise it will never end.
         */


        // The Haunted Mansion: A Text Adventure Game
        // Title Screen Display
        public static void TitleMenu()
        {
            Console.WriteLine(" =======   ||    ||   ||==== ");
            Console.WriteLine("    ||     ||    ||   ||     ");
            Console.WriteLine("    ||     ||====||   ||===  ");
            Console.WriteLine("    ||     ||    ||   ||     ");
            Console.WriteLine("    ||     ||    ||   ||==== ");
            Console.WriteLine();
            Console.WriteLine(@" ||     ||       /=\        ||     ||   ||\\  ||   =======   ||====   ||==     ");
            Console.WriteLine(@" ||     ||      // \\       ||     ||   || \\ ||      ||     ||       ||  \\   ");
            Console.WriteLine(@" ||=====||     //   \\      ||     ||   ||  \\||      ||     ||===    ||   ||  ");
            Console.WriteLine(@" ||     ||    //=====\\     \\     //   ||   \\|      ||     ||       ||   // ");
            Console.WriteLine(@" ||     ||   //       \\     \\___//    ||    \\      ||     ||====   ||==//  ");
            Console.WriteLine();
            Console.WriteLine(@" |\\      //|       /=\       ||\\  ||    ===\\   =||=   //===\\   ||\\  || ");
            Console.WriteLine(@" ||\\    //||      // \\      || \\ ||   //        ||    ||   ||   || \\ || ");
            Console.WriteLine(@" || \\  // ||     //   \\     ||  \\||   \\==\\    ||    ||   ||   ||  \\|| ");
            Console.WriteLine(@" ||  \\//  ||    //=====\\    ||   \\|       ||    ||    ||   ||   ||   \\| ");
            Console.WriteLine(@" ||   \/   ||   //       \\   ||    \\   \\==//   =||=   \\===//   ||    \\ ");
            Console.WriteLine();
        }



        // Starts the Game, Currently Give you the option play the game and Close the program
        public static void GameMenu()
        {
            bool keepPlayingGame = true;

            do
            {
                Nigel.TitleMenu();
                Console.WriteLine("Press 1: To play Game\nPress 2: To quit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Playing Game");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Nigel.LevelSelect();
                        break;
                    case "2":
                        Console.WriteLine("Exiting,\nGood Bye");
                        keepPlayingGame = false;
                        break;
                    default:
                        Console.WriteLine("Error Not Valid\nTry again");
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                }
                Nigel.playGame = true;

            } while (keepPlayingGame);


        }

        // This is called each loop to check if conditions need to change,
        // Does everything depending on if something is true.
        public static void PotionMovement(ref string input)
        {
            Random rand = new Random();
            int newDirection = rand.Next(0, 4);

            if (magicDrinkCount > 0) hasUsedMagicDrink = true;
            if (magicDrinkCount < 1) hasUsedMagicDrink = false;

            if (hasUsedMagicDrink)
            {
                MoveStartedAs(input);
                Console.WriteLine("You feel the effects of the Magic Potion");
                input = PotionDirection(newDirection);
                Console.WriteLine(input);
                Thread.Sleep(5000);
            }
        }

        // will check to see if you are in the room with the potion and change isMagicRoom bool if you are
        public static void IfInMagicRoom()
        {
            if (x == 2 && y == 2) isMagicRoom = true;
            if (x == 2 && y == 5) isMagicRoom = true;
            if (x == 3 && y == 7) isMagicRoom = true;

            if (Ben.x == 4 && Ben.y == 2) isMagicRoom = true;
            if (Ben.x == 1 && Ben.y == 7) isMagicRoom = true;
            if (Ben.x == 3 && Ben.y == 7) isMagicRoom = true;

            if (Declan.x == 1 && Declan.y == 2) isMagicRoom = true;
            if (Declan.x == 3 && Declan.y == 4) isMagicRoom = true;
            if (Declan.x == 4 && Declan.y == 3) isMagicRoom = true;
        }

        // This code will change the isMagicRoom bool and magicDrinkCount int,
        // and print stuff to the console using timed pauses.
        public static void MagicDrink()
        {
            if(Nigel.isMagicRoom)
            {
                Thread.Sleep(2000);
                Console.WriteLine("You are now suffering from some kind of curse\nNot sure how long it will last for,\nHave fun with that.");
                Thread.Sleep(500);
                Console.WriteLine("Honestly,\nWho just drinks something they find in an abandoned Mansion and thinks,\nDrinking this is a good idea.......");
                Thread.Sleep(4000);

                if (x == 2 && y == 2) magicDrinkCount += 10;
                if (x == 2 && y == 5) magicDrinkCount += 13;
                if (x == 3 && y == 7) magicDrinkCount += 15;

                if (Ben.x == 2 && Ben.y == 2) magicDrinkCount += 10;
                if (Ben.x == 2 && Ben.y == 5) magicDrinkCount += 13;
                if (Ben.x == 3 && Ben.y == 7) magicDrinkCount += 15;

                if (Declan.x == 1 && Declan.y == 2) magicDrinkCount += 10;
                if (Declan.x == 3 && Declan.y == 4) magicDrinkCount += 13;
                if (Declan.x == 4 && Declan.y == 3) magicDrinkCount += 15;
            } 
        }

        // this returns the new value to input in PotionMovement if called
        public static string PotionDirection(int directionNum)
        {
            if (directionNum == 0) return "n";
            if (directionNum == 1) return "s";
            if (directionNum == 2) return "e";
            if (directionNum == 3) return "w";
            return " ";
        }

        // This tells the player the direction that they tryed to move
        public static void MoveStartedAs(string input)
        {
            if (input == "n" || input == "north") Console.WriteLine("You Tried to move North but,");
            if (input == "s" || input == "south") Console.WriteLine("You Tried to move South but,");
            if (input == "e" || input == "east") Console.WriteLine("You Tried to move East but,");
            if (input == "w" || input == "west") Console.WriteLine("You Tried to move West but,");
        }

        // Prints to the screen For the Potion Feature
        public static void PotionInRoom() => Console.WriteLine("You see a Magic Potion on the floor,\nIt has a note on it saying,\n\"Drink me to make the game Easy\"");
    }

}
