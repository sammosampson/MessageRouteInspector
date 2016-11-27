import AppPage from './components/AppPage';
import AppHomeRoute from './routes/AppHomeRoute';
import Relay from 'react-relay';

ReactDOM.render(
  <Relay.RootContainer
    Component={AppPage}
    route={new AppHomeRoute()}
  />,
  document.getElementById('root')
);
