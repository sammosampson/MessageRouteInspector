import 'babel/polyfill';

export default class MessageNode extends React.Component {
  render() {
    console.log('render MessageNode');
    return (
      <li className="dd-item">
        {this.renderInner()}
        <ol className="dd-list">{
          this.props.message.children.map((childMessage) => {
            return <MessageNode message={childMessage} />
          })
        }
        </ol>
      </li>
    )
  }

  renderInner() {
    if(this.props.message.type == 0) {
      return (
        <div className="dd-handle green-bg">{this.props.message.name}</div>
      )
    }
    if(this.props.message.type == 1) {
      return (
        <div className="dd-handle blue-bg">{this.props.message.name}</div>
      )
    }
    if(this.props.message.type == 2) {
      return (
        <div className="dd-handle red-bg">{this.props.message.name}</div>
      )
    }
  }
}
