import 'babel/polyfill';

class SelectedMessageRoute extends React.Component{
  render() {
    return (
      <ul>
        <li>hello</li>
      </ul>
    )
  }
};

export default Relay.createContainer(SelectedMessageRoute, {
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
