﻿using GraphQL.Types;
using GraphQLProject.API.Source.Commands;

namespace GraphQLProject.API.Source.Resources.JediResource.InputTypes
{
    public class FindInputType : InputObjectGraphType<FindJediCmd>
    {
        public FindInputType()
        {
            Field(d => d.Jedi, nullable: true)
                .Name("jedi")
                .Description("List ids jedis");
            
            Field(d => d.Keyworks, nullable: true)
                .Name("keyworks")
                .Description("Text jedis");
        }
    }
}