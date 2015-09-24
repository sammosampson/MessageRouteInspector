var finder = require('./routeFinder');

finder.getRoute(2).then(function(result) {
    console.log(result);
}, function(err) {
  console.log(err);
});
