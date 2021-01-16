using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        public List<int> Stones { get; set; }

        public Lake(params int[] stones)
        {
            this.Stones = stones.ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Stones.Count; i += 2)
            {
                yield return this.Stones[i];
            }

            for (int i = Stones.Count - 1; i > 0; i--)
            {
                if (i % 2 != 0)
                    yield return this.Stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
