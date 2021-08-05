using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Player : Character
    {
        //fields

        //props
        public Weapon EquippedWeapon { get; set; }

        //ctors
        public Player(string name, int hitChance, int block, int life, int maxLife, Weapon equippedWeapon)
        {
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            EquippedWeapon = equippedWeapon;
        }

        //methods
        public override string ToString()
        {
            return string.Format("**** {0} ****\n" +
                "Life: {1} of {2}\n" +
                "Hit Chance: {3}%\n" +
                "Weapon: {4}\n" +
                "Block: {5}\n",
                Name, Life, MaxLife, HitChance, EquippedWeapon, Block);
        }//end tostring

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage,
                EquippedWeapon.MaxDamage + 1);
            return damage;
        }//end calcdamage

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.CriticalHit;
        }//end calchitchance

    }//end class
}//end namespace
