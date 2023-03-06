using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nigel_Ben_Declan_Zach
{
    internal class Zach
    {
        public static void attic()
        {
            string tool;
            int win, death;
            death = 0;
            win = 0;
            do
            {
                Console.WriteLine("You have now entered the attic only to find a glowing crystal ball on the table surrounded by,\n a hammer, a wrench, a pipe, a rock, and a pair of scissors.");
                tool = Console.ReadLine();

                switch (tool)
                {
                    case "hammer":
                    case "wrench":
                        {
                            Console.WriteLine($"You whack the crystal ball with the {tool}. It has shattered the crystal ball into millions of shards. You have freed all the victims of Marie Lavaue.You walk out of the mansion forgetting why you were there and wondering.What just happened.");
                            win = 1;
                            break;
                        }
                    case "pipe":
                    case "rock":
                        {
                            Console.WriteLine("You crack the crystal ball. The crystal ball repairs itself trapping you for eternity with everyone else.");
                            win = 1;
                            break;
                        }
                    case "scissors":
                        {
                            Console.WriteLine("you plunge the scissors into the crystal ball, and they get stuck. The crystal ball repairs itself sealing in the scissors trapping you for eternity with everyone else.");
                            win = 1;
                            break;
                        }

                    default:
                        {
                            death++;
                            if (death < 2)
                            {
                                Console.WriteLine("thank the lucky stars the witch has giving you a second chance to pick");
                            }

                            break;
                        }
                }
                if (death == 2)
                {
                    Console.WriteLine("The crystal ball notice you, it traps you for eternity with everyone else.");
                    win = 1;
                }

            } while (win == 0);
            Console.ReadLine();
            Nigel.playGame = false;
        }
        public static void intro()
        {
            Console.WriteLine("Welcome to the Haunted Mansion.");
            Console.ReadLine();
            Console.WriteLine("As a paranormal investigator it is you job to find out what has caused 35 people to disappear over the last century.\nYour search has led you to this haunted mansion.");
            Console.ReadLine();
            Console.WriteLine("You have now entered the mansion. The Large doors slam shut behind you and locked themselves as well.\nNow begins your journey.\nTo learn how to move type “help” at any point.\nTo see you Inventory type “inventory” or “invent”.");
            Console.ReadLine();
        }

    }
}
