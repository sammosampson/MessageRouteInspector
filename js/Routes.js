import React from 'react';
import Relay from 'react-relay';
import {IndexRoute, Route} from 'react-router';

import ViewerQueries from './ViewerQueries';
import AppPage from './components/AppPage';
import MessageRouteInspector from './components/MessageRouteInspector';

export default (
  <Route
    path="/" component={AppPage}
    queries={ViewerQueries}>
    <Route
      path="route/:route"
      component={MessageRouteInspector}
      queries={ViewerQueries} />
  </Route>
);
