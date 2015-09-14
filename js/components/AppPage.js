import 'babel/polyfill';
import MessageRoutesList from './MessageRoutesList';

class AppPage extends React.Component {
  render() {
    return (
      <MessageRoutesList/>
    );
  }
}

export default Relay.createContainer(AppPage, {
  fragments: {
    app: () => Relay.QL`
      fragment on App {
        routes {
          ${MessageRoutesList.getFragment('routes')}
        }
      },
    `,
  },
});
