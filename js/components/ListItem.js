import React from 'react';
import Link from 'react-router/lib/Link';

export default class ListItem extends React.Component {
  render() {
    var to = '/route/' + this.props.id;
    return(
      <Link to={to} className="list-group-item">{this.props.title}</Link>
      );
  }
}
