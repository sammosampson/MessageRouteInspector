import {
  GraphQLBoolean,
  GraphQLFloat,
  GraphQLID,
  GraphQLInt,
  GraphQLList,
  GraphQLNonNull,
  GraphQLObjectType,
  GraphQLSchema,
  GraphQLString,
  GraphQLInterfaceType
} from 'graphql';

import {
  mutationWithClientMutationId
} from 'graphql-relay';

import {
  getRoute,
  getRoutes,
  logCommandProcessing,
  logEventProcessing,
  logMessageProcessingFailure,
  logMessageProcessed,
} from './routeFinder';

var message = new GraphQLObjectType({
  name: 'Message',
  fields: {
    id: {
      type: GraphQLID,
      resolve: (message) => {
        return message.Id;
      }
    },
    name: {
      type: GraphQLString,
      resolve: (message) => {
        return message.Name;
      }
    },
    closeBranchCount: {
      type: GraphQLInt,
      resolve: (message) => {
        return message.CloseBranchCount;
      }
    }
  }
});

var route = new GraphQLObjectType({
  name: 'MessageRoute',
  fields: {
    id: {
      type: GraphQLID,
      resolve: (route) => {
        return route.Id;
      }
    },
    root: {
      type: message,
      resolve: (route) => {
        return route.Messages[0];
      }
    },
    messages: {
      type: new GraphQLList(message),
      resolve: (route) => {
        return route.Messages;
      }
    }
  }
});

var mutation = new GraphQLObjectType({
  name: 'RootMutationType',
  fields: {
     logCommandProcessing: {
       type: GraphQLInt,
       args: {
          name: { type: new GraphQLNonNull(GraphQLString) },
          machine: { type: new GraphQLNonNull(GraphQLString) },
          thread: { type: new GraphQLNonNull(GraphQLInt) },
          createdOn: { type: new GraphQLNonNull(GraphQLString) }
       },
       description: 'Logs the processing of a command',
       resolve: function(root, {name, machine, thread, createdOn}) {
         return logCommandProcessing(name, machine, thread, createdOn);
       }
     },
     logEventProcessing: {
       type: GraphQLInt,
       args: {
          name: { type: new GraphQLNonNull(GraphQLString) },
          machine: { type: new GraphQLNonNull(GraphQLString) },
          thread: { type: new GraphQLNonNull(GraphQLInt) },
          createdOn: { type: new GraphQLNonNull(GraphQLString) }
       },
       description: 'Logs the processing of a event',
       resolve: function(root, {name, machine, thread, createdOn}) {
         return logEventProcessing(name, machine, thread, createdOn);
       }
     },
     logMessageProcessingFailure: {
       type: GraphQLInt,
       args: {
          name: { type: new GraphQLNonNull(GraphQLString) },
          machine: { type: new GraphQLNonNull(GraphQLString) },
          thread: { type: new GraphQLNonNull(GraphQLInt) },
          createdOn: { type: new GraphQLNonNull(GraphQLString) }
       },
       description: 'Logs the processing of a message processing',
       resolve: function(root, {name, machine, thread, createdOn}) {
         return logMessageProcessingFailure(name, machine, thread, createdOn);
       }
     },
     logMessageProcessed: {
       type: GraphQLInt,
       args: {
          machine: { type: new GraphQLNonNull(GraphQLString) },
          thread: { type: new GraphQLNonNull(GraphQLInt) }
       },
       description: 'Logs the fact that any messaged has been processed',
       resolve: function(root, {machine, thread}) {
         return logMessageProcessed(machine, thread);
       }
     }
   }
});

var app = new GraphQLObjectType({
  name: 'App',
  fields: {
    routes: {
      type: new GraphQLList(route),
      resolve: (app) => {
        return getRoutes();
      }
    },
    route: {
      args: {
        id: {type: GraphQLID}
      },
      type: route,
      resolve: (app, {id}) => {
        return getRoute(id);
      }
    }
  }
});

export var Schema = new GraphQLSchema({
  mutation: mutation,
  query: new GraphQLObjectType({
    name: 'Query',
    fields: {
      viewer: {
        type: app,
        resolve: function() {
          return {};
        }
      }
    }
  })
});
