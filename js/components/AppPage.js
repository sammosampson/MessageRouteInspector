import 'babel/polyfill';
import Panel from './Panel'
import MessageRoutesList from './MessageRoutesList';
import SelectedMessageRoute from './SelectedMessageRoute';

class AppPage extends React.Component {
  onRouteItemSelected(id) {
    console.log('onRouteItemSelected' + id);
  }

  render() {
    return (
      <div>
        <Panel title="Selected route">
            <SelectedMessageRoute route={this.props.viewer.route} />
        </Panel>
        <Panel title="Available routes">
          <MessageRoutesList
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
          ${MessageRoutesList.getFragment('routes')}
        },
        route(
          id: $selectedRoute
        ) {
          ${SelectedMessageRoute.getFragment('route')}
        }
      }
    `,
  },
});
