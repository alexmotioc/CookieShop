import React, {useState} from 'react';
import { BrowserRouter as Router, Link, Route } from "react-router-dom";
import logo from './logo.svg';
import './App.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCookieBite, faUserNinja } from '@fortawesome/free-solid-svg-icons'
import 'bootstrap/dist/css/bootstrap.css'
import CookiesPage from './components/CookiesPage';
import HomePage from './components/HomePage'
import FavoritePage from './components/FavoritePage'
import CartPage from './components/CartPage'
import LoginPage from './components/LoginPage'
import RegisterPage from './components/RegisterPage'
import { AuthContext } from "./context/authcontext";
import StockPage from './components/StockPage';
import AdminRoute from './components/AdminRoute'
import PrivateRoute from './components/PrivateRoute'
import { ToastProvider, useToasts } from 'react-toast-notifications'


function App() {
  const existingTokens = JSON.parse(localStorage.getItem("tokens"));
  const existingRole = JSON.parse(localStorage.getItem("role"));
  const existingBalance = JSON.parse(localStorage.getItem("balance"));
  const [authTokens, setAuthTokens] = useState(existingTokens);
  const [role, setRole] = useState(existingRole);
  const [balance, setBalance] = useState(existingBalance);

  const setTokens = (data) => {
    localStorage.setItem("tokens", JSON.stringify(data));
    setAuthTokens(data);
  }

  const setRoleInstorage = (data) => {
    localStorage.setItem("role", JSON.stringify(data));
    setRole(data);
  }

  const setBalanceInstorage = (data) => {
    localStorage.setItem("balance", JSON.stringify(data));
    setBalance(data);
  }

  return (
    <div className="App">
      <ToastProvider>

      
    
      <AuthContext.Provider value={{ 
        authTokens, setAuthTokens: setTokens, 
        role, setRole: setRoleInstorage 
        }}>
       <Router>     
      <header className="App-header">

        <nav class="navbar navbar-expand-lg navbar-light bg-light">
          <a class="navbar-brand" href="#"> 
          <FontAwesomeIcon className="App-logo" icon={faCookieBite} alt="cookie" />
          </a>
          <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
          <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
              <li class="nav-item active">
                <a class="nav-link" href="/">Home <span class="sr-only">(current)</span></a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/cookies">Cookies</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/favorites">Favorites</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/stock">Stock</a>
              </li>
            </ul>
            <button className="login btn btn-primary">  User
       <FontAwesomeIcon className="" icon={faUserNinja} alt="login" />
          </button>
          </div>
         
        </nav>
      </header>
      <div className="content">
      <Route exact path="/" component={HomePage} />
        <Route path="/cookies" component={CookiesPage} />
        <PrivateRoute path='/favorites' component={FavoritePage}/>
        <Route path='/cart' component={CartPage}/>
        <Route path='/login' component={LoginPage}/>
        <Route path='/register' component={RegisterPage}/>
        <AdminRoute path='/stock' component={StockPage}/>
      </div>
      </Router>
      </AuthContext.Provider>
      </ToastProvider>
    </div>
  );
}

export default App;
