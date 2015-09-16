import {
  _
} from 'lodash'

const app = {
  routes: [{
    id: 1,
    root:{
      id: 1,
      name:'GenerateIntermediateFiles',
      closeBranchCount: 0
    },
    messages: [{
      id: 1,
      name:'GenerateIntermediateFiles',
      closeBranchCount: 0
    },{
      id: 2,
      name:'NextGenerateIntermediateFiles',
      closeBranchCount: 0
    },{
      id: 3,
      name:'NextNextGenerateIntermediateFiles',
      closeBranchCount: 2
    },{
      id: 4,
      name:'NextThing',
      closeBranchCount: 1
    }]
  },{
    id: 2,
    root:{
      id: 5,
      name:'GeneratePosDocuments',
      closeBranchCount: 1
    },
    messages: [{
      id: 5,
      name:'GeneratePosDocuments',
      closeBranchCount: 1
    }]
  }]
};

module.exports = {
  getApp: () => app,
  getRoute: (id) => {
    return _.find(app.routes, {'id': parseInt(id)});
  },
  logMessageProcessing: () => {},
  logMessageProcessed(): () => {},
  logFailure(): () => {}
};
