namespace SystemDot.MessageRouteInspector.Server.GraphQl
{
    public class GraphQlExecuter
    {
        public string ExecuteQuery(string query)
        {
            return @"{
  ""data"": {
    ""App"": {
		""Routes"": [{
		}]
    }
  }
}";
        }
    }
}