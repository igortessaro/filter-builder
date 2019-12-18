using System;

namespace filter_builder.application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IFilterBuilder filterBuilder = new FilterBuilder();

            Console.WriteLine(filterBuilder.Build());

            filterBuilder.Equals("id", "1020")
                .Equals("name", "Fulano")
                .StartsWith("desciption", "Teste");

            Console.WriteLine(filterBuilder.Build());

            Console.ReadKey();
        }
    }
}
