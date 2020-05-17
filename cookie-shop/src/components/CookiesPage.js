import React, {useState, useEffect} from 'react'
import CookieCard from './CookieCards'
import axios from 'axios';
const querystring = require('querystring');
const CookiesPage = () => {
    const url = 'http://localhost:52741/Cookie'
    const [data, setData] = useState([])
 const [searchTerm, setSearchTerm] = useState("");
    useEffect(() => {
        axios.get(url+ '?name=' + searchTerm).then(json => setData(json.data))
      }, [searchTerm])
    
     
      const handleChange = event => {
        setSearchTerm(event.target.value);
      };
    return (
        <React.Fragment>
        <input
        type="text"
        placeholder="Search"
        // value={searchTerm}
        onBlur={handleChange}
      />
    <div className="d-flex flex-row flex-wrap">
        {data.map(cookie => {
        return (
         <CookieCard cookie={cookie}></CookieCard>
        )
      })}
    </div>
    </React.Fragment>)
    
    }

export default CookiesPage