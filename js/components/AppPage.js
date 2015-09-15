import 'babel/polyfill';
import Panel from './Panel'
import MessageRoutes from './MessageRoutes';
import MessageRouteInspector from './MessageRouteInspector';

class AppPage extends React.Component {
  onRouteItemSelected(id) {
    console.log('onRouteItemSelected' + id);
  }

  render() {
    return (
      <div>
        <Panel title="Selected route inspector">
            <MessageRouteInspector route={this.props.viewer.route} />
        </Panel>
        <Panel title="Available routes">
          <MessageRoutes
            routes={this.props.viewer.routes}
            onRouteItemSelected={this.onRouteItemSelected.bind(this)}/>
        </Panel>
      </div>
    );
  }
}

export default Relay.createContainer(AppPage, {
  initialVariables: {
    selectedRoute: 1
  },
  fragments: {
    viewer: () => Relay.QL`
      fragment on App {
        routes {
          ${MessageRoutes.getFragment('routes')}
        },
        route(
          id: $selectedRoute
        ) {
          ${MessageRouteInspector.getFragment('route')}
        }
      }
    `,
  },
});
