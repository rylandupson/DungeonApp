using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Droideka : Droid
    {
        //fields
        public bool EnergyShield { get; set; }

        //props

        //ctors
        public Droideka(string name, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, string description, bool energyShield) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            EnergyShield = energyShield;
        }

        //methods
        public override string ToString()
        {
            return base.ToString() + (EnergyShield ? "Energy Shield Activated" : "Energy Shield Down");
        }//wnd tostring

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (EnergyShield)
            {
                calculatedBlock += calculatedBlock / 3;
            }

            return calculatedBlock;
        }

    }//end class
}//end namespace
