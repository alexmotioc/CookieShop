import React from 'react'
import axios from 'axios';
const CookieCard = ({cookie}) => {
const {id, name, type, price, sweeteners}=cookie;
const handleRatingClick = (e, data)=> {

    alert('You left a ' + data.rating + ' star rating for ' + data.caption);

}
const addToFavorites = () => {
    axios.post("http://localhost:52741/Account/add-favorite", {id} )
                .then(result => {
                    if (result.status === 200) {
                        //mesaj
                    } else {
                        
                    }
                })
                .catch(e => {
                    
                });
}
    return (
        <div class="card" style={{width:18+"rem"}}>
            {/* <img class="card-img-top" src="..." alt="Card image cap" /> */}
            <div class="card-body">
                <h5 class="card-title">{name}</h5>
                <p class="card-text">Type: {type}</p>
                <p class="card-text">Price: {price}</p>
                <p class="card-text">Sweetners: {sweeteners}</p>
                <a href="#" class="btn btn-primary">Add to cart</a>
                <a href="#" class="btn btn-primary" onClick={addToFavorites}>Add to favorites</a>
            </div>
        </div>
    );
}
export default CookieCard
