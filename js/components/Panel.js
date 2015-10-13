import React from 'react';

export default class Panel extends React.Component {
  render() {
    return (
      <div className="panel panel-default">
        <div className="panel-heading">
          <h4 className="panel-title">
            <i className="glyphicon glyphicon-th-list"></i> {this.props.title}
          </h4>
        </div>
        <div className="panel-body">
          {this.props.children}
        </div>
      </div>
    );
  }
}
