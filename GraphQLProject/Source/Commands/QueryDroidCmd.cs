using System.Collections.Generic;

namespace GraphQLProject.Source.Commands
{
    public class QueryDroidCmd
    {
        public string Keyworks { get; set; }

        public IList<int> Droid { get; set; } = new int[] { };
    }
}