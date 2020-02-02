using System.Linq;
using GraphQLProject.Source.Models;
using GraphQLProject.Source.Commands;
using GraphQLProject.Source.Repository;

namespace GraphQLProject.Source.Services
{
    public class DroidService
    {
        public Droid[] Find(FindDroidCmd command)
        {
            Droid[] result = new Droid[] { };

            result = DroidRepository.Results.Where(
                      x => (!command.Droid.Any() || command.Droid.Contains(x.Id))
                      && (command.Keyworks == null || command.Keyworks == x.Name)).ToArray();

            return result;
        }

        public Droid Get(int id)
        {
            Droid result = null;

            result = DroidRepository.Results.FirstOrDefault(x => x.Id == id);

            return result;
        }
    }
}