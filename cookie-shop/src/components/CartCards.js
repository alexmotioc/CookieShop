import React,{useContext} from 'react'
import axios from 'axios';
import ReactStars from 'react-stars'
import { useAuth } from '../context/authcontext';
import {CartContext} from '../context/cartcontext'
const CartCard = ({ cartItem }) => {
    const { authTokens } = useAuth();
    const {cartItems, setCartItems} = useContext(CartContext);

    const options = {
        headers: {
            'Authorization': 'Bearer '+ authTokens
        }}
    const { cookie, amount } = cartItem;
    const { id, name, type, price, sweeteners,ratingAvg} = cookie;
    
    return (
        <div className="card " style={{ width: 18 + "rem" }}>
            {/* <img class="card-img-top" src="..." alt="Card image cap" /> */}
            <div class="card-body  d-flex  flex-column justify-content-center">
                <h5 class="card-title">{name}</h5>
                <p class="card-text">Type: {type}</p>
                <p class="card-text">Price: {price}</p>
                <p class="card-text">Amount: {amount}</p>
            </div>
        </div>
    );
}
export default CartCard
