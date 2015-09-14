const messageRoute = {
  name:'GenerateIntermediateFiles',
  routes: [{
    name:'NextGenerateIntermediateFiles',
    routes: [{
      name:'NextNextGenerateIntermediateFiles',
      routes: []
    }]
  },{
    name:'NextThing',
    routes: []
  }]
};

module.exports = {
  getRoute: () => messageRoute
};
