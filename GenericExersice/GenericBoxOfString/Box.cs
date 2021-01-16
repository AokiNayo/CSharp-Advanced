using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T> where T : IComparable
    {
        public List<T> Values { get; set; }

        public Box(List<T> values)
        {
            this.Values = new List<T>();
            this.Values = values;
        }


        public void Swap(int first, int second)
        {
            T temp = Values[first];
            Values[first] = Values[second];
            Values[second] = temp;
        }

        public int CountOfGreaterValues(List<T> list, T element)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (element.CompareTo(item) < 0)
                {
                    count++;
                }
            }
            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.Values)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().Trim();
        }
    }
}
