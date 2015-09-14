import React from 'react';
import ListItem from './ListItem';

export default class List extends React.Component {
  render() {
    return (
      <div className="list-group-item"> {
        this.props.items.map((item, index) => {
          return <ListItem title={this.props.getItemTitle(item)} key={this.props.getItemKey(item)} id={this.props.getItemKey(item)} onItemSelected={this.props.onItemSelected}/>;
        })}
      </div>);
  }
}
