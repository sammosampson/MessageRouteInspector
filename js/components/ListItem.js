import React from 'react';

export default class ListItem extends React.Component {
  render() {
    var boundClick = this.props.onItemSelected.bind(this, this.props.id);
    return(
      <a className="list-group-item" onClick={boundClick}>{this.props.title}</a>
      );
  }
}
