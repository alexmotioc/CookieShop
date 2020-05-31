import React, {useState} from 'react';
import { BrowserRouter as Router, Link, Route } from "react-router-dom";
import logo from './logo.svg';
import './App.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCookieBite, faUserNinja } from '@fortawesome/free-solid-svg-icons'
import 'bootstrap/dist/css/bootstrap.css'
import CookiesPage from './components/CookiesPage';
import Pages from './Pages'
import FavoritePage from './components/FavoritePage'
import CartPage from './components/CartPage'
import LoginPage from './components/LoginPage'
import RegisterPage from './components/RegisterPage'
import { AuthContext } from "./context/authcontext";
import { CartContext } from "./context/cartcontext";
import StockPage from './components/StockPage';
import AdminRoute from './components/AdminRoute'
import PrivateRoute from './components/PrivateRoute'
import { ToastProvider, useToasts } from 'react-toast-notifications'
import UserInfoComponent from './components/UserInfoComponent'


function App() {
  const existingTokens = JSON.parse(localStorage.getItem("tokens"));
  const existingRole = JSON.parse(localStorage.getItem("role"));
  const existingCart = JSON.parse(localStorage.getItem("cart"));
  
  const [cartItems, setCartItems] = useState(existingCart || []); 
  const [authTokens, setAuthTokens] = useState(existingTokens);
  const [role, setRole] = useState(existingRole);


  const setTokens = (data) => {
    localStorage.setItem("tokens", JSON.stringify(data));
    setAuthTokens(data);
  }

  const setRoleInstorage = (data) => {
    localStorage.setItem("role", JSON.stringify(data));
    setRole(data);
  }

  const setCartItemsInstorage = (data) => {
    console.log("=== ```````````````````````` " + data)
    localStorage.setItem("cart", JSON.stringify(data));
    setCartItems(data);
  }

  return (
    <div className="App">
      <ToastProvider>
      <AuthContext.Provider value={{ 
        authTokens, setAuthTokens: setTokens, 
        role, setRole: setRoleInstorage ,
        }}>
      <CartContext.Provider value ={{
        cartItems, setCartItems: setCartItemsInstorage
      }
      }>
      <Pages />
      </CartContext.Provider>
      </AuthContext.Provider>
      </ToastProvider>
    </div>
  );
}

export default App;
