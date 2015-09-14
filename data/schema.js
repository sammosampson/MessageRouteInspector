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

var routeInterface = new GraphQLInterfaceType({
  name: 'MessageRouteInterface',
  fields: () => ({
    id: {
      type: GraphQLID
    },
    name: {
      type: GraphQLString
    },
    routes: {
      type: new GraphQLList(routeInterface)
    }
  }),
  resolveType: (route) => {
    return routeType;
  }
});

var routeType = new GraphQLObjectType({
  name: 'MessageRoute',
  fields: {
    id: {
      type: GraphQLID
    },
    name: {
      type: GraphQLString
    },
    routes: {
      type: new GraphQLList(routeInterface),
      resolve: (route) => {
        return route.routes;
      }
    }
  },
  interfaces: [ routeInterface ]
});

var appType = new GraphQLObjectType({
  name: 'App',
  fields: {
    routes: {
      type: new GraphQLList(routeInterface),
      resolve: (app) => {
        return app.routes;
      }
    }
  }
});

export var Schema = new GraphQLSchema({
  query: new GraphQLObjectType({
    name: 'Query',
    fields: {
      app: {
        type: appType,
        resolve: function() {
          return getApp();
        }
      }
    }
  })
});
