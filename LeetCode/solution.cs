using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class SolutionIter : IEnumerable<int>
{
    private StreamReader reader;
    public SolutionIter(StreamReader stream)
    {
        //reader = new StreamReader(stream);
        reader = stream;

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return null;
    }

    IEnumerator<int> IEnumerable<int>.GetEnumerator( )
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            int result = 0;
            line = line.Trim();
            if (Int32.TryParse(line, out result))
            {
                if (result >= -1000000000 && result <= 1000000000)
                {
                    yield return result;
                }
            }
        }
    }

}

public class Test
{
    public void Run()
    {
        StreamReader stream = new StreamReader(@"D:\Document\exceltest\test.txt");
        IEnumerable<int> it = new SolutionIter(stream);
        int[] arr = it.ToArray();

    }
    
}