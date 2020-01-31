using GraphQL.Types;
using GraphQLProject.Source.Resources.DroidResource;
using GraphQLProject.Source.Services;

namespace GraphQLProject.Source.DroidResource
{
    public class DroidQuery : ObjectGraphType
    {
        public DroidQuery(DroidService service)
        {
            Field<DroidType>(
                "droid", "Get one droid by id",
                arguments: DroidGetInputType.Arguments,
                resolve: context => DroidGetInputType.Resove(context, service)
              );

            Field<ListGraphType<DroidType>>(
              "droids", "Get lists droid by param",
              arguments: DroidQueryInputType.Arguments,
              resolve: context => DroidQueryInputType.Resove(context, service)
            );
        }
    }
}