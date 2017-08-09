using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class RandomUtils
    {
        static Random random = new Random();

        /// <summary>
        /// Takes input from user (1-100) and calculates chance for true in percentage.
        /// </summary>
        /// <param name="value">Input from user</param>
        /// <returns>bool</returns>
        public static bool ChanceForTrueInPercentage(int value)
        {
            if (value < 1 || value > 100)
            {
                throw new IndexOutOfRangeException("The value has to be 1-100.");
            }
            return random.Next(1, 101) < value;

            #region Förklaring
            //Value = input 1-100, om värdet från random är mindre än value så returnerar vi true och går in i if-satsen.
            #endregion
        }

        /// <summary>
        /// Takes to values from user and randomizes a number inbetween.
        /// </summary>
        /// <param name="min">Input form user, lowest value</param>
        /// <param name="max">Input from user, highest value</param>
        /// <returns>Int between min-max.</returns>
        public static int RandomBetween(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }
}
