using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoomLib
{
    public class Player : Character
    {
        public Player(int health, int damage, int x, int y) : base(x, y, health, damage, "Player", 'P')
        {
        }

        public List<IObtainable> BackPack = new List<IObtainable>();

    }
}
