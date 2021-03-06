﻿using GraphQL.Types;
using GraphQLProject.API.Source.Commands;

namespace GraphQLProject.API.Source.Resources.JediResource.InputTypes
{
    public class CreateInputType : InputObjectGraphType<CreateJediCmd>
    {
        public CreateInputType()
        {
            Name = "CreateInput";

            Field(d => d.Name, nullable: false)
                .Name("name")
                .Description("Set name person");

            Field(d => d.Side, nullable: false)
                .Name("side")
                .Description("Set side person");
        }
    }
}