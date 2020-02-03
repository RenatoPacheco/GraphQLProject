using System.Collections.Generic;

namespace GraphQLProject.API.Source.Commands
{
    public class FindDroidCmd
    {
        public string Keyworks { get; set; }

        public IList<int> Droid { get; set; } = new int[] { };
    }
}