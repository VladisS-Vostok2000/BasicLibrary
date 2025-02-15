using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Math;

namespace BasicLibrary {
    public static class MathExtensions {

        /// <summary>
        /// <see langword="true"/>, если число содержит дробную часть.
        /// </summary>
        public static bool IsInt(this double number) => number % Truncate(number) == 0;

        /// <summary>
        /// Переводит целочисленный угол из радиан в градусы.
        /// </summary>
        public static double ToGrad(int corner) {
            return corner * PI / 180;
        }

        /// <summary>
        /// Меняет знак числа на противоположный.
        /// </summary>
        public static int Invert(this int number) => number * -1;

        public static int Square(this int number) => (int)Pow(number, 2);
        public static double Square(this double number) => Pow(number, 2);

    }
}
