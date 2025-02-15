using BasicLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.Data
{
    public interface IReadOnlyBit : IEquatable<IReadOnlyBit>, IDefault<IReadOnlyBit>, ICloneable<IReadOnlyBit>, ICloneable<IBit>
    {
        // TODO: update CLR
        //public abstract static bool operator true(IReadOnlyBit bit);
        //public abstract static bool operator false(IReadOnlyBit bit);
        //public abstract static IReadOnlyBit operator ==(IReadOnlyBit left, IReadOnlyBit right);
        //public abstract static IReadOnlyBit operator !=(IReadOnlyBit left, IReadOnlyBit right);
        //public abstract static IReadOnlyBit operator &(IReadOnlyBit left, IReadOnlyBit right);
        //public abstract static IReadOnlyBit operator |(IReadOnlyBit left, IReadOnlyBit right);
        //public abstract static IReadOnlyBit operator ~(IReadOnlyBit left, IReadOnlyBit right);
        //public abstract static IReadOnlyBit operator ^(IReadOnlyBit left, IReadOnlyBit right);
        //public abstract static IReadOnlyBit operator !(IReadOnlyBit left, IReadOnlyBit right);

        // 1 + 0 -> 1
        IReadOnlyBit S1(IReadOnlyBit other);
        // 1 + 0 -> 1
        // 1 + 1 -> 1
        IReadOnlyBit S2(IReadOnlyBit other);
        // 0 + 1 -> 1
        IReadOnlyBit S3(IReadOnlyBit other);
        // 0 + 1 -> 1
        // 1 + 1 -> 1
        IReadOnlyBit S4(IReadOnlyBit other);

        // 0 + 0 -> 1
        IReadOnlyBit NOR(IReadOnlyBit other);

        // 1 + 1 -> 1
        // 1 + 0 -> 1
        IReadOnlyBit S7(IReadOnlyBit other);

        // 1 + 0 -> 0
        IReadOnlyBit Coerse(IReadOnlyBit other);
        // 0 + 0 -> 1
        // 0 + 1 -> 1
        IReadOnlyBit S9(IReadOnlyBit other);

        IReadOnlyBit Implication(IReadOnlyBit other);

        // 1 + 1 -> 0
        IReadOnlyBit NAND(IReadOnlyBit other);

    }
}
