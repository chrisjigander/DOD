using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoomLib
{
    public class Sword : Weapon
    {

        public Sword(string name) : base(name)
        {
        }

        public override void Obtain(Character character)
        {
            character.Damage += 5;
        }

    }
}
