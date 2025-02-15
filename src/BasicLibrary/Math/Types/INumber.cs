using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary {
    public interface INumber {
        INumber NumbersAdd(INumber number);
        INumber NumbersSubstract(INumber number);
        INumber NumbersMultiply(INumber number);
        INumber NumbersDivide(INumber number);

        void Add(INumber number);
        void Substract(INumber number);
        void Multiply(INumber number);
        void Divide(INumber number);
    }
}
