using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoomLib
{
    public class Ogre : Monster
    {
        public Ogre() : base(50, 10, "Ogre")
        {
        }

        /// <summary>
        /// Initiates a fight between this and opponent, reduces opponent's health with "this"'s damage value.
        /// </summary>
        /// <param name="opponent">A character</param>
        /// <returns>To base.Fight</returns>
        public override string Fight(Character opponent)
        {
            return base.Fight(opponent);
        }
    }
}
