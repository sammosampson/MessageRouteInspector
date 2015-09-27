var finder = require('./routeFinder');

finder.getRoutes().then(function(result) {
    console.log(result);
}, function(err) {
  console.log(err);
});
