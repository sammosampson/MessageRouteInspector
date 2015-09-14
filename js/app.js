import AppPage from './components/AppPage';
import AppHomeRoute from './routes/AppHomeRoute';

ReactDOM.render(
  <Relay.RootContainer
    Component={AppPage}
    route={new AppHomeRoute()}
  />,
  document.getElementById('root')
);
