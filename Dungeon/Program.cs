namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "The Polar Tundra Dungeon";

            Console.WriteLine("Your quest through the dungeon will begin now...");

            //TODO: Create Player and Monsters

            #region Main Game Loop

            bool exit = false;

            do
            {
                Console.WriteLine(GetRoom());

                Console.WriteLine(GetMonster());

                #region Gameplay Menu Loop

                bool reload = false;
                do
                {
                    //Display the menu
                    Console.WriteLine("\nPlease select what you would like to do:\n" +
                        "(A) Attack\n" +
                        "(B) Run Away\n" +
                        "(C) Character Info\n" +
                        "(D) Monster Info\n" +
                        "(E) Exit\n");

                    ConsoleKey choice = Console.ReadKey(true).Key;

                    Console.Clear();

                    switch (choice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("Attack");
                            //TODO Combat
                            break;

                        case ConsoleKey.B:
                            Console.WriteLine("Run Away");
                            //TODO Run away
                            break;

                        case ConsoleKey.C:
                            Console.WriteLine("Character Info");
                            //TODO Player info
                            break;

                        case ConsoleKey.D:
                            Console.WriteLine("Monster Info");
                            //TODO Monster info
                            break;

                        case ConsoleKey.E:
                        case ConsoleKey.X:
                            Console.WriteLine("Thank you for playing!");
                            exit = true; //UPDATE
                            break;

                        default:
                            Console.WriteLine("Invalid input. Please try again.");
                            break;
                    }//end switch
                    if (!exit) //Only run if the loop will repeat
                    {
                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadKey(true);
                    }//end if

                } while (!exit && !reload); //continue looping while exit == false; (CONDITION)

                #endregion 

            } while (!exit);

            #endregion

        }//end Main

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

        #region GetMonster

        private static string GetMonster()
        {
            string[] monsters =
            {
                "You encounter a caribou-like creature that has a 3rd eye on the top of his head. The horns are frozen at the tips and are much larger as well as sharper than the standard caribou.",
                "An arctic wolf appears. It looks friendly at a glance, but once you get close enough, it's eyes turn red and it is ready for dinner.",
                "You see what you believe is a hurd of Muskox. As you get closer, you see it is one large, 3-headed muskox.",
                "A friendly looking penguin appears! You think it is cute as it's eyes twinkly until it starts to fly. It possesses magical powers to use it's flippers like wings and can provide a harsh peck if you get too close.",
                "There is a snow owl you hear hooting in the distance. No need to fear right? You heard it in the distance because it is actually much bigger than the standard snow owl. It is about the size of a normal one x100 and has blazing red eyes.",
                "A mountain goat appears and it feels trapped so it becomes ready to attack. Your best tactic is to flee but you will not be able to outrun it.",
                "A killer whale jumps out of the waters beside you and knocks you into the harsh cold water. It is rare that a killer whale would attack a human but you are the chosen one.",
                "A wild snow leopard spots you. It would be more likely for it to run away instead of attack you, but you are looking tasty to the leopard.",

            };

            //create random Object | use Next() to generate number | create and store variable | return random monster to user
            Random rand = new Random();

            int indexNbr = rand.Next(monsters.Length);

            string room = monsters[indexNbr];

            return room;
        }

        #endregion




    }//end Class
}//end Namespace