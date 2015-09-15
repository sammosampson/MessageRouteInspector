import 'babel/polyfill';

class MessageRouteInspector extends React.Component {
  render() {
    return (
      <ul> {
        this.props.route.messages.map((message) => {
          return <li>{message.name}</li>
        })
      }
      </ul>
    )
  }
}

export default Relay.createContainer(MessageRouteInspector, {
  fragments: {
    route: () => Relay.QL`
      fragment on MessageRoute {
        messages {
          id,
          name,
          closeBranchCount
        }
      }
    `
  }
});
