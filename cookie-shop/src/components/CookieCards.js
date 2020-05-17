import React from 'react'
import axios from 'axios';
import ReactStars from 'react-stars'
const CookieCard = ({ cookie }) => {
    const { id, name, type, price, sweeteners,ratingAvg} = cookie;
    const ratingChanged = (newRating) => {
        axios.post("http://localhost:52741/Cookie/rate", 
        { 
            cookieId: id, 
            rating: Math.round(newRating)
        }
        )
            .then(result => {
                if (result.status === 200) {
                    //mesaj
                } else {

                }
            })
            .catch(e => {

            });
        console.log(newRating)
    }
    const addToFavorites = () => {
        axios.post("http://localhost:52741/Account/add-favorite", { id })
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
        <div class="card" style={{ width: 18 + "rem" }}>
            {/* <img class="card-img-top" src="..." alt="Card image cap" /> */}
            <div class="card-body">
                <h5 class="card-title">{name}</h5>
                <p class="card-text">Type: {type}</p>
                <p class="card-text">Price: {price}</p>
                <p class="card-text">Sweetners: {sweeteners}</p>
                <ReactStars count={5} onChange={ratingChanged} size={24} color2={'#ffd700'} value={Math.round(ratingAvg)} />
                <a href="#" class="btn btn-primary">Add to cart</a>
                <a href="#" class="btn btn-primary" onClick={addToFavorites}>Add to favorites</a>
            </div>
        </div>
    );
}
export default CookieCard
