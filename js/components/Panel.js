import React from 'react';

export default class Panel extends React.Component {
  render() {
    return (
      <div className="panel panel-default">
        <div className="panel-heading">{this.props.title}</div>
        {this.props.children}
      </div>
    );
  }
}
