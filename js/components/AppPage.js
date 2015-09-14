import 'babel/polyfill';

class AppPage extends React.Component {
  render() {
    return (
      <div>
        <h1>Widget list</h1>
      </div>
    );
  }
}

export default Relay.createContainer(AppPage, {
  fragments: {
    route: () => Relay.QL`
      fragment on MessageRoute {
        name,
        routes {
          name,
          routes {
            name
          },
        },
      },
    `,
  },
});
