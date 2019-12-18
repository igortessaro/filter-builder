namespace filter_builder
{
    public sealed class Filter
    {
        public Filter(string field, string value, Operation operation)
        {
            this.Field = field;
            this.Value = value;
            this.Operation = operation;
        }

        public string Field { get; set; }

        public string Value { get; set; }

        public Operation Operation { get; set; }
    }
}
