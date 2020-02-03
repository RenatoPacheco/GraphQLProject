using Newtonsoft.Json.Linq;
using System.Json;

namespace GraphQLProject.Models
{
    public class DataGraphQL
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }        
        public JObject Variables { get; set; }
        public bool EnableMetrics { get; set; }
    }
}