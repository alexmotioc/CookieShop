import React from 'react';
import logo from './logo.svg';
import './App.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCookieBite, faUserNinja } from '@fortawesome/free-solid-svg-icons'
import 'bootstrap/dist/css/bootstrap.css'
import CookiesPage from './components/CookiesPage';

function App() {
  return (
    <div className="App">
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
                <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#">Cookies</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#">Favorites</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#">Cart</a>
              </li>
            </ul>
            <button className="login btn btn-primary">  User
       <FontAwesomeIcon className="" icon={faUserNinja} alt="login" />
          </button>
          </div>
         
        </nav>
      </header>
      <div className="content">
        <CookiesPage></CookiesPage>
      </div>
    </div>
  );
}

export default App;
