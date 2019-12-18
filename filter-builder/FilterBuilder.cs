using System.Collections.Generic;
using System.Linq;

namespace filter_builder
{
    public sealed class FilterBuilder : IFilterBuilder
    {
        private IDictionary<int, Filter> Filters { get; set; }

        public FilterBuilder()
        {
            this.Filters = new Dictionary<int, Filter>();
        }

        public string Build()
        {
            if (this.Filters == null || !this.Filters.Any())
            {
                return string.Empty;
            }

            string[] filters = this.Filters
                .Select(x => $"Filter[{x.Key}][{x.Value.Field}:{x.Value.Operation.ToString()}:{x.Value.Value}]")
                .ToArray();

            return string.Join('&', filters);
        }

        public FilterBuilder Equals(string field, string value, bool onlyIfHasValue = true)
        {
            return this.AddFilter(field, value, Operation.Equals, onlyIfHasValue);
        }

        public FilterBuilder StartsWith(string field, string value, bool onlyIfHasValue = true)
        {
            return this.AddFilter(field, value, Operation.StartsWith, onlyIfHasValue);
        }

        private FilterBuilder AddFilter(string field, string value, Operation operation, bool onlyIfHasValue = true)
        {
            if (onlyIfHasValue && string.IsNullOrEmpty(value))
            {
                return this;
            }

            this.Filters.Add(this.Filters.Count, new Filter(field, value, operation));

            return this;
        }
    }
}
