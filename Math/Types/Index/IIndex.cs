using BasicLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.Math
{
    public interface IIndex : IReadOnlyIndex, IData
    {
        new IData Index { get; set; }

    }
}
