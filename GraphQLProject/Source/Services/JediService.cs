using GraphQLProject.Source.Commands;
using GraphQLProject.Source.Models;
using GraphQLProject.Source.Repository;
using System.Linq;

namespace GraphQLProject.Source.Services
{
    public class JediService
    {
        public Jedi[] Query(QueryJediCmd command)
        {
            Jedi[] result = new Jedi[] { };

            result = JediRepository.Results.Where(
                      x => (!command.Jedi.Any() || command.Jedi.Contains(x.Id))
                      && (command.Keyworks == null || command.Keyworks == x.Name)).ToArray();

            return result;
        }
    }
}