using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumbasDemons; //added
using TumbasLibrary;//added

namespace Diablero
{
    class Tumbas
    {
        static void Main(string[] args)
        {
            Console.Title = "La Tumba";
            Console.WriteLine("You enter the dark cave. Only to have lost your sense of direction. Now you have to find a way out. Good luck!\n");

            //1 create a player
            //we need to learn about custom classes first 
            Weapon sword = new Weapon(1, 20, "Espada", 10, false);

            Player player = new Player("Diablero", 70, 5, 40, 40, Race.Demon, sword);

            int score = 0;

            //2 create a loop for the room

            bool exit = false;

            do
            {
                //3 create a room - write a () to get a room description
                Console.WriteLine(GetRoom());

                //4 create a monster 
                //we need to learn about creating objects and then probably randomly select one

                Wendigo r1 = new Wendigo(); //uses the default ctor which sets some default values 

                Wendigo r2 = new Wendigo("Swift Wendigo", 25, 25, 50, 20, 2, 8, "That's no ordinary wendigo! Look how tall it is!", true);

                Nahual r3 = new Nahual();

                Jenglot r4 = new Jenglot();

                Kawuk r5 = new Kawuk();

                Kawuk r6 = new Kawuk("Young Kawuk", 25, 25, 50, 20, 2, 8, "It is alone and awaiting its mother.", true);


                //Since all children monsters are of type monster, we can store them in an array of monsters
                Monster[] monsters = { r1, r2, r3, r4, r5, r6 };

                //randomly select a monster from the array
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];

                //show monster in the room
                Console.WriteLine("\nIn this room: " + monster.Name);

                //5 create a loop for the menu
                bool reload = false;
                do
                {
                    //6 create a menu of options that tells the player what they can do
                    #region MENU
                    Console.WriteLine("\nPlease choose an action:\nA) Attack\nR) Run Away\nP) Player Info\nM) Monster Info\nX) Exit\n");

                    //7 Catch the users input 
                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    //8 Clear the console after the user input to clean up the screen
                    Console.Clear();

                    //9 Build out a switch for userChoice
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            //10 Engage battle sequence
                            //11 Handle if the player wins
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
                            Console.WriteLine("Run Away!!!");
                            //12 Handle running away and getting a new room
                            //13 Monster gets a free attack 
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player); //free attack
                            Console.WriteLine();
                            reload = true; //loads the new room with a new monster
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info");
                            //14 Need to print out player info
                            Console.WriteLine(player);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info");
                            //15 Need to print out monster info
                            Console.WriteLine(monster); //this will use polymorphism to get the correct
                            //ToString()
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("No one likes a quitter....");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("That wont work. Try another key.");
                            break;
                    }
                    #endregion

                    //check for the players life 
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("You see the light!\a");
                        exit = true;
                    }

                } while (!exit && !reload);//while exit is NOT TRUE AND reload is NOT TRUE keep looping

            } while (!exit);//while exit is NOT TRUE keep looping

            Console.WriteLine($"You defeated {score} monster(s)");

        }//end Main()


        private static string GetRoom()
        {
            string[] rooms = {
                "The room is dark and musty with the smell of lost souls.",
                "You enter a white bright room with light reflecting off all of the walls.",
                "You open the door to a scene of carnage. Two male humans, a male elf,\n and a female dwarf lie in drying pools of their blood.",
                "You enter an empty library... shelves have not a single book... nothing but silence....",
                "As you enter the room, you realize you are standing on a platform surrounded by sharks",
                "Oh my.... what is that smell? You appear to be standing in a compost pile",
                "Burning torches in iron sconces line the walls of this room, lighting it brilliantly.\n At the room's center lies a squat stone altar, its top covered in recently spilled blood.\n A channel in the altar funnels the blood down its side to the floor\n where it fills grooves in the floor that trace some kind of pattern or symbol around the altar.\n Unfortunately, you can't tell what it is from your vantage point",
                "This small bare chamber holds nothing but a large ironbound chest,\n which is big enough for a man to fit in and bears a heavy iron lock.\n The floor has a layer of undisturbed dust upon it",
                "You smelled smoke as you moved down the hall, and rounding the corner into this room you see why. \n Every surface bears scorch marks and ash piles on the floor. The room reeks of fire and burnt flesh.\n Either a great battle happened here or the room bears some fire danger you cannot see\n for no flames light the room anymore."
            };

            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;
        }
    }//end class
}//end namespace
