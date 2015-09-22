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
  getRoute,
  getRoutes
} from './database';

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
  query: new GraphQLObjectType({
    name: 'Query',
    fields: {
      app: {
        type: app,
        resolve: function() {
          return {};
        }
      }
    }
  })
});
