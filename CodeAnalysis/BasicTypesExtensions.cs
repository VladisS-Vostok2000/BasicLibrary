using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace BasicLibrary {
    public static class BasicTypesExtensions {

        // TODO: Documentation to english.

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

        /// <summary>
        /// Возвращает число, крайняя правая ненулевая цифра которого округляется в следующий слева разряд.
        /// </summary>
        public static int Round(in this int target) {
            if (target == 0) {
                return 0;
            }

            int sign = System.Math.Sign(target);

            int digitToRound = System.Math.Abs(target) % 10;
            int trancatedNumber = System.Math.Abs(target) / 10;
            int dozens = 1;
            while (digitToRound == 0) {
                digitToRound = trancatedNumber % 10;
                trancatedNumber /= 10;
                dozens++;
            }

            int roundedDigit = digitToRound < 5 ? 0 : 1;
            int multiplicator = 1;
            for (int i = 0; i < dozens; i++) {
                multiplicator *= 10;
            }

            return (trancatedNumber + roundedDigit) * multiplicator * sign;
        }

        #endregion


        #region Float

        /// <summary>
        /// Возвращает 0, если число меньше нуля или само значение иначе.
        /// </summary>
        public static float NotNegative(in this float target) => target < 0 ? 0 : target;

        #endregion


        #region String

        /// <summary>
        /// <see langword="true"/>, если строка состоит лишь из символов-пробелов.
        /// </summary>
        public static bool IsWhiteSpaces(this string @string) {
            for (int i = 0; i < @string.Length; i++) {
                char @char = @string[i];
                if (!char.IsWhiteSpace(@char)) {
                    return false;
                }
            }

            return true;
        }

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

        /// <returns>
        /// <see langword="true"/>, if presented string <see cref="string"/> contains control character.
        /// </returns>
        public static bool ContainsControlCharacter(this string target) {
            foreach (var @char in target) {
                if (char.IsControl(@char)) {
                    return true;
                }
            }

            return false;
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
            return value.StringPart(0, length);
        }

        /// <summary>
        /// Возвращает подстроку заданной длинны. Вернётся полная строка при избыточной длинне.
        /// Вернётся пустая строка при длинне 0.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string StringPart(this string value, int startIndex, int length) {
            if (length < 0) {
                throw new ArgumentOutOfRangeException(nameof(length), "Длинна не может быть отрицательной.");
            }

            if (startIndex == 0 && length == value.Length) {
                return value;
            }

            if (startIndex < value.Length - length) {
                return value.Substring(startIndex, value.Length);
            }

            int actualLength = value.Length - startIndex;
            return value.Substring(startIndex, actualLength);
        }

        /// <summary>
        /// <see langword="true"/>, если длинна строки равна нулю.
        /// </summary>
        public static bool Empty(this string @string) {
            return @string.Length == 0;
        }

        /// <summary>
        /// Returns the same <see cref="string"/>, if there is dot on the end.
        /// Returns string with dot on the end instead.
        /// Trimms spaces at the end.
        /// </summary>
        public static string Dot(this string @string) {
            if (@string.Last() == '.') {
                return @string;
            }

            return @string.TrimEnd() + '.';
        }

        #endregion

    }
}

