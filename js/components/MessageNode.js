import 'babel/polyfill';

export default class MessageNode extends React.Component {
  render() {
    console.log('render MessageNode');
    return (
      <li className="dd-item">
        <div className="dd-handle green-bg">{this.props.message.name}</div>
        <ol className="dd-list">{
          this.props.message.children.map((childMessage) => {
            return <MessageNode message={childMessage} />
          })
        }
        </ol>
      </li>
    )
  }
}
