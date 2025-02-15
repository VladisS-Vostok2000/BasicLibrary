using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.Exceptions
{
    public class ItemNotFoundByIndexException : NotFoundException
    {
        public int Index { get; set; }



        public ItemNotFoundByIndexException(string message, int index) : base(message)
        {
            Index = index;
        }

    }
}
