import React, {useState, useEffect} from 'react'
import CookieCard from './CookieCards'
import axios from 'axios';
const CookiesPage = () => {
    const url = 'http://localhost:52741/Cookie'
    const [data, setData] = useState([])

    useEffect(() => {
        axios.get(url).then(json => setData(json.data))
      }, [])
    
    
    return data.map(cookie => {
        return (
            <div className="d-flex flex-row">
         <CookieCard cookie={cookie}></CookieCard>
         </div>
        )
      })
    }

export default CookiesPage