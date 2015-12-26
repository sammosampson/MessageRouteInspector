using SystemDot.MessageRouteInspector.Server.Queries.Messages;

namespace SystemDot.MessageRouteInspector.Server.GraphQl
{
    using SystemDot.MessageRouteInspector.Server.Messages;
    using GraphQL;
    using GraphQL.Types;

    public class MessageRoute : ObjectGraphType
    {
        public MessageRoute()
        {
            Field<StringGraphType>("id", resolve: (obj) => obj.Source.As<Route>().Id);
            Field<StringGraphType>("createdOn", resolve: (obj) => obj.Source.As<Route>().CreatedOn);
            Field<StringGraphType>("machine", resolve: (obj) => obj.Source.As<Route>().MachineName);
            Field<Message>("root", resolve: (obj) => obj.Source.As<Route>().Messages[0]);
            Field<ListGraphType<Message>>("messages", resolve: (obj) => obj.Source.As<Route>().Messages);
        }
    }
}