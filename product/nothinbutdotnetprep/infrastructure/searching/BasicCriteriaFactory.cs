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

        public CriteriaFactory<ItemToSearch, PropertyType> not
        {
            get { return new NotBasicCriteriaFactory<ItemToSearch, PropertyType>(this); }
            
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

    public class NotBasicCriteriaFactory<ItemToSearch, PropertyType> : CriteriaFactory<ItemToSearch, PropertyType>
    {
        PropertyAccessor<ItemToSearch, PropertyType> accessor;

        public NotBasicCriteriaFactory(BasicCriteriaFactory<ItemToSearch,PropertyType> basicCriteriaFactory)
        {
            this.basicCriteriaFactory = basicCriteriaFactory;
        }

      

        public Criteria<ItemToSearch> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        public Criteria<ItemToSearch> equal_to_any(params PropertyType[] values)
        {
            return new NotCriteria<ItemToSearch>(basicCriteriaFactory.equal_to_any(values));
        }

        public Criteria<ItemToSearch> create_using(Criteria<PropertyType> real_criteria)
        {

            return new NotCriteria<ItemToSearch>(basicCriteriaFactory.create_using(real_criteria));
        }

        public Criteria<ItemToSearch> not_equal_to_any(params PropertyType[] values)
        {
             return new NotCriteria<ItemToSearch>(basicCriteriaFactory.not_equal_to_any(values));
        }


        private BasicCriteriaFactory<ItemToSearch, PropertyType> basicCriteriaFactory;
    }
}