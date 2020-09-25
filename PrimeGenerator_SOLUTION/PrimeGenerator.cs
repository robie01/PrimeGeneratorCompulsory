using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGenerator_SOLUTION
{
    public class PrimeGenerator
    {

       public async Task<List<long>> GetPrimesSequential(int from, int to)
       => await Task.Factory.StartNew(() => {
           return PrimeSequential(from, to).ToList();
       });
        private IEnumerable<long> PrimeSequential(int from, int to)
        {
            bool[] pno = new bool[to + 1];
            for (int i = 0; i < pno.Count(); i++)
                pno[i] = true;
            int sqrt = (int)Math.Sqrt(to);
            for (int i = 2; i <= sqrt; i++)
            {
                if (pno[i] == true)
                {
                    for (int j = i * 2; j <= to; j += i)
                        pno[j] = false;
                }
            }
            for (long i = from < 2 ? 2 : from; i <= to; i++)
                if (pno[i])
                    yield return i;
        }

       
        public async Task<List<long>> GetPrimesParallel(int from, int to)
        => await Task.Factory.StartNew(() =>
        {
            return PrimesParallel(from, to).ToList();
        });
        private IEnumerable<long> PrimesParallel(int from, int to)
        {
            bool[] pno = new bool[to + 1];
            for (int i = 0; i < pno.Count(); i++) pno[i] = true;
            int sqrt = (int)Math.Sqrt(to);
           
            int threads = to < 24 ? 2 : 24;
            for (int i = 2; i <= sqrt; i += threads)
            {
                Task[] tasks = new Task[threads];
                for (int j = 0; j < threads; j++)
                {
                    int h = i + j;
                    var t = Task.Factory.StartNew(() =>
                    {
                        MarkNotPrimes(pno, h, to);
                    });
                    tasks[j] = t;
                }
                Task.WaitAll(tasks);
            }
            for (long i = from > 2 ? from : 2; i <= to; i++)
                if (pno[i])
                    yield return i;

        }
        private void MarkNotPrimes(bool[] pno, int i, int to)
        {
            if (pno[i] == true)
            {
                for (int j = i * 2; j <= to; j += i)
                    pno[j] = false;
            }
        }
    }


}
