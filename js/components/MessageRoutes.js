import React from 'react';
import Relay from 'react-relay';
import 'babel/polyfill';
import List from './List';

class MessageRoutes extends React.Component {
  render() {
    console.log('render MessageRoutes');
    return (
      <List
        items={this.props.routes}
        getItemTitle={(route) => route.root.name}
        getItemKey={(route) => route.id} />
    );
  }
}

export default Relay.createContainer(MessageRoutes, {
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
