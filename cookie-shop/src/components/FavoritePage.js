import React, {useState, useEffect} from 'react'
import FavoriteCookieCard from './FavoriteCookieCards'
import axios from 'axios';
const FavoritesPage = () => {
    const url = 'http://localhost:52741/account/favorites'
    const [data, setData] = useState([])
    const makeRequest =() => {axios.get(url).then(json => setData(json.data))}
    useEffect(() => {
        makeRequest();
      }, [])

    return (
        <div className="d-flex flex-row flex-wrap">
        {data.map(cookie => {
        return (
         <FavoriteCookieCard refresh={makeRequest} cookie={cookie}></FavoriteCookieCard>
        )
      })}
    </div>
    );
} 

export default FavoritesPage