using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLibrary.IO
{
    public static class Extensions
    {
        public static List<string> ReadFile(string path)
        {
            List<string> strings = new List<string>();
            StreamReader streamReader = new StreamReader(path);
            while (streamReader.EndOfStream)
            {
                strings.Add(streamReader.ReadLine());
            }
            streamReader.Dispose();
            return strings;
        }
    }
}
