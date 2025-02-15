using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicLibrary;

namespace BasicLibrary
{
    public static class RandomExtensions {
        /// <summary>
        /// Returns count within the specified boundaries inclusive.
        /// </summary>
        public static int NextInclude(this Random random, int lowBound, int upperBound) {
            return random.Next(lowBound, upperBound + 1);
        }
    }
}
