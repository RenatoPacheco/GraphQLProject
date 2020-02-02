using GraphQL.Types;
using GraphQLProject.Source.Resources.DroidResource.InputTypes;
using GraphQLProject.Source.Resources.JediResource.ObjectTypes;

namespace GraphQLProject.Source.Resources.JediResource
{
    public class JediQuery : ObjectGraphType
    {
        public JediQuery()
        {
            Field<JediType>(
                "jedi", "Get one droid by id",
                arguments: GetInputType.Arguments,
                resolve: context => GetInputType.Resove(context)
              );

            Field<ListGraphType<JediType>>(
              "jedis", "Get lists jedi by param",
              arguments: ListInputType.Arguments,
              resolve: context => ListInputType.Resove(context)
            );
        }
    }
}