import 'babel/polyfill';

class MessageRoutes extends React.Component {
  render() {
    console.log('render MessageRoutes');
    return (
      <table className="table table-striped table-hover">
        <thead>
          <tr>
            <th className="per60">Name</th>
            <th className="per20">Date</th>
            <th className="per20">Machine</th>
          </tr>
        </thead>
        <tbody>
          {this.renderRows()}
        </tbody>
      </table>

    );
  }
  renderRows() {
    return this.props.routes.map((item, index) => this.renderRow(item));
  }
  renderRow(item) {
    var boundClick = this.props.onRouteItemSelected.bind(this, item.id);
    return (
      <tr onClick={boundClick}>
        <td>{item.root.name}</td>
        <td>{item.createdOn}</td>
        <td>{item.machine}</td>
      </tr>
    );
  }
}

export default Relay.createContainer(MessageRoutes, {
  fragments: {
    routes: () => Relay.QL`
      fragment on MessageRoute @relay(plural: true) {
        id,
        createdOn,
        machine,
        root {
          name
        }
      },
    `,
  },
});
