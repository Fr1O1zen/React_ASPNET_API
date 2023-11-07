import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import './App.css';
import HomePage from './components/Home';
import Product from './components/Product';
import SignalRTest from './components/SignalRTest';
function App() {
  return (
    <>
       <Router>
        <Switch>
        <Route exact path="/" component={HomePage} />
        <Route path="/Product" component={Product} />
        </Switch>
      </Router> 
    </>
  );
}

export default App;
