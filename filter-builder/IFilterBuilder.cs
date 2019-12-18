namespace filter_builder
{
    public interface IFilterBuilder
    {
        string Build();

        FilterBuilder Equals(string field, string value, bool onlyIfHasValue = true);

        FilterBuilder StartsWith(string field, string value, bool onlyIfHasValue = true);
    }
}
