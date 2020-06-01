import React,{useContext} from 'react'
import CartCard from './CartCards'
import {CartContext} from './../context/cartcontext'
import { useAuth } from '../context/authcontext';
import axios from 'axios';

const CartPage = () => {
    const {cartItems, setCartItems } = useContext(CartContext);
    const { authTokens} = useAuth();
    const options = {
        headers: {
            'Authorization': 'Bearer '+ authTokens
        }}
    const Purchase = () => {
        axios.post("http://localhost:52741/Account/buy-cart", cartItems, options)
            .then(result => {
                if (result.status === 200) {
                    setCartItems([]);
                    //mesaj
                } else {

                }
            })
            .catch(e => {

            });
    }
    return (
    <React.Fragment><div className="d-flex flex-row flex-wrap">
    {cartItems.map(cart => {
        return (
            <CartCard cartItem={cart}></CartCard>
        )
    })}
</div>
<p><a href="#" class="btn btn-primary m-3" onClick={Purchase}>Purchcase</a></p>
</React.Fragment>)

    
} 

export default CartPage