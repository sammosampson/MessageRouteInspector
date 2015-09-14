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
  getRoute
} from './database';

var routeInterface = new GraphQLInterfaceType({
  name: 'MessageRouteInterface',
  fields: () => ({
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

export var Schema = new GraphQLSchema({
  query: new GraphQLObjectType({
    name: 'Query',
    fields: {
      route: {
        type: routeType,
        resolve: function() {
          return getRoute();
        }
      }
    }
  })
});
