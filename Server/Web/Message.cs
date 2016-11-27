namespace SystemDot.MessageRouteInspector.Server.Web
{
    using GraphQL;
    using GraphQL.Types;

    internal class Message : ObjectGraphType
    {
        public Message()
        {
            Field<StringGraphType>("id", resolve: (obj) => obj.Source.As<Queries.Messages.Message>().Id);
            Field<StringGraphType>("name", resolve: (obj) => obj.Source.As<Queries.Messages.Message>().Name);
            Field<IntGraphType>("type", resolve: (obj) => obj.Source.As<Queries.Messages.Message>().Type);
            Field<IntGraphType>("closeBranchCount", resolve: (obj) => obj.Source.As<Queries.Messages.Message>().CloseBranchCount);
        }
    }
}