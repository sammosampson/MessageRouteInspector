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
  getApp
} from './database';

var message = new GraphQLObjectType({
  name: 'Message',
  fields: {
    id: {
      type: GraphQLID
    },
    name: {
      type: GraphQLString
    },
    closeBranchCount: {
      type: GraphQLInt
    }
  }
});

var route = new GraphQLObjectType({
  name: 'MessageRoute',
  fields: {
    id: {
      type: GraphQLID
    },
    root: {
      type: message,
      resolve: (route) => {
        return route.messages[0];
      }
    },
    messages: {
      type: new GraphQLList(message),
      resolve: (route) => {
        return route.messages;
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
        return app.routes;
      }
    },
    route: {
      args: {
        id: {type: GraphQLID}
      },
      type: route,
      resolve: (app, {id}) => {
        return app.routes[0];
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
          return getApp();
        }
      }
    }
  })
});
