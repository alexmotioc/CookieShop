import React,{useContext} from 'react'
import CartCard from './CartCards'
import {CartContext} from './../context/cartcontext'
const CartPage = () => {
    const {cartItems} = useContext(CartContext);
    return (<div className="d-flex flex-row flex-wrap">
    {cartItems.map(cart => {
        return (
            <CartCard cartItem={cart}></CartCard>
        )
    })}
</div>)
    
} 

export default CartPage