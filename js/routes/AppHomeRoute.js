export default class extends Relay.Route {
  static queries = {
    route: () => Relay.QL`
      query {
        route
      }
    `,
  };
  static routeName = 'AppHomeRoute';
}
