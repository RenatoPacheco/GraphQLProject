using GraphQL.Types;
using GraphQLProject.Source.Resources.DroidResource;
using GraphQLProject.Source.Resources.JediResource;

namespace GraphQLProject.Source
{
    public class StarWarsQuery : ObjectGraphType
    {
        public StarWarsQuery()
        {
            JediQuery();
            DroidQuery();
        }

        public void JediQuery()
        {
            Field<JediType>(
                "jedi", "Get one droid by id",
                arguments: JediGetInputType.Arguments,
                resolve: context => JediGetInputType.Resove(context)
              );

            Field<ListGraphType<JediType>>(
              "jedis", "Get lists jedi by param",
              arguments: JediQueryInputType.Arguments,
              resolve: context => JediQueryInputType.Resove(context)
            );
        }

        public void DroidQuery()
        {
            Field<DroidType>(
                "droid", "Get one droid by id",
                arguments: DroidGetInputType.Arguments,
                resolve: context => DroidGetInputType.Resove(context)
              );

            Field<ListGraphType<DroidType>>(
              "droids", "Get lists droid by param",
              arguments: DroidQueryInputType.Arguments,
              resolve: context => DroidQueryInputType.Resove(context)
            );
        }
    }
}