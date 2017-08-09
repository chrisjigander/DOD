using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoomLib
{
    public abstract class Item : GameObject, IObtainable
    {
        public Item(string name) : base('I')
        {
            Name = name;
        }

        public string Name { get; set; }


        /// <summary>
        /// Declares an abstract method.
        /// </summary>
        /// <param name="character">Character who uses the method</param>
        public abstract void Obtain(Character character);
    }
}
