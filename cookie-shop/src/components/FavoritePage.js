import React, {useState, useEffect} from 'react'
import FavoriteCookieCard from './FavoriteCookieCards'
import axios from 'axios';
import { useAuth } from '../context/authcontext';
const FavoritesPage = () => {
    const url = 'http://localhost:52741/account/favorites'
    const [data, setData] = useState([])
    const { authTokens } = useAuth();
    const options = {
        headers: {
            'Authorization': 'Bearer '+ authTokens
        }}
    const makeRequest =() => {axios.get(url,options).then(json => setData(json.data))}
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