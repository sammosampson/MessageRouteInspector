import 'babel/polyfill';

class MessageRoutesList extends React.Component {
  render() {
    return (
      <div/>
    );
  }
}

export default Relay.createContainer(MessageRoutesList, {
  fragments: {
    routes: () => Relay.QL`
      fragment on MessageRouteInterface @relay(plural: true) {
        name
      },
    `,
  },
});
