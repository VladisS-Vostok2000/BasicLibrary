using BasicLibrary.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.Data
{
    public interface IReadOnlyData : IReadOnlyArray<IReadOnlyBit>
    {
        // TODO: использовать bit и unsafe
        Array<IReadOnlyBit> Bits { get; }

    }
}
