import 'babel/polyfill';
import MessageNode from './MessageNode'

class MessageRouteInspector extends React.Component {
  rebuildHierarchy(messages) {
    var root = null;
    this.props.route.messages.map((message) => {
      if(root === null) {
        root = message;
        root.children = [];
      } else {
        root.children.push(message);
        message.parent = root;
        root = message;
        root.children = [];
        for(var i = message.closeBranchCount; i > 0; i--) {
          root = root.parent
        }
      }
    });
    return root;
  }

  render() {
    console.log('render MessageRouteInspector');
    return (
      <ul>
        <MessageNode message={this.rebuildHierarchy(this.props.route.messages)} />
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
