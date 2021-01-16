using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        public List<T> Collection { get; set; }
        private int index;

        public ListyIterator(params T[] collection)
        {
            this.Collection = new List<T>(collection);
            this.index = 0;
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            return this.index < this.Collection.Count - 1; 
            // 0 1 2 
            // 5 4 3 - 3 elements
        }
        public void Print()
        {
            if (this.Collection.Count == 0)
                throw new InvalidOperationException("Invalid Operation!");
            Console.WriteLine(this.Collection[this.index]);
        }
        public void PrintAll()
        {
            if (this.Collection.Count == 0)
                throw new InvalidOperationException("Invalid Operation!");
            foreach (var item in Collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Collection.Count; i++)
            {
                yield return this.Collection[i];
            }
        }
    }
}
