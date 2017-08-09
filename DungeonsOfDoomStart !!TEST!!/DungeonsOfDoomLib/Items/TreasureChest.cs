using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoomLib
{
    public class TreasureChest : GameObject
    {
        public TreasureChest(int health) : base('T')
        {
            Health = health;
        }

        public int Health { get; set; }

    }
}

