var finder = require('./routeFinder');

finder.logCommandProcessing('hello', 'hello', 1, '6231608640100000').then(function(result) {
    console.log(result);
}, function(err) {
  console.log(err);
});

finder.logMessageProcessed('hello', 1).then(function(result) {
    console.log(result);
}, function(err) {
  console.log(err);
});

finder.getRoutes().then(function(result) {
    console.log(result);
}, function(err) {
  console.log(err);
});
