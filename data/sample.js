var dispatchRequest = require('./dispatchRequest');
dispatchRequest(null).then(function(result) {
    console.log(result);
}, function(err) {
  console.log(err);
});
