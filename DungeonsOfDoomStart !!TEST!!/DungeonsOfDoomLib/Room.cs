using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoomLib
{
    public class Room : GameObject
    {
        public Monster Monster { get; set; }
        public Item Item { get; set; }
        public TreasureChest TreasureChest { get; set; }

        public Room() : base('.')
        {

        }
    }
}
