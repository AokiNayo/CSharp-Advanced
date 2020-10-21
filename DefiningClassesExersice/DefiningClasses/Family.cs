using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> People { get; set; }

        public Family()
        {
            People = new List<Person>();
        }


        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
            => People.OrderByDescending(x => x.Age).First();

        public List<Person> SortByMoreThanAge()
            => People.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
    }
}
