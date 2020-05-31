
import React, { useState } from "react";
import { Link } from 'react-router-dom';
import { Card, Logo, Form, Input, Button } from './AuthPage';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCookieBite } from '@fortawesome/free-solid-svg-icons'
import sendDetailsToServer from "../services/sendDetailsToServer";
import axios from 'axios';
import { useAuth } from "../context/authcontext"


const LoginPage = () => {
    const [state, setState] = useState({
        email: "",
        password: ""
    })
    const [isLoggedIn, setLoggedIn] = useState(false);
    const [isError, setIsError] = useState(false);
    const { setAuthTokens, setRole, setBalance, setUnserName } = useAuth();
    const handleChange = (e) => {
        const { id, value } = e.target
        setState(prevState => ({
            ...prevState,
            [id]: value
        }))
    }
    const handleSubmitClick = (e) => {
        if (state.email.length && state.password.length) {
            const payload = {
                "email": state.email,
                "password": state.password,

            }

            axios.post("http://localhost:52741/Authentification/login", payload)
                .then(result => {
                    if (result.status === 200) {
                        setAuthTokens(result.data.token);
                        setRole(result.data.role);
                        setBalance(result.data.balance)
                        setUnserName(result.data.Name)
                        setLoggedIn(true);

                      
                    } else {
                        setIsError(true);
                    }
                })
                .catch(e => {
                    setIsError(true);
                });
        }
    }

    return (
        <div className="form-group col-12 col-lg-4">
            {/* ... */}
            <input type="email"
                className="form-control"
                id="email"
                aria-describedby="emailHelp"
                placeholder="Enter email"
                value={state.email}
                onChange={handleChange}
            />
            {/* ... */}
            <input type="password"
                className="form-control"
                id="password"
                placeholder="Password"
                value={state.password}
                onChange={handleChange}
            />
            <button
                type="submit"
                className="btn btn-primary"
                onClick={handleSubmitClick}
            >
                Login
          </button>
            <Link to="/register">Don't have an account?</Link>
            {isError && <div>The username or password provided were incorrect!</div>}
        </div>
    )
}

export default LoginPage