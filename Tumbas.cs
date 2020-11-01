using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumbasLibrary;//added
using TumbasDemons;//added

namespace Diablero
{
    class Tumbas
    {
        static void Main(string[] args)
        {
            Console.Title =  "Tumbas";
            Console.WriteLine("Your journey beginS...\n");

            // 1 Create a player
            Weapon sword = new Weapon(1, 8, "Machete", 10, false);

            Player player = new Player("Elvis Infante", 70, 40, 40, 40, Race.Elf, sword);

            int score = 0;
            //2 create a loop for the room

            bool exit = false;

            do
            {
                //3 Create a room - write a () to get a room description
                Console.WriteLine(GetRoom());

                // 4 create a monster
                //We need to learn about creating objects and then probably randomly select on
                Wendigo r1 = new Wendigo();//uses the default ctor which sets some default values

                Wendigo r2 = new Wendigo("Tall Wendigo", 25, 25, 50, 20, 2, 8, "That's no ordinary Wendigo!," +
                    "look at those claws", true);

                //Since all children monsters are of type monster, we can store them in an array of monsters
                Monster[] monsters = { r1, r2, r1, r1, r2, r2 }; //ex supply 1 of many types of monsters 

                //Randomly select a monster from the array
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];

                //Show monster in the room
                Console.WriteLine("\nIn this room: " + monster.Name);

                //5 create a loop for the menu
                bool reload = false;

                do
                {
                    //6 Create a menu of options that tells the player what they can do
                    #region Menu
                    Console.WriteLine("\nDiablero, choose an action:\nA) Attack\nR) Run Away\nP) Player Info\n" +
                        "M) Monster Info\nX) Exit\n");

                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            // 10 Engage battle sequence
                            // 11 Handle if the player wins
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                //it's dead!
                                //You could put some logic here to have the player get items, get life
                                //back, or something similar
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                Console.ResetColor();
                                reload = true;
                                score++;
                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("You try to flee the room.");
                            //12 handle running away and getting a new room
                            //13 monster gets a free attack
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player); //free attack
                            Console.WriteLine();
                            reload = true; //loads the new room with a new monster
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Bio:\n");
                            //TODO 14 need to print out player info
                            Console.WriteLine(player);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Bio:\n");
                            Console.WriteLine(monster); //this will use polymorphism to get the correct
                            //ToString()
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("The world grows darker without you...");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Choose an option." +
                                "Try again");
                            break;
                    }
                    #endregion

                    //check for the players life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude...you died!\a");
                        exit = true;//causes the do while to fall out of both exit and reload
                    }

                } while (!exit && !reload);//keeps looping until both become true
            } while (!exit);//keeps looping until true

            Console.WriteLine($"You defeated {score} monster(s)");

        }//end main()

        private static string GetRoom()
        {
            string[] rooms =
            {

                ". When looking into this chamber, you're confronted by a thousand reflections of yourself looking back. " +
                "Mirrored walls set at different angles fill the room. A path seems to wind through the mirrors, although " +
                "you can't tell where it leads.",//room 1 description
                "You open the door, and the room comes alive with light and music. A sourceless, warm glow suffuses the chamber," +
                " and a harp you cannot see plays soothing sounds. Unfortunately, the rest of the chamber isn't so inviting." +
                " The floor is strewn with the smashed remains of rotting furniture. It looks like the room once held a bed," +
                " a desk, a chest, and a chair.",//room 2 description
                "Fire crackles and pops in a small cooking fire set in the center of the room. The smoke from a burning rat" +
                " on a spit curls up through a hole in the ceiling. Around the fire lie several fur blankets and a bag. It looks" +
                " like someone camped here until not long ago, but then left in a hurry.", //room 3 description
                "A huge stewpot hangs from a thick iron tripod over a crackling fire in the center of this chamber. A hole in the" +
                " ceiling allows some of the smoke from the fire to escape, but much of it expands across the ceiling and rolls" +
                " down to fill the room in a dark fog. Other details are difficult to make out, but some creature must be nearby," +
                " because it smells like a good soup is cooking.",// 4 room description
                "In the center of this large room lies a 30-foot-wide round pit, its edges lined with rusting iron spikes. " +
                "About 5 feet away from the pit's edge stand several stone semicircular benches. The scent of sweat and blood lingers," +
                " which makes the pit's resemblance to a fighting pit or gladiatorial arena even stronger."//room 5 description
            };

            Random rand = new Random();

            int indexNum = rand.Next(rooms.Length);

            string room = rooms[indexNum];

            return room;
        }
    }//end class
}//end namespace
