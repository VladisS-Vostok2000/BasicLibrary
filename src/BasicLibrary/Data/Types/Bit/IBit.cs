using BasicLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.Data
{
    [Obsolete("Использовать unsafe вместо", true)]
    public interface IBit : IEquatable<IBit>, IDefault<IBit>, IReadOnlyBit, IReadOnlyable<IReadOnlyBit>, IImmutable<IReadOnlyBit>
    {
        //public abstract static bool operator true(IReadOnlyBit bit);
        //public abstract static bool operator false(IReadOnlyBit bit);
        //public abstract static IReadOnlyBit operator ==(IReadOnlyBit left, IReadOnlyBit right);
        //public abstract static IReadOnlyBit operator !=(IReadOnlyBit left, IReadOnlyBit right);
        //public abstract static IReadOnlyBit operator &(IReadOnlyBit left, IReadOnlyBit right);
        //public abstract static IReadOnlyBit operator |(IReadOnlyBit left, IReadOnlyBit right);
        //public abstract static IReadOnlyBit operator ~(IReadOnlyBit left, IReadOnlyBit right);
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

        void SetAsInvert();

        void SetAsAND(IReadOnlyBit other);
        // 1 + 0 -> 1
        void SetAsS1(IReadOnlyBit other);
        // 1 + 0 -> 1
        // 1 + 1 -> 1
        void SetAsS2(IReadOnlyBit other);
        // 0 + 1 -> 1
        void SetAsS3(IReadOnlyBit other);
        // 0 + 1 -> 1
        // 1 + 1 -> 1
        void SetAsS4(IReadOnlyBit other);

        void SetAsXOR(IReadOnlyBit other);

        void SetAsOR(IReadOnlyBit other);

        // 0 + 0 -> 1
        void SetAsNOR(IReadOnlyBit other);

        void SetAsEquals(IReadOnlyBit other);

        // 1 + 1 -> 1
        // 1 + 0 -> 1
        void SetAsS7(IReadOnlyBit other);

        // 1 + 0 -> 0
        void SetAsCoerse(IReadOnlyBit other);
        // 0 + 0 -> 1
        // 0 + 1 -> 1
        void SetAsS9(IReadOnlyBit other);

        void SetAsImplication(IReadOnlyBit other);

        // 1 + 1 -> 0
        void SetAsNAND(IReadOnlyBit other);

        void SetAsAND(IBit other);
        // 1 + 0 -> 1
        void SetAsS1(IBit other);
        // 1 + 0 -> 1
        // 1 + 1 -> 1
        void SetAsS2(IBit other);
        // 0 + 1 -> 1
        void SetAsS3(IBit other);
        // 0 + 1 -> 1
        // 1 + 1 -> 1
        void SetAsS4(IBit other);

        void SetAsXOR(IBit other);

        void SetAsOR(IBit other);

        // 0 + 0 -> 1
        void SetAsNOR(IBit other);

        void SetAsEquals(IBit other);

        // 1 + 1 -> 1
        // 1 + 0 -> 1
        void SetAsS7(IBit other);

        // 1 + 0 -> 0
        void SetAsCoerse(IBit other);
        // 0 + 0 -> 1
        // 0 + 1 -> 1
        void SetAsS9(IBit other);

        void SetAsImplication(IBit other);

        // 1 + 1 -> 0
        void SetAsNAND(IBit other);

    }
}
