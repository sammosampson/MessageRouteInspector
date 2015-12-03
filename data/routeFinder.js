var edge = require('edge');
var finderWebClient = require('./finderWebClient')

var getRoutes = function() {
  return new Promise(function(resolve, reject) {
    finderWebClient.getRoutes(null, function (error, result) {
      if (error) reject(Error(error));
      resolve(result);
    });
  });
};

var getRoute = function(id) {
  return new Promise(function(resolve, reject) {
    finderWebClient.getRoute(id, function (error, result) {
      if (error) reject(Error(error));
      resolve(result);
    });
  });
};

var logCommandProcessing = function(name, machine, thread, createdOnTicks) {
  return new Promise(function(resolve, reject) {
    finderWebClient.logCommandProcessing({
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
    finderWebClient.logEventProcessing({
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
    finderWebClient.logMessageProcessingFailure({
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
    finderWebClient.logMessageProcessed({
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
