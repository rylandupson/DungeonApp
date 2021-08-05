using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            //get a random number from 1-100 as our dice roll
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(500);
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //the attacker hit...calcDamage
                int damageDealt = attacker.CalcDamage();

                //assign the damage
                defender.Life -= damageDealt;

                //Write the result to the screen
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!",
                    attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();
            }//end if
            else
            {
                //the attacker missed
                Console.WriteLine($"{attacker.Name} missed!");
            }//end else
        }//end DoAttack

        public static void DoBattle(Player player, Droid droid)
        {
            //Player attacks first
            DoAttack(player, droid);

            //monster gets an attack only if they are still alive
            if (droid.Life > 0)
            {
                DoAttack(droid, player);
            }//end if
        }//end DoBattle

    }//end class
}//end namespace
