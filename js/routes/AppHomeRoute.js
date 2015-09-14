export default class extends Relay.Route {
  static queries = {
    viewer: () => Relay.QL`
      query {
        app
      }
    `,
  };
  static routeName = 'AppHomeRoute';
}
