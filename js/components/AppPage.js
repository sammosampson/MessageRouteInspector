import 'babel/polyfill';
import MessageRoutesList from './MessageRoutesList';

class AppPage extends React.Component {
  onRouteItemSelected() {
    console.log('onRouteItemSelected');
  }

  render() {
    return (
      <MessageRoutesList routes={this.props.viewer.routes}/>
    );
  }
}


export default Relay.createContainer(AppPage, {
  fragments: {
    viewer: () => Relay.QL`
      fragment on App {
        routes {
          ${MessageRoutesList.getFragment('routes')}
        }
      },
    `,
  },
});
