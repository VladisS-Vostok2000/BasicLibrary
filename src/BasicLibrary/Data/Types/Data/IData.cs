using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.Data
{
    public interface IData : IReadOnlyData
    {
        // TODO: использовать bit и unsafe
        new bool[] Bits { get; set; }
    }
}
