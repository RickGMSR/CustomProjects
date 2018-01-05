using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace countline
{
    class Program
    {
        static void Main()
        {
            CountLinesInFile(@"\\msrwebxiis\Drawbridge\TraceWindowsLogFiles\ComprLock Compact Tests\ntapid.log");
        }

        /// <summary>
        /// Count the number of lines in the file specified.
        /// </summary>
        /// <param name="f">The filename to count lines in.</param>
        /// <returns>The number of lines in the file.</returns>
        static long CountLinesInFile(string f)
        {
            long count = 0;
            using (StreamReader r = new StreamReader(f))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    count++;
                }
            }
            return count;

        }

    }


}
