using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLProject.Source
{
    public interface IDataGraphQL
    {
        string OperationName { get; }
        string NamedQuery { get; }
        string Query { get; }
        JObject Variables { get; }
        bool EnableMetrics { get; }
    }
}