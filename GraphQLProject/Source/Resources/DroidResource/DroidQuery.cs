using GraphQL.Types;
using GraphQLProject.Source.Resources.DroidResource.InputTypes;
using GraphQLProject.Source.Resources.DroidResource.ObjectTypes;

namespace GraphQLProject.Source.Resources.DroidResource
{
    public class DroidQuery : ObjectGraphType
    {
        public DroidQuery()
        {

            Field<DroidType>(
                "droid", "Get one droid by id",
                arguments: GetInputType.Arguments,
                resolve: context => GetInputType.Resove(context)
                );

            Field<ListGraphType<DroidType>>(
                "droids", "Get lists droid by param",
                arguments: ListInputType.Arguments,
                resolve: context => ListInputType.Resove(context)
            );
        }
    }
}