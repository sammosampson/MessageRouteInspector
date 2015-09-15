import 'babel/polyfill';

class MessageRouteInspector extends React.Component {
  render() {
    return (
      <ul> {
        this.props.route.messages.map((message) => {
          return renderMessage(message)
        })
      }
      </ul>
    )
  }

  renderMessage(message) {
    var node = <li>{message.name}<ul>
    for (i = message.closeBranchCount; i > 0; i--;) {
      var closing = '</ul></li>'
      node = node + closing
    }
    return node;
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
