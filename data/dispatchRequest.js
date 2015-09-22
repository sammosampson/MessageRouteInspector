var edge = require('edge');

var clrMethod = edge.func(function () {/*
    #r "SystemDot.MessageRouteInspector.Server.dll"

    using System.Threading.Tasks;
    using SystemDot.MessageRouteInspector.Server;

    public class Startup
    {
        public async Task<object> Invoke(dynamic input)
        {
            return await new RequestDispatcher().DispatchRequest(input);
        }
    }
*/
});

module.exports = function(request) {
  return new Promise(function(resolve, reject) {
    clrMethod(request, function (error, result) {
      console.log(result);
      if (error) reject(Error(error));
      resolve(result);
    });
  });
}
