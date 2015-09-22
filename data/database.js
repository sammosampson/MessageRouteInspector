
var dispatchRequest = require('./dispatchRequest');

module.exports = {
  getRoutes: () => {
    return dispatchRequest({getRoutesRequest:{}});
  },
  getRoute: (id) => {
    //return _.find(app.routes, {'id': parseInt(id)});
  }
};
