using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoomLib
{
    public abstract class Character : GameObject
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public Character(int x, int y, int health, int damage, string name, char gameChar) : base (gameChar)
        {
            X = x;
            Y = y;
            Name = name;
            Health = health;
            Damage = damage;
            GameChar = gameChar;
        }


        /// <summary>
        /// Initiates a fight between this and opponent, reduces opponent's health with "this"'s damagevalue.
        /// </summary>
        /// <param name="opponent">A character</param>
        /// <returns>A string.</returns>
        public virtual string Fight(Character opponent)
        {
            opponent.Health -= this.Damage;
            return $"{this.Name} attacked {opponent.Name}, it's health is now {opponent.Health}\n";
        }

        
    }
}
