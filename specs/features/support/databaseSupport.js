var Database = require('../../../data/database');
function World(callback) {
  this.database = new Database();

  this.logMessageProcessing = function (message, callback) {
    this.database.logMessageProcessing();
  };

  this.getRoutes = function (callback) {
    this.routes = this.database.getApp().routes;
  };

  callback(); // tell Cucumber we're finished and to use 'this' as the world instance
}
module.exports.World = World;
