using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoomLib
{
    public class HealingPotion : Potion
    {
        public HealingPotion() : base("Healing Potion")
        {

        }

        /// <summary>
        /// Adds a value to a characters health. If the health is lower than max health.
        /// </summary>
        /// <param name="character"></param>
        public override void Obtain(Character character)
        {
            character.Health += 10;

            if (character.Health >= 100)
            {
                character.Health = 100;
            }
        }
    }
}
