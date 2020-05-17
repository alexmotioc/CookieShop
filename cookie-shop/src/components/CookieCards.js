import React from 'react'
const CookieCard = ({cookie}) => {
const {name, type, price, sweeteners}=cookie;
    return (
        <div class="card" style={{width:18+"rem"}}>
            {/* <img class="card-img-top" src="..." alt="Card image cap" /> */}
            <div class="card-body">
                <h5 class="card-title">{name}</h5>
                <p class="card-text">Type: {type}</p>
                <p class="card-text">Price: {price}</p>
                <p class="card-text">Sweetners: {sweeteners}</p>
                <a href="#" class="btn btn-primary">Add to cart</a>
                <a href="#" class="btn btn-primary">Add to favorites</a>
            </div>
        </div>
    );
}
export default CookieCard
