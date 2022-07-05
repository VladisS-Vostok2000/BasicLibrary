using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace BasicTypesLibrary {
    public static class BasicTypesExtensions {

        #region Int32
        /// <summary>
        /// Возвращает число в заданном диапазоне в соответсвии с правилом, как если бы следующее число после последнего в диапазоне соответсвовало первому в диапазоне, и наоборот.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public static int ToRange(in this int target, in int rangeStart, in int rangeEnd) {
            int rangeLength = rangeEnd - rangeStart;
            if (rangeLength < 0) {
                throw new ArgumentException("Диапазон не может быть меньше единицы.");
            }

            var shiftedTarget = target - rangeStart;
            var preShiftedIndex = shiftedTarget % rangeLength;
            int shiftedIndex = preShiftedIndex < 0 ? preShiftedIndex + rangeLength : preShiftedIndex;
            return shiftedIndex + rangeStart;
        }

        /// <summary>
        /// <see langword="true"/>, если число лежит в заданном диапазоне включительно с обоих границ.
        /// </summary>
        public static bool IsInRange(in this int target, in int lowerBound, in int upperBound) => target >= lowerBound && target <= upperBound;
        #endregion

        #region Float
        /// <summary>
        /// Возвращает 0, если число меньше нуля или само значение иначе.
        /// </summary>
        public static float NotNegative(in this float target) => target < 0 ? 0 : target;
        #endregion

        #region String
        /// <summary>
        /// Отчистит строку от символов, относящихся к категории пробелов.
        /// </summary>
        public static string ClearEmptySpaces(this string target) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < target.Length; i++) {
                if (!char.IsWhiteSpace(target[i])) {
                    sb.Append(target[i]);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Извлекает подстроку с заданной позиции, пока не будет встречен заданный символ.
        /// Возвращается строка содержащая символ со стартовой индексацией, но без заданного.
        /// </summary>
        public static string Substring(this string target, int startIndex, char chr) {
            int lastIndex = target.IndexOf(chr, startIndex);
            int length = lastIndex - startIndex;
            return target.Substring(startIndex, length);
        }

        /// <summary>
        /// Извлекает подстроку с заданной позиции, пока не будет встречен символ, относящийся к категории пробелов.
        /// </summary>
        public static string ExtractWord(this string target, int startIndex = 0) {
            int whiteSpaceIndex = -1;
            for (int i = startIndex; i < target.Length; i++) {
                char letter = target[i];
                if (char.IsWhiteSpace(letter)) {
                    whiteSpaceIndex = i;
                    break;
                }
            }

            if (whiteSpaceIndex == -1) {
                return target.Substring(startIndex);
            }

            int length = whiteSpaceIndex - startIndex;
            return target.Substring(startIndex, length);
        }

        /// <summary>
        /// Возвращает строку, в которой все заданные символы отсутствуют.
        /// </summary>
        public static string Remove(this string target, char aim) {
            var sb = new StringBuilder();
            foreach (var letter in target) {
                if (letter == aim) { continue; }

                sb.Append(letter);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Возвращает проходящий по строкам перечислитель заданного текста.
        /// </summary>
        public static IEnumerable<string> SplitToLines(this string input, StringSplitOptions stringSplitOptions = StringSplitOptions.None) {
            if (input is null) { throw new ArgumentNullException($"{nameof(input)} был null."); }


            using (var reader = new StringReader(input)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    if (stringSplitOptions == StringSplitOptions.RemoveEmptyEntries && line == "") {
                        continue;
                    }

                    yield return line;
                }
            }
        }

        /// <summary>
        /// Возвращает индекс символа(-ов), относящихся к переносу строки.
        /// -1, если не найден.
        /// </summary>
        public static int IndexOfNewLine(this string value) => value.IndexOf(Environment.NewLine);

        /// <summary>
        /// Возвращает индекс символа(-ов), относящихся к переносу строки.
        /// -1, если не найден.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int IndexOfNewLine(this string value, int startIndex) => value.IndexOf(Environment.NewLine, startIndex);

        /// <summary>
        /// <see langword="true"/>, если содержит символ переноса строки.
        /// </summary>
        public static bool ContainsNewLine(this string value) => value.IndexOfNewLine() != -1;

        /// <summary>
        /// Возвращает подстроку заданной длинны. Вернётся полная строка при избыточной длинне.
        /// Вернётся пустая строка при длинне 0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string StringPart(this string value, int length) {
            if (length < 0) {
                throw new ArgumentOutOfRangeException(nameof(length), "Длинна не может быть отрицательной.");
            }

            if (length <= value.Length) {
                return value.Substring(0, length);
            }

            return value.Substring(0, value.Length);
        }

        #endregion

    }
}

