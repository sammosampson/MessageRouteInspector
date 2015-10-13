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
      <div id="content">
        <div className="row">
          <div className="col-lg-6 col-md-6">
            <Panel title="Available routes">
              <MessageRoutes
                routes={this.props.viewer.routes}
                onRouteItemSelected={this.onRouteItemSelected.bind(this)}/>
            </Panel>
          </div>
        </div>
        <div className="row">
          <div className="col-lg-6 col-md-6">
            <Panel title="Route inspector">
              <MessageRouteInspector route={this.props.viewer.route}/>
            </Panel>
          </div>
        </div>
      </div>
    );
  }
}

export default Relay.createContainer(AppPage, {
  initialVariables: {
    selectedRoute: 0
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
