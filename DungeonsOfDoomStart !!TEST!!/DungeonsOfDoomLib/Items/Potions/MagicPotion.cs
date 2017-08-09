using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoomLib
{
    public class MagicPotion : Potion
    {
        int worldWidth, worldHeight;

        public MagicPotion(Room[,] world) : base("Magic Potion")
        {
            worldWidth = world.GetLength(0);
            worldHeight = world.GetLength(1);
        }

        /// <summary>
        /// "Randomizes" two coordinates on the game board and moves a characters position here.
        /// </summary>
        /// <param name="character">A character</param>
        public override void Obtain(Character character)
        {
            character.X = RandomUtils.RandomBetween(0, worldWidth - 1);
            character.Y = RandomUtils.RandomBetween(0, worldHeight - 1);
        }
    }
}
