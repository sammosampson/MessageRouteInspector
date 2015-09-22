namespace SystemDot.MessageRouteInspector.Server
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RequestDispatcher
    {
        public async Task<object> DispatchRequest(dynamic input)
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

            var getRoutesResponse = new GetRoutesResponse
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
            return await Task.FromResult(getRoutesResponse.Routes);
        }
    }
}
