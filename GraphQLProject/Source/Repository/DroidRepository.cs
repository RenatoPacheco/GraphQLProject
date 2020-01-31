using GraphQLProject.Source.Models;

namespace GraphQLProject.Source.Repository
{
    public static  class DroidRepository
    {
        public static Droid[] Results => new Droid[] 
        {
            new Droid { Id = 1, Name = "R2-D2" },
            new Droid { Id = 2, Name = "C3-PO" },
            new Droid { Id = 3, Name = "BB-08" }
        };
    }
}