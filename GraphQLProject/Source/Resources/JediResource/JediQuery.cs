using GraphQL.Types;
using GraphQLProject.Source.Services;
using GraphQLProject.Source.Resources.JediResource;

namespace GraphQLProject.Source.JediResource
{
    public class JediQuery : ObjectGraphType
    {
        public JediQuery(JediService service)
        {
            Field<JediType>(
                "jedi", "Get one droid by id",
                arguments: JediGetInputType.Arguments,
                resolve: context => JediGetInputType.Resove(context, service)
              );

            Field<ListGraphType<JediType>>(
              "jedis", "Get lists jedi by param",
              arguments: JediQueryInputType.Arguments,
              resolve: context => JediQueryInputType.Resove(context, service)
            );
        }
    }
}