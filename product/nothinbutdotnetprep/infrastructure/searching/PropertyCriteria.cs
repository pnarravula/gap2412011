namespace nothinbutdotnetprep.infrastructure.searching
{
    public class PropertyCriteria<ItemToSearch, PropertyType> : Criteria<ItemToSearch>
    {
        PropertyAccessor<ItemToSearch, PropertyType> accessor;
        Criteria<PropertyType> raw_criteria;

        public PropertyCriteria(PropertyAccessor<ItemToSearch, PropertyType> accessor,
                                Criteria<PropertyType> raw_criteria)
        {
            this.accessor = accessor;
            this.raw_criteria = raw_criteria;
        }

        public bool matches(ItemToSearch item)
        {
            return raw_criteria.matches(accessor(item));
        }
    }


    public class NotCriteriaFactory<ItemToSearch, PropertyType> : Criteria<ItemToSearch>
    {
        PropertyAccessor<ItemToSearch, PropertyType> accessor;
        Criteria<PropertyType> raw_criteria;

        public NotCriteriaFactory(PropertyAccessor<ItemToSearch, PropertyType> accessor,
                                Criteria<PropertyType> raw_criteria)
        {
            this.accessor = accessor;
            this.raw_criteria = raw_criteria;
        }

        public bool matches(ItemToSearch item)
        {
            return !raw_criteria.matches(accessor(item));
        }
    }
}