export default class extends Relay.Route {
  static queries = {
    app: () => Relay.QL`
      query {
        app
      }
    `,
  };
  static routeName = 'AppHomeRoute';
}
