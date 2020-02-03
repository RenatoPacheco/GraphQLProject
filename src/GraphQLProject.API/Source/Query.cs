using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLProject.Source
{
    public class Query : ObjectGraphType<object>
    {
        [GraphQLMetadata("jedis")]
        public IEnumerable<Jedi> GetJedis()
        {
            return StarWarsDB.GetJedis();
        }

        [GraphQLMetadata("jedi")]
        public Jedi GetJedi(int? id = null, string name = null, string side = null)
        {
            return StarWarsDB.GetJedis().SingleOrDefault(j => 
                (id == null || j.Id == id) 
                && (name == null || j.Name == name) 
                && (side == null || j.Side == side));
        }

        [GraphQLMetadata("hello")]
        public string GetHello()
        {
            return "Hello Query class";
        }
    }
}