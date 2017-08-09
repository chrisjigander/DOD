using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoomLib
{
    public abstract class GameObject
    {
        public char GameChar { get; set; }

        public GameObject(char gameChar)
        {
            GameChar = gameChar;
        }
    }
}
