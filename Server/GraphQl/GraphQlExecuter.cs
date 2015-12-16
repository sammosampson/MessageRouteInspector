namespace SystemDot.MessageRouteInspector.Server.GraphQl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Messaging;
    using System.Threading.Tasks;
    using SystemDot.MessageRouteInspector.Server.Messages;
    using SystemDot.MessageRouteInspector.Server.Specifications.Steps;
    using GraphQL;
    using GraphQL.Http;
    using GraphQL.Types;

    public class GraphQlExecuter
    {
        private readonly DocumentExecuter executer;
        private readonly DocumentWriter writer;
        private readonly MessageLogger logger;

        public GraphQlExecuter(MessageLogger logger)
        {
            this.logger = logger;
            executer = new DocumentExecuter();
            writer = new DocumentWriter();
        }

        public async Task<string> ExecuteQueryAsync(string query)
        {
            
            ExecutionResult result = await executer.ExecuteAsync(new RouteInspectorSchema(logger), new object(), query, null);
            return writer.Write(result);
        }
    }

    public class RouteInspectorSchema : Schema
    {
        public RouteInspectorSchema(MessageLogger logger)
        {
            Query = new RouteInspectorQuery(logger);
            Mutation = new RouteInspectorMutation(logger);
        }
    }

    public class RouteInspectorQuery : ObjectGraphType
    {
        public RouteInspectorQuery(MessageLogger logger)
        {
            Field<AppType>("App", resolve: (obj) => logger);
        }
    }

    public class AppType : ObjectGraphType
    {
        public AppType()
        {
            Field<ListGraphType<RouteType>>("routes", resolve: obj => obj.Source.As<MessageLogger>().GetRoutesAsync());
        }
    }

    public class RouteType : ObjectGraphType
    {
        public RouteType()
        {
            Field<StringGraphType>("id", resolve: (obj) => obj.Source.As<Route>().Id);
            Field<StringGraphType>("createdOn", resolve: (obj) => obj.Source.As<Route>().CreatedOn);
            Field<StringGraphType>("machine", resolve: (obj) => obj.Source.As<Route>().MachineName);
            Field<MessageType>("root", resolve: (obj) => obj.Source.As<Route>().Messages[0]);
            Field<ListGraphType<MessageType>>("messages", resolve: (obj) => obj.Source.As<Route>().Messages);
        }
    }
    
    public class MessageType : ObjectGraphType
    {
        public MessageType()
        {
            Field<StringGraphType>("id", resolve: (obj) => obj.Source.As<Message>().Id);
            Field<StringGraphType>("name", resolve: (obj) => obj.Source.As<Message>().Name);
            Field<IntGraphType>("type", resolve: (obj) => obj.Source.As<Message>().Type);
            Field<IntGraphType>("closeBranchCount", resolve: (obj) => obj.Source.As<Message>().CloseBranchCount);
        }
    }

    public class RouteInspectorMutation : ObjectGraphType
    {
        public RouteInspectorMutation(MessageLogger logger)
        {
            Field<IntGraphType>(
                "logCommandProcessing",
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "machine" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "thread" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "createdOn" }
                }),
                description: "Logs the processing of a command",
                resolve: ctx => logger.LogCommandProcessingAsync(
                    ctx.Arguments.Values.First().ToString(),
                    ctx.Arguments.Values.ElementAt(1).ToString(),
                    Int32.Parse(ctx.Arguments.Values.ElementAt(2).ToString()),
                    new DateTime(Int32.Parse(ctx.Arguments.Values.ElementAt(3).ToString()))));
            
            Field<IntGraphType>(
                "logEventProcessing",
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "machine" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "thread" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "createdOn" }
                }),
                description: "Logs the processing of an event",
                resolve: ctx => logger.LogEventProcessingAsync(
                    ctx.Arguments.Values.First().ToString(),
                    ctx.Arguments.Values.ElementAt(1).ToString(),
                    Int32.Parse(ctx.Arguments.Values.ElementAt(2).ToString()),
                    new DateTime(Int32.Parse(ctx.Arguments.Values.ElementAt(3).ToString()))));
            
            Field<IntGraphType>(
                "logMessageProcessingFailure",
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "machine" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "thread" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "createdOn" }
                }),
                description: "Logs a message failure",
                resolve: ctx => logger.LogMessageProcessingFailureAsync(
                    ctx.Arguments.Values.First().ToString(),
                    ctx.Arguments.Values.ElementAt(1).ToString(),
                    Int32.Parse(ctx.Arguments.Values.ElementAt(2).ToString()),
                    new DateTime(Int32.Parse(ctx.Arguments.Values.ElementAt(3).ToString()))));
            
            Field<IntGraphType>(
                "logMessageProcessed", 
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>{ Name = "machine" },
                    new QueryArgument<NonNullGraphType<IntGraphType>>{ Name = "thread" },
                }),
                description: "Logs the fact that any messaged has been processed", 
                resolve: ctx => logger.LogMessageProcessedAsync(
                    ctx.Arguments.Values.First().ToString(),
                    Int32.Parse(ctx.Arguments.Values.ElementAt(1).ToString())));
        }
    }
}