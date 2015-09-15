import 'babel/polyfill';
import List from './List';

class MessageRoutesList extends React.Component {
  render() {
    return (
      <List
        items={this.props.routes}
        getItemTitle={(route) => route.root.name}
        getItemKey={(route) => route.id}
        onItemSelected={this.props.onRouteItemSelected} />
    );
  }
}

export default Relay.createContainer(MessageRoutesList, {
  fragments: {
    routes: () => Relay.QL`
      fragment on MessageRoute @relay(plural: true) {
        id,
        root {
          name
        }
      },
    `,
  },
});
