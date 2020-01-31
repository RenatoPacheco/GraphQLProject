using GraphQLProject.Source.Models;

namespace GraphQLProject.Source.Repository
{
    public static  class JediRepository
    {
        public static Jedi[] Results => new Jedi[] 
        {
            new Jedi { Id = 1, Name = "Person 001", Side = "Dark" },
            new Jedi { Id = 2, Name = "Person 002", Side = "Light" },
            new Jedi { Id = 3, Name = "Person 003", Side = "Light" },
            new Jedi { Id = 4, Name = "Person 004", Side = "Dark" }
        };
    }
}