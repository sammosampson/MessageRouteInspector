import express from 'express';
import path from 'path';
import webpack from 'webpack';
import WebpackDevServer from 'webpack-dev-server';

const APP_PORT = 3001;
const GRAPHQL_PORT = 8081;

// Expose a GraphQL endpoint - now in dot net
//var graphQLServer = express();
//graphQLServer.use('/', graphQLHTTP({schema: Schema, pretty: true}));
//graphQLServer.listen(GRAPHQL_PORT, () => console.log(
  //`GraphQL Server is now running on http://localhost:${GRAPHQL_PORT}`
//));

// Serve the Relay app
var compiler = webpack({
  entry: path.resolve(__dirname, 'js', 'app.js'),
  module: {
    loaders: [
      {
        test: /\.js$/,
        loader: 'babel',
        query: {stage: 0, plugins: ['./build/babelRelayPlugin']}
      }
    ]
  },
  output: {filename: 'app.js', path: '/'}
});
var app = new WebpackDevServer(compiler, {
  contentBase: '/public/',
  proxy: {'/graphql': `http://localhost:${GRAPHQL_PORT}`},
  publicPath: '/js/',
  stats: {colors: true}
});
// Serve static resources
app.use('/', express.static('public'));
app.use('/node_modules/react', express.static('node_modules/react'));
app.use('/node_modules/react-relay', express.static('node_modules/react-relay'));
app.listen(APP_PORT, () => {
  console.log(`App is now running on http://localhost:${APP_PORT}`);
});
