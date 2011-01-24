using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class IsEqualToAny<T> : Criteria<T>
    {
        List<T> items;

        public IsEqualToAny(params T[] possible_values)
        {
            this.items = new List<T>(possible_values);
        }

        public bool matches(T item)
        {
            return items.Contains(item);
        }
    }
}