using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class BasicCriteriaFactory<ItemToSearch, PropertyType> : CriteriaFactory<ItemToSearch, PropertyType>
    {
        PropertyAccessor<ItemToSearch, PropertyType> accessor;

        public BasicCriteriaFactory(PropertyAccessor<ItemToSearch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToSearch> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        public Criteria<ItemToSearch> equal_to_any(params PropertyType[] values)
        {
            return create_using(new IsEqualToAny<PropertyType>(values));
        }

        public Criteria<ItemToSearch> create_using(Criteria<PropertyType> real_criteria)
        {
            return new PropertyCriteria<ItemToSearch, PropertyType>(accessor,
                                                                    real_criteria);
        }

        public Criteria<ItemToSearch> not_equal_to_any(params PropertyType[] values)
        {
            return new NotCriteria<ItemToSearch>(equal_to_any(values));
        }

    }
}