const app = {
  routes: [{
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
  },{
    name:'GeneratePosDocuments',
    routes: []
  }]
};

module.exports = {
  getApp: () => app
};
