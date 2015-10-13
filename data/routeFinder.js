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
          var logger = await Bootstrapper.LimitRoutesTo(10).InitialiseAsync();

          return new
          {
              getRoutes = (Func<object, Task<object>>)(
                  async (_) =>
                  {
                      return await logger.GetRoutesAsync();
                  }
              ),
              getRoute = (Func<object, Task<object>>)(
                  async (id) =>
                  {
                      return await logger.GetRouteAsync((string)id);
                  }
              ),
              logCommandProcessing = (Func<dynamic, Task<object>>)(
                  async (details) =>
                  {
                    long createdOnTicks = Convert.ToInt64((string)details.CreatedOnTicks);
                    await logger.LogCommandProcessingAsync(details.MessageName, details.Machine, details.Thread, new DateTime(createdOnTicks));
                    return 1;
                  }
              ),
              logEventProcessing = (Func<dynamic, Task<object>>)(
                  async (details) =>
                  {
                    long createdOnTicks = Convert.ToInt64((string)details.CreatedOnTicks);
                    await logger.LogEventProcessingAsync(details.MessageName, details.Machine, details.Thread, new DateTime(createdOnTicks));
                    return 1;
                  }
              ),
              logMessageProcessingFailure = (Func<dynamic, Task<object>>)(
                  async (details) =>
                  {
                    long createdOnTicks = Convert.ToInt64((string)details.CreatedOnTicks);
                    await logger.LogMessageProcessingFailureAsync(details.FailureName, details.Machine, details.Thread, new DateTime(createdOnTicks));
                    return 1;
                  }
              ),
              logMessageProcessed = (Func<dynamic, Task<object>>)(
                  async (details) =>
                  {
                    await logger.LogMessageProcessedAsync(details.Machine, details.Thread);
                    return 1;
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

var logCommandProcessing = function(name, machine, thread, createdOnTicks) {
  return new Promise(function(resolve, reject) {
    finder.logCommandProcessing({
      MessageName: name,
      Machine: machine,
      Thread: thread,
      CreatedOnTicks: createdOnTicks
    }, function (error, result) {
      if (error) reject(Error(error));
      resolve(result);
    });
  });
};

var logEventProcessing = function(name, machine, thread, createdOnTicks) {
  return new Promise(function(resolve, reject) {
    finder.logEventProcessing({
      MessageName: name,
      Machine: machine,
      Thread: thread,
      CreatedOnTicks: createdOnTicks
    }, function (error, result) {
      if (error) reject(Error(error));
      resolve(result);
    });
  });
};

var logMessageProcessingFailure = function(name, machine, thread, createdOnTicks) {
  return new Promise(function(resolve, reject) {
    finder.logMessageProcessingFailure({
      FailureName: name,
      Machine: machine,
      Thread: thread,
      CreatedOnTicks: createdOnTicks
    }, function (error, result) {
      if (error) reject(Error(error));
      resolve(result);
    });
  });
};

var logMessageProcessed = function(machine, thread) {
  return new Promise(function(resolve, reject) {
    finder.logMessageProcessed({
      Machine: machine,
      Thread: thread
    }, function (error, result) {
      if (error) reject(Error(error));
      resolve(result);
    });
  });
};


module.exports = {
  getRoutes: getRoutes,
  getRoute: getRoute,
  logCommandProcessing: logCommandProcessing,
  logEventProcessing: logEventProcessing,
  logMessageProcessingFailure: logMessageProcessingFailure,
  logMessageProcessed: logMessageProcessed
};
