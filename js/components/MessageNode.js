import 'babel/polyfill';

export default class MessageNode extends React.Component {
  render() {
    console.log('render MessageNode');
    return (
      <li><button type="button" className="btn btn-success">{this.props.message.name}</button>
        <ul>{
          this.props.message.children.map((childMessage) => {
            return <MessageNode message={childMessage} />
          })
        }
        </ul>
      </li>
    )
  }
}
