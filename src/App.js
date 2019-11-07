import React from 'react';
import './App.css';
import './Nav.css';
import MyClaims from './pages/MyClaims.js';
import AllClaims from './pages/AllClaims.js';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  NavLink,
  Link,
  useRouteMatch,
  useParams
} from "react-router-dom";

function Navigation() {
  return (<nav>
    
    <NavLink className="logo" exact to="/"><span>ExpenseTrack</span></NavLink>
    <ul>
      <NavLink exact to="/new-claim"><li><span>New Claim</span></li></NavLink>
      <NavLink exact to="/my-claims"><li><span>My Claims</span></li></NavLink>
      <NavLink exact to="/all-claims"><li><span>All Claims</span></li></NavLink>
      <NavLink exact to="/preferences"><li><span>Preferences</span></li></NavLink>
    </ul>
  </nav>)
}

function App() {
  return (
    <Router>
      <Navigation />
      <div className="body">
        <Switch>
          <Route exact path="/">
            
          </Route>
          <Route path="/my-claims">
            <MyClaims/>
          </Route>
          <Route path="/all-claims">
            <AllClaims/>
          </Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
