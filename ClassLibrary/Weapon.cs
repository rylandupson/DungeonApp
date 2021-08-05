using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Weapon
    {
        //fields
        private int _minDamage;

        //props
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public int CriticalHit { get; set; }
        
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }//end if
            }//end set
        }//end MinDamage

        //ctors
        public Weapon(int minDamage, int maxDamage, string name, int criticalHit)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            CriticalHit = criticalHit;
        }

        //methods
        public override string ToString()
        {
            return string.Format("{0}\t{1} to {2} Damage\n" +
                "Crit Chance: {3}%\t",
                Name, MinDamage, MaxDamage, CriticalHit);
        }

    }//end class
}//end namespace
