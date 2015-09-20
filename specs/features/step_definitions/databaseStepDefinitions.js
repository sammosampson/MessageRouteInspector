module.exports = function () {
  this.World = require("../support/databaseSupport.js").World;

  this.Given('I have logged message proccessing for the message "$message"', function (message) {
    return this.logMessageProcessing(message);
  });

  this.When('I get all routes', function () {
    return this.getRoutes();
  });

  this.Then('the only route should have the name "$route"', function (route, callback) {
    callback.pending();
  });
};
