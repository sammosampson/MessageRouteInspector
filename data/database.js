const app = {
  routes: [{
    id: 1,
    name:'GenerateIntermediateFiles',
    routes: [{
      id: 11,
      name:'NextGenerateIntermediateFiles',
      routes: [{
        id: 111,
        name:'NextNextGenerateIntermediateFiles',
        routes: []
      }]
    },{
      id: 12,
      name:'NextThing',
      routes: []
    }]
  },{
    id: 2,
    name:'GeneratePosDocuments',
    routes: []
  }]
};

module.exports = {
  getApp: () => app
};
