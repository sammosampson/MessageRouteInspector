namespace SystemDot.MessageRouteInspector.Server.GraphQl
{
    using System;
    using System.Linq;
    using SystemDot.Core;
    using SystemDot.MessageRouteInspector.Server.Specifications.Steps;
    using GraphQL.Types;

    public class RouteInspectorMutation : ObjectGraphType
    {
        public RouteInspectorMutation()
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
                resolve: ctx => ctx.Source.As<MessageLogger>().LogCommandProcessingAsync(
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
                resolve: ctx => ctx.Source.As<MessageLogger>().LogEventProcessingAsync(
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
                resolve: ctx => ctx.Source.As<MessageLogger>().LogMessageProcessingFailureAsync(
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
                resolve: ctx => ctx.Source.As<MessageLogger>().LogMessageProcessedAsync(
                    ctx.Arguments.Values.First().ToString(),
                    Int32.Parse(ctx.Arguments.Values.ElementAt(1).ToString())));
        }
    }
}