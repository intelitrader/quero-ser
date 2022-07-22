import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import Provider from './Context/Provider';
import Home from './Pages/Home';
import Table from './Pages/Table';

function App() {
  return (
    <BrowserRouter>
      <Provider>
        <Switch>
          <Route exact path="/" component={ Home } />
          <Route exact path="/table" component={ Table } />
        </Switch>
      </Provider>
    </BrowserRouter>
  );
}

export default App;
