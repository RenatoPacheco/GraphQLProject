using GraphQLProject.Source.Commands;
using GraphQLProject.Source.Models;
using GraphQLProject.Source.Repository;
using System.Linq;

namespace GraphQLProject.Source.Services
{
    public class DroidService
    {
        public Droid[] Query(QueryDroidCmd command)
        {
            Droid[] result = new Droid[] { };

            result = DroidRepository.Results.Where(
                      x => (!command.Droid.Any() || command.Droid.Contains(x.Id))
                      && (command.Keyworks == null || command.Keyworks == x.Name)).ToArray();

            return result;
        }
    }
}