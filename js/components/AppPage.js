import React from 'react';
import Relay from 'react-relay';
import 'babel/polyfill';
import Panel from './Panel'
import MessageRoutes from './MessageRoutes';
import MessageRouteInspector from './MessageRouteInspector';

class AppPage extends React.Component {
  render() {
    console.log('render AppPage');
    return (
      <div>
        <Panel title="Available routes">
          <MessageRoutes routes={this.props.viewer.routes}/>
        </Panel>
        <Panel title="Selected route inspector">
          {this.props.children}
        </Panel>
      </div>
    );
  }
}

export default Relay.createContainer(AppPage, {
  fragments: {
    viewer: () => Relay.QL`
      fragment on App {
        routes {
          ${MessageRoutes.getFragment('routes')}
        }
      }
    `,
  },
});
