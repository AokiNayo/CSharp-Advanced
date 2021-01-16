using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        public List<T> MyStack { get; set; }

        public CustomStack()
        {
            this.MyStack = new List<T>();
        }

        public void Push(T item)
        {
            this.MyStack.Add(item);
        }

        public T Pop()
        {
            if (this.MyStack.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            var element = this.MyStack[MyStack.Count - 1];
            this.MyStack.RemoveAt(MyStack.Count - 1);
            return element;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.MyStack.Count - 1; i >= 0; i--)
            {
                yield return this.MyStack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
