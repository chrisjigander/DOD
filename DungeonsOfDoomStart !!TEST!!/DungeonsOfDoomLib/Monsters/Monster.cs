using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoomLib
{
    public abstract class Monster : Character, IObtainable
    {
        public Monster(int health, int damage, string name) : base(0, 0, health, damage, name, 'M')
        {
        }

    }
}
