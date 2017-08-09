using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoomLib
{
    public class Orc : Monster
    {
        public Orc() : base(30, 5, "Orc")
        {
        }

        /// <summary>
        /// If the Orc's health is less than half of the opponent's damage, Orc selfdestructs.
        /// </summary>
        /// <param name="opponent">A character</param>
        /// <returns>A string or returns to base.Fight</returns>
        public override string Fight(Character opponent)
        {
            if (this.Damage < opponent.Damage / 2)
            {
                this.Health = 0;
                return $"{opponent} died from fear!";
            }

            return base.Fight(opponent);
        }
    }
}
