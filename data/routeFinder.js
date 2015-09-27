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
            var logger = await Bootstrapper.InitialiseAsync();

            return new {
                getRoutes = (Func<object,Task<object>>)(
                    async (_) =>
                    {
                        return await logger.GetRoutesAsync();
                    }
                ),
                getRoute = (Func<object,Task<object>>)(
                    async (id) =>
                    {
                        return await logger.GetRouteAsync((string)id);
                    }
                )
            };
        }
    }
*/});


var finder = null;
initialiseFinder(null, function (error, result) {
  if (error) {
    console.log(error);
  }
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
