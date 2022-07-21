import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import Home from './Pages/Home';
import Table from './Pages/Table';

function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={ Home } />
        <Route exact path="/table" component={ Table } />
      </Switch>
    </BrowserRouter>
  );
}

export default App;
