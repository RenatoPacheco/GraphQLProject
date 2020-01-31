using System.Json;

namespace GraphQLProject.Models
{
    public class DataGraphQL
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }        
        public object Variables { get; set; }
    }
}