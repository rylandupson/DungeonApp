using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class BattleDroid : Droid
    {
        //fields

        //props

        //ctors
        public BattleDroid(string name, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, string description) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        { }
        //methods


    }//end class
}//end namespace
