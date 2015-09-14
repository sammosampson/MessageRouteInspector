import 'babel/polyfill';
import List from './List';

class MessageRoutesList extends React.Component {
  onRouteItemSelected(id) {
    console.log('onRouteItemSelected' + id);
  }

  render() {
    return (
      <List
        items={this.props.routes}
        getItemTitle={(route) => route.name}
        getItemKey={(route) => route.id}
        onItemSelected={this.onRouteItemSelected.bind(this)} />
    );
  }
}

export default Relay.createContainer(MessageRoutesList, {
  fragments: {
    routes: () => Relay.QL`
      fragment on MessageRouteInterface @relay(plural: true) {
        id
        name
      },
    `,
  },
});
