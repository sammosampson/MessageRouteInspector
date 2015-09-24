var edge = require('edge');

var initialiseFinder = edge.func(function () {/*
    #r "SystemDot.MessageRouteInspector.Server.dll"

    using System;
    using System.Threading.Tasks;
    using SystemDot.MessageRouteInspector.Server;

    public class Startup
    {
        public async Task<object> Invoke(dynamic input)
        {
            var finder = new RouteFinder();
            await finder.Initialise();

            return new {
                getRoutes = (Func<object,Task<object>>)(
                    async (_) =>
                    {
                        return await finder.GetRoutes();
                    }
                ),
                getRoute = (Func<object,Task<object>>)(
                    async (id) =>
                    {
                        return await finder.GetRoute((int)id);
                    }
                )
            };
        }
    }
*/});


var finder = null;
initialiseFinder(null, function (error, result) {
  finder = result;
});

var getRoutes = function() {
  return new Promise(function(resolve, reject) {
    finder.getRoutes(null, function (error, result) {
      if (error) reject(Error(error));
      resolve(result);
    });
  });
};

var getRoute = function(id) {
  return new Promise(function(resolve, reject) {
    finder.getRoute(id, function (error, result) {
      if (error) reject(Error(error));
      resolve(result);
    });
  });
};

module.exports = {
  getRoutes: getRoutes,
  getRoute: getRoute,
};
