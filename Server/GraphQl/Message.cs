namespace SystemDot.MessageRouteInspector.Server.GraphQl
{
    using SystemDot.MessageRouteInspector.Server.Messages;
    using GraphQL;
    using GraphQL.Types;

    public class Message : ObjectGraphType
    {
        public Message()
        {
            Field<StringGraphType>("id", resolve: (obj) => obj.Source.As<Messages.Message>().Id);
            Field<StringGraphType>("name", resolve: (obj) => obj.Source.As<Messages.Message>().Name);
            Field<IntGraphType>("type", resolve: (obj) => obj.Source.As<Messages.Message>().Type);
            Field<IntGraphType>("closeBranchCount", resolve: (obj) => obj.Source.As<Messages.Message>().CloseBranchCount);
        }
    }
}