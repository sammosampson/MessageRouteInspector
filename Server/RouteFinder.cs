namespace SystemDot.MessageRouteInspector.Server
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SystemDot.MessageRouteInspector.Server.Queries;

    public class RouteFinder
    {
        static GetRoutesQueryResponse getRoutesQueryResponse;

        public static Task Initialise()
        {
            var root = new Message
            {
                Id = 1,
                Name = "GenerateIntermediateFiles",
                CloseBranchCount = 0
            };

            var nextmessage = new Message
            {
                Id = 2,
                Name = "NextGenerateIntermediateFiles",
                CloseBranchCount = 0
            };

            var nextnextmessage = new Message
            {
                Id = 3,
                Name = "NextNextGenerateIntermediateFiles",
                CloseBranchCount = 2
            };

            var nextThing = new Message
            {
                Id = 4,
                Name = "NextThing",
                CloseBranchCount = 1
            };

            var otherRoot = new Message
            {
                Id = 5,
                Name = "GeneratePosDocuments",
                CloseBranchCount = 1
            };

            getRoutesQueryResponse = new GetRoutesQueryResponse
            {
                Routes = new List<Route> { 
                    new Route
                    {
                        Id = 1,
                        Root = root,
                        Messages = new List<Message>
                        {
                            root,
                            nextmessage,
                            nextnextmessage,
                            nextThing
                        }.ToArray()
                    },
                    new Route
                    {
                        Id = 2,
                        Root = otherRoot,
                        Messages = new List<Message>
                        {
                            otherRoot
                        }.ToArray()
                    } 
                }.ToArray()
            };

            return Task.FromResult(false);
        }

        public static Task<Route> GetRoute(int id)
        {
            return Task.FromResult(getRoutesQueryResponse.Routes.Single(r => r.Id == id));
        }

        public static Task<Route[]> GetRoutesAsync()
        {
            return Task.FromResult(getRoutesQueryResponse.Routes);
        }
    }
}