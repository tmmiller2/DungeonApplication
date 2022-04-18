using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //Combat is NOT a datatype class, so it won't have our
        //fields, properties, constructors. It will simply
        //serve as a warehouse for a variety of methods related
        //to combat.

        //Let's create a method to handle a 1-sided attack!
        public static void DoAttack(Character attacker, Character defender)
        {
            //Get a random number from 1-100
            Random rand = new Random();
            int roll = rand.Next(1, 101);

            //Nothing is TRULY random in programming, but suspending the code
            //execution briefly may help stimulate "randomness".
            //We can use the Thread.Sleep() for this, which is located in the
            //System.Threading namespace

            Thread.Sleep(30); //30 milliseconds to delay first to next

            //If the attacker "hits"
            if (roll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //Calculate the damage
                int damageDealt = attacker.CalcDamage();

                //Subtract & assign the damage to the defender's lifw
                defender.Life -= damageDealt;

                //Output the result w Red text
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, 
                    defender.Name, damageDealt);

                //Reset the color
                Console.ResetColor();
            }
            //If the attacker "missed"
            else
            {
                Console.WriteLine("{0} missed!", attacker.Name);
            }
        }//end DoAttack

        //Now we can create a method to handle Battle - attacks from both sides 
        public static void DoBattle(Player player, Monster monster)
        {
            //Possible Expansion
            //Consider adding initiative property to character
            //if (player.Initiative >= Monster.Initiative)
            //{
            //    DoAttack(player, monster);
            //}

            //For this example, we'll grant the Player "initiative" by default
            DoAttack(player, monster);

            //If the Monster survives, they will attack the player back
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }

        }

    }//end Class
}//end Namespace
