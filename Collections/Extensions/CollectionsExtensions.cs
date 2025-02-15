using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;

using BasicLibrary.Collections;

namespace BasicLibrary
{
    public static class CollectionsExtensions {

        #region Array

        /// <summary>
        /// Заполнит массив заданными значениями.
        /// </summary>
        /// <returns> Ссылка на текущий массив. </returns>
        public static T[] Fill<T>(this T[] array, T value) where T : struct {
            for (int i = 0; i < array.Length; i++) {
                array[i] = value;
            }
            return array;
        }
        /// <summary>
        /// Заполнит массив значением, возвращаемым заданным делегатом.
        /// </summary>
        public static T[] Fill<T>(this T[] array, Func<T> action) {
            for (int i = 0; i < array.Length; i++) {
                array[i] = action.Invoke();
            }
            return array;
        }
        /// <summary>
        /// Заполнит массив заданным значением.
        /// </summary>
        public static T[,] Fill<T>(this T[,] array, T value) {
            for (int r = 0; r <= array.GetLength(0); r++) {
                for (int c = 0; c <= array.GetLength(1); c++) {
                    array[r, c] = value;
                }
            }

            return array;
        }

        /// <summary>
        /// Fills array of presented items from presented start index.
        /// If index is greater then array length, the method completed without any error.
        /// If items count more then array length, the method will fill only part of it without any error.
        /// </summary>
        public static void Put<T>(this T[] array, IEnumerable<T> itemsToPaste, int startIndex = 0) {
            IEnumerator<T> enumerator = itemsToPaste.GetEnumerator();
            for (int i = startIndex; i < array.Length; i++) {
                if (enumerator.MoveNext() == false) {
                    return;
                }

                array[startIndex] = enumerator.Current;
            }
        }

        /// <summary>
        /// Создаст нередактируемое отражение <see cref="Array"/>.
        /// </summary>
        public static Slice<T> AsReadOnly<T>(this T[] array) => new Slice<T>(array);
        /// <summary>
        /// Создаст нередактируемое отражение <see cref="Array"/>.
        /// </summary>
        public static ReadOnlyDoubleDemensionArray<T> AsReadOnly<T>(this T[,] array) => new ReadOnlyDoubleDemensionArray<T>(array);

        /// <summary>
        /// <see langword="true"/>, если длинна массива равна нулю.
        /// </summary>
        public static bool Empty<T>(this T[] array) => array.Length == 0;

        /// <summary>
        /// <see langword = "true"/>, если массив имеет два ненулевых измерения.
        /// </summary>
        public static bool IsEmptyOrFlat<T>(this T[,] array) => array.GetLength(0) == -1 || array.GetLength(1) == -1;

        /// <summary>
        /// <see langword="true"/>, если индексация корректна.
        /// </summary>
        public static bool IndexCorrect<T>(this T[,] array, Point target) {
            return target.X < array.GetLength(1) && target.Y < array.GetLength(0);
        }

        /// <summary>
        /// Заменяет один найденный элемент в массиве на заданный.
        /// </summary>
        public static void Replase<T>(this T[,] array, T target, T substitute) {
            for (int r = 0; r < array.GetLength(0); r++) {
                for (int c = 0; c < array.GetLength(1); c++) {
                    if (ReferenceEquals(target, array[r, c])) {
                        array[r, c] = substitute;
                    }
                }
            }
        }

        public static IEnumerator<T> GetEnumerator<T>(this T[] array) {
            return (IEnumerator<T>)array.GetEnumerator();
        }

        #endregion


        #region IEnumerable<T>

        /// <summary>
        /// <see langword="true"/>, если коллекция пуста.
        /// </summary>
        public static bool Empty<T>(this IEnumerable<T> enumerable) => !enumerable.Any();

        /// <summary>
        /// Вставляет заданный <see cref="IEnumerable{T}"/> в начало <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <returns> Новый объект <see cref="IEnumerable{T}"/>. </returns>
        public static IEnumerable<T> AppendRange<T>(this IEnumerable<T> enumerable, IEnumerable<T> insertedEnum) {
            var outEnum = new Collection<T>();
            outEnum.AddRange(insertedEnum);
            outEnum.AddRange(enumerable);
            return outEnum;
        }

        /// <summary>
        /// Вставляет заданный <see cref="IEnumerable{T}"/> в начало <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="insertedEnum"></param>
        /// <returns></returns>
        public static IEnumerable<T> PrependRange<T>(this IEnumerable<T> enumerable, IEnumerable<T> insertedEnum) {
            var outEnum = new Collection<T>();
            outEnum.AddRange(enumerable);
            outEnum.AddRange(insertedEnum);
            return outEnum;
        }

        /// <summary>
        /// <see langword="true"/>, если последовательности равны
        /// (равны их длины, порядок элементов и равенство по заданной
        /// функции) или они тождественны.
        /// </summary>
        public static bool SequenceEqual<T>(this IEnumerable<T> enumerable, IEnumerable<T> other, Predicate<T> equalityComparer) {
            if (ReferenceEquals(enumerable, other)) {
                return true;
            }

            if (other == null) {
                return false;
            }

            if (enumerable.Count() != other.Count()) {
                return false;
            }

            var otherEnumerator = other.GetEnumerator();
            otherEnumerator.MoveNext();
            foreach (var thisItem in enumerable) {
                if (!equalityComparer(thisItem, otherEnumerator.Current)) {
                    return false;
                }

                otherEnumerator.MoveNext();
            }

            return true;
        }

        /// <summary>
        /// <see langword="true"/>, если соответствующий заданному условию элемент содержится в коллекции.
        /// </summary>
        public static bool Contains<T>(this IEnumerable<T> enumerable, System.Predicate<T> predicate) {
            foreach (var t in enumerable) {
                if (predicate(t)) {
                    return true;
                }
            }

            return false;
        }

        #endregion


        #region ICollection, IReadOnlyCollection

        /// <summary>
        /// <see langword="true"/>, если коллекция пуста.
        /// </summary>
        public static bool Empty<T>(this IReadOnlyCollection<T> sourse) => sourse.Count == 0;

        /// <summary>
        /// <see langword="true"/>, если содержит определяемое делегатом значение.
        /// </summary>
        public static bool Contains<T1>(this ICollection<T1> colletion, System.Predicate<T1> predicate) {
            foreach (var item in colletion) {
                if (predicate(item)) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Возвращает первое с начала вхождение элемента в коллекции, соответствующего заданному предикату.
        /// </summary>
        public static bool TryGet<T>(this ICollection<T> collection, System.Predicate<T> predicate, out T outItem) {
            foreach (var item in collection) {
                if (predicate(item)) {
                    outItem = item;
                    return true;
                }
            }
            outItem = default;
            return false;
        }

        /// <summary>
        /// Вставляет коллекцию элементов в конец текущей.
        /// </summary>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> input) {
            foreach (var item in input) {
                collection.Add(item);
            }
        }

        /// <summary>
        /// Удаляет последний элемент коллекции.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public static void RemoveLastItem<T>(this ICollection<T> collection) {
            if (collection.Empty()) { throw new InvalidOperationException("Коллекция пуста."); }
            T removingItem = default;
            foreach (var item in collection) {
                removingItem = item;
            }
            collection.Remove(removingItem);
        }

        /// <summary>
        /// <see langword="true"/>, если все элементы последовательности равны между собой.
        /// </summary>
        public static bool IsEven<T>(this IList<T> list) where T : IEquatable<T> {
            if (list.Empty()) {
                throw new ArgumentException("Коллекция пуста.");
            }
            if (list.Count == 1) {
                return true;
            }

            for (int i = 0; i < list.Count - 1; i++) {
                if (!list[i].Equals(list[i + 1])) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Присвоит последнему элементу листа значение.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public static void SetLast<T>(this IList<T> list, T value) {
            if (list.Empty()) {
                throw new InvalidOperationException("Лист пуст.");
            }

            list[list.Count - 1] = value;
        }

        #endregion


        #region IList

        /// <summary>
        /// Вставляет элемент в начало <see cref="IList{T}"/>.
        /// </summary>
        /// <returns> Ссылка на текущий экземпляр. </returns>
        public static IList<T> AddHead<T>(this IList<T> list, T item) {
            list.Insert(0, item);
            return list;
        }

        /// <summary>
        /// Добавит заданную <see cref="IEnumerable{T}"/> в начало списка.
        /// </summary>
        /// <returns> Текущий <see cref="IList{T}"/>. </returns>
        public static IList<T> AddHeadRange<T>(this IList<T> iList, IEnumerable<T> insertedHead) {
            IList<T> temp = new List<T>();
            temp.AddRange(insertedHead);
            temp.AddRange(iList);
            iList.Clear();
            iList.AddRange(temp);
            return iList;
        }

        /// <summary>
        /// Удалит первый элемент, удовлетворяющий <paramref name="finder"/>.
        /// Выдаст исключение, если элемент не найден.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public static void RemoveFirst<T>(this IList<T> iList, Func<T, bool> finder) {
            iList.Remove(iList.First(finder));
        }

        /// <summary>
        /// Удалит все элементы, которые удовлетворяют заданному <paramref name="finder"/>.
        /// </summary>
        public static void RemoveAll<T>(this IList<T> iList, Func<T, bool> finder) {
            for (int i = 0; i < iList.Count; i++) {
                bool shouldRemove = finder(iList[i]);
                if (shouldRemove) {
                    iList.RemoveAt(i);
                    i--;
                }
            }
        }

        ///
        /// <exception cref="InvalidOperationException"></exception>
        public static void RemoveLast<T>(this IList<T> iList) {
            if (iList.Empty()) {
                throw new InvalidOperationException("List already empty.");
            }

            iList.RemoveAt(iList.Count - 1);
        }

        /// 
        /// <exception cref="InvalidOperationException"></exception>
        public static void RemoveFirst<T>(this IList<T> iList) {
            if (iList.Empty()) {
                throw new InvalidOperationException("List is already empty.");
            }

            iList.RemoveAt(0);
        }

        #endregion


        #region Dictionary<T, T>

        public static TKey FirstKeyByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value) {
            bool found = dictionary.TryGetFirstKeyByValue(valueInDictionary => EqualityComparer<TValue>.Default.Equals(valueInDictionary, value), out TKey key);
            if (!found) {
                throw new InvalidOperationException($"No value found in {nameof(dictionary)}. Value was {value}.");
            }

            return key;
        }
        public static TKey FirstKeyByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, System.Predicate<TValue> predicate) {
            foreach (var keyValuePair in dictionary) {
                if (predicate(keyValuePair.Value)) {
                    return keyValuePair.Key;
                }
            }

            throw new InvalidOperationException($"{nameof(dictionary)} not contains corresponding value.");
        }
        public static bool TryGetFirstKeyByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value, out TKey result) {
            return dictionary.TryGetFirstKeyByValue(valueInDictionary => EqualityComparer<TValue>.Default.Equals(valueInDictionary, value), out result);
        }
        public static bool TryGetFirstKeyByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, System.Predicate<TValue> predicate, out TKey result) {
            foreach (var keyValuePair in dictionary) {
                if (predicate(keyValuePair.Value)) {
                    result = keyValuePair.Key;
                    return true;
                }
            }

            result = default;
            return false;
        }

        public static bool ContainsValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value) {
            foreach (var keyValuePair in dictionary) {
                if (EqualityComparer<TValue>.Default.Equals(keyValuePair.Value, value)) {
                    return true;
                }
            }

            return false;
        }

        public static TKey FirstKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, System.Predicate<TKey> predicate) {
            return dictionary.First(keyValuePair => predicate(keyValuePair.Key)).Key;
        }

        #endregion


        #region HashSet<T>

        public static IReadOnlyCollection<T> AsReadOnly<T>(this HashSet<T> hashSet) {
            return new HashSetReadOnlyCollection<T>(hashSet);
        } 

        #endregion

    }
}
