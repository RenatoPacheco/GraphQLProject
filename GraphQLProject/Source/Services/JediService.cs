using System.Linq;
using GraphQLProject.Source.Models;
using GraphQLProject.Source.Commands;
using GraphQLProject.Source.Repository;

namespace GraphQLProject.Source.Services
{
    public class JediService
    {
        public Jedi[] Find(FindediCmd command)
        {
            Jedi[] result = new Jedi[] { };

            result = JediRepository.Results.Where(
                      x => (!command.Jedi.Any() || command.Jedi.Contains(x.Id))
                      && (command.Keyworks == null || command.Keyworks == x.Name)).ToArray();

            return result;
        }

        public Jedi Get(int id)
        {
            Jedi result = null;

            result = JediRepository.Results.FirstOrDefault(x => x.Id == id);

            return result;
        }
    }
}