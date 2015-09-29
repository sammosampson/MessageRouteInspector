import Routes from './Routes';
import {Router} from 'react-router';
import ReactRouterRelay from 'react-router-relay';

ReactDOM.render(
  <Router
    createElement={ReactRouterRelay.createElement}
    routes={Routes}
  />,
  document.getElementById('root')
);
