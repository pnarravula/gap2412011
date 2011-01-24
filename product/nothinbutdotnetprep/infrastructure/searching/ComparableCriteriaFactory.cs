using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<ItemToSearch, PropertyType> : CriteriaFactory<ItemToSearch,PropertyType>
        where PropertyType : IComparable<PropertyType>,new()
    {
        PropertyAccessor<ItemToSearch, PropertyType> accessor;

        CriteriaFactory<ItemToSearch, PropertyType> basic_criteria_factory;

        public ComparableCriteriaFactory(PropertyAccessor<ItemToSearch, PropertyType> accessor, BasicCriteriaFactory<ItemToSearch, PropertyType> basic_criteria_factory)
        {
            this.accessor = accessor;
            this.basic_criteria_factory = basic_criteria_factory;
        }

        public Criteria<ItemToSearch> greater_than(PropertyType value_to_be_greater_than)
        {
            return create_using(new IsGreaterThan<PropertyType>(value_to_be_greater_than));
        }

        public Criteria<ItemToSearch> equal_to(PropertyType value)
        {
            return basic_criteria_factory.equal_to(value);
        }

        public Criteria<ItemToSearch> equal_to_any(params PropertyType[] values)
        {
            return basic_criteria_factory.equal_to_any(values);
        }

        public Criteria<ItemToSearch> create_using(Criteria<PropertyType> real_criteria)
        {
            return basic_criteria_factory.create_using(real_criteria);
        }

        public Criteria<ItemToSearch> not_equal_to_any(params PropertyType[] values)
        {
            return basic_criteria_factory.not_equal_to_any(values);
        }

        public Criteria<ItemToSearch> between(PropertyType start, PropertyType end )
        {
            return create_using(new FallsInRange<PropertyType>(
                new InclusiveRange<PropertyType>(start, end)));
        }

    }
}