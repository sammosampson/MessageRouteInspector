import 'babel/polyfill';
import Panel from './Panel'
import MessageRoutes from './MessageRoutes';
import MessageRouteInspector from './MessageRouteInspector';

class AppPage extends React.Component {
  onRouteItemSelected(id) {
    this.props.relay.setVariables({selectedRoute: id})
  }

  render() {
    console.log('render AppPage');
    return (
      <div>
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
