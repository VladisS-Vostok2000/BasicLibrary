using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.Collections {
    /// <summary>
    /// Предоставляет проекцию массива.
    /// Может быть изменён родителем.
    /// </summary>
    [Obsolete("Slice уже создан в более новых версиях.")]
    public sealed class Slice<T> : IReadOnlyList<T> {
        private readonly T[] array;
        public int Count => array.Length;



        public Slice(IList<T>[] sourse, int lowerIndex, int upperIndex) {
            //array = sourse ?? throw new ArgumentNullException($"{nameof(sourse)}");
        }



        public T this[int index] {
            get {
                return array[index];
            }
        }



        public IEnumerator<T> GetEnumerator() => (IEnumerator<T>)array.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => array.GetEnumerator();

    }
}
