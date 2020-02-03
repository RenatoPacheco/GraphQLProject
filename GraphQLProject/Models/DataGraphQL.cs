using GraphQLProject.Source;
using Newtonsoft.Json.Linq;

namespace GraphQLProject.Models
{
    public class DataGraphQL : IDataGraphQL
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }        
        public JObject Variables { get; set; }
        public bool EnableMetrics { get; set; }
    }
}