using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BasicLibrary.Collections.Abstract;

namespace BasicLibrary.Collections {
    public sealed class ReadOnlyDoubleDemensionArray<TValue> : IReadOnlyDoubleDemensionArray<TValue>
    {
        private readonly TValue[,] array;



        public int Count => array.Length;
        public bool IsReadOnly => true;



        public TValue this[int index1, int index2] => array[index1, index2];



        public bool Contains(TValue item) => throw new NotImplementedException();
        public void CopyTo(TValue[] array, int arrayIndex) => throw new NotImplementedException();
        public IEnumerator<TValue> GetEnumerator() => throw new NotImplementedException();
        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();

    }
}
