using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BasicTypesLibrary {
    public static class SystemDrawingExtensions {

        #region Point
        /// <summary>
        /// Ссумирует координаты точки.
        /// </summary>
        public static Point Sum(this Point p1, Point p2) {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        /// <summary>
        /// Ссумирует координаты точки.
        /// </summary>
        public static Point Sum(this Point p1, int x, int y) {
            return new Point(p1.X + x, p1.Y + y);
        }
        /// <summary>
        /// Вычтет координаты точки.
        /// </summary>
        public static Point Substract(this Point p1, Point p2) {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }
        /// <summary>
        /// <see langword="true"/>, если заданный <see cref="Point"/> с четырёх сторон к объекту вплотную.
        /// </summary>
        public static bool CloseTo(this Point value, Point target) => !(Math.Abs(value.Y - target.Y) > 1 || Math.Abs(value.X - target.X) > 1);
        /// <summary>
        /// Возвращает объект с инвертированными координаты.
        /// </summary>
        public static Point Invert(this Point p1) {
            return new Point(-p1.X, -p1.Y);
        }

        #endregion

        #region Size
        /// <summary>
        /// <see langword="true"/>, если размер одной из сторон нулевой.
        /// </summary>
        public static bool IsEmptyOrFlat(this Size size) {
            return size.Width == 0 || size.Height == 0;
        }

        #endregion

    }
}
