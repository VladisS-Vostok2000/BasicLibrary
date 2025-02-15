using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.Collections.Abstract
{
    public interface IReadOnlyDoubleDemensionArray<TValue> : IReadOnlyCollection<TValue>
    {
        TValue this[int index1, int index2] { get; }
    }
}
