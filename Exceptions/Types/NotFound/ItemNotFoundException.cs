using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.Exceptions
{
    public class ItemNotFoundException<T> : NotFoundException
    {
        public T Item { get; }



        public ItemNotFoundException(string message, T item) : base(message)
        {
            Item = item;
        }

    }
}
