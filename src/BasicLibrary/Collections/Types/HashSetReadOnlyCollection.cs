using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.Collections {
    public class HashSetReadOnlyCollection<T> : IReadOnlyCollection<T> {
        public int Count => HashSet.Count;



        private HashSet<T> HashSet { get; }



        public HashSetReadOnlyCollection(HashSet<T> hashSet) {
            HashSet = hashSet;
        }



        public IEnumerator<T> GetEnumerator() => HashSet.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => HashSet.GetEnumerator();

    }
}
