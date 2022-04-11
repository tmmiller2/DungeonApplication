using DungeonLibrary;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Title / Introduction

            Console.Title = "Arctic Dungeon";

            Console.WriteLine("Your journey starts here...");

            #endregion

            //TODO Create a variable to track the score
            int score = 0;

            //TODO: Create a Player object to track info/stats
            Weapon longSword = new Weapon(1, 8, "Long Sword", 10, false, WeaponType.Sword);

            Player player = new Player("Leeroy Jenkins", 70, 5, 40, 40, Race.Human, longSword);

            #region Main Game Loop

            //Bool (counter) for the loop
            bool exit = false;

            //Create the main loop
            do
            {
                //TODO Generate a random room
                Console.WriteLine(GetRoom());

                //TODO Select a Monster (at random) for the player to encounter
                #region Monster Objects

                Caribou caribou = new Caribou("Caribou", 25, 25, 50, 20, 2, 8,
                    "That's no ordinary caribou! Look at the horns!", true);

                Muskox muskox = new Muskox("3 Headed Ox", 25, 30, 70, 8, 1, 8, "This monster is like no other.");

                Wolf wolf = new Wolf("Wolf", 17, 25, 50, 10, 1, 4,
                    "This is the alpha wolf.", 3, 10);

                Penguin penguin = new Penguin("Penguin", 10, 20, 65, 20, 1, 15, "The cutest of them all.", true);

                #endregion

                #region Monster Selection

                //Add the monsters to a collection
                Monster[] monsters = { caribou, muskox, wolf, penguin };

                //Pick one at random to place in the room
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];

                //Output
                Console.WriteLine("\nIn this room you encounter: " + monster.Name);

                #endregion

                #region Gameplay Menu Loop

                //Bool (counter) for the gameplay loop
                bool reload = false;

                //Create the gameplay loop
                do
                {
                    //Create the gameplay menu
                    #region Gameplay Menu

                    //Prompt the user
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run away\n" +
                        "P) Player info\n" +
                        "M) Monster info\n" +
                        "X) Exit\n");


                    //Capture the user's menu selection
                    ConsoleKey userChoice = Console.ReadKey(true).Key; //Executes on key press

                    //Clear the console
                    Console.Clear();

                    //Use branching logic to execute code based on user's menu selection
                    switch (userChoice)
                    {

                        case ConsoleKey.A:
                            //TODO Combat
                            Combat.DoBattle(player, monster);

                            //Check if the monster is dead
                            if (monster.Life <= 0)
                            {
                                //Use green text to highlight winning combat
                                Console.ForegroundColor = ConsoleColor.Green;

                                //Output the result
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);

                                //Reset the color
                                Console.ResetColor();

                                //Update the score
                                score++;

                                //Flip the reload bool to exit the current menu
                                //loop so we can get a new room & monster
                                reload = true;
                            }

                            break;

                        case ConsoleKey.R:
                            //TODO Run away
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);

                            //Formatting
                            Console.WriteLine();

                            //Flip the reload bool to exit the current menu
                            //and get a new room & monster
                            reload = true;

                            break;

                        case ConsoleKey.P:
                            //TODO Player info
                            Console.WriteLine(player);
                            Console.WriteLine("Monsters defeated: " + score);
                            break;

                        case ConsoleKey.M:
                            //TODO Monster info
                            Console.WriteLine(monster);
                            break;

                        //Allows the user to exit if they hit X OR E
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("No one likes a quitter...");

                            //Flip the bool to break from the loop
                            exit = true;
                            break;

                        default:

                            Console.WriteLine("Thou hast chosen an improper action. Triest thou again.");

                            break;
                    }

                    #endregion

                    //Check the Player's life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("You have been defeated by {0}!", monster.Name);

                        //Flip the exit bool to end the game
                        exit = true;
                    }


                } while (!exit && !reload); //Condition - while exit AND reload are NOT true, keep looping

                #endregion


            } while (!exit); //Condition for loop - While exit is NOT true, keep looping

            #endregion

            //Output the final score
            Console.WriteLine("You defeated " + score + " monster" +
                ((score == 1) ? "." : "s."));

        }//end Main()

        #region GetRoom

        private static string GetRoom()
        {
            string[] rooms =
            {
                "The room you entered is very cold with large icicles beaming down towards you from above.",
                "A 10 foot tall ice statue, appearing as the final boss of monsters, stands before you. In it's palm, holds a cobalt blue gemstone.",
                "A thin vibrant red trail of blood stands out against the bright white snow. You follow it and find a gutted elf with a stange symbol in blood on the snow beside it.",
                "There is a large dead tree that is home to a bunch of snow owls, hooting a somewhat familiar melody that draws your attention.",
                "You spot a cave blocked by a solid block of ice. You get closer and see there is a human-like figure frozen in the block.",
                "A fishing boat is stuck, frozen in a glacier with a large trout. Next to it is an alive trout flopping on the ice.",
                "You are knocked out from the harsh weather and wake up on a lonely ice island. You began to hallucinate and see the chunk floating towards the other chunks of ice until you come to realization, that all you are surrounded by is open water.",
                "This room is very cold and you spot a backpack that might be useful. You pick it up and hear an alarming sound and can infer that you are not alone anymore.",

            };

            //create random Object | use Next() to generate number | create and store variable | return random room to user
            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;
        }

        #endregion

    }//end class

}//end Namespace
