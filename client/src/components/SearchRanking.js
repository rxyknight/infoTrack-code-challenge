import React, { useState, useEffect, useContext } from 'react';
import { GlobalContext } from '../context/GlobalContext';

const searchEngineOptions = [
    { id: 'google', text: 'Google', value: 'google' },
    { id: 'bing', text: 'Bing', value: 'bing' }
]

export const SearchRanking = () => {
    const [keywords, setKeywords] = useState('online title search');
    const [url, setUrl] = useState('https://www.infotrack.com.au');
    const [searchEngines, setSearchEngines] = useState(['google']);

    const { state: { loading }, fetchRequest, fetchSuccess, fetchFailure } = useContext(GlobalContext);

    const onSubmit = e => {
        e.preventDefault();
        fetchRequest();
    }

    useEffect(() => {
        if (loading) {
            fetchRequest();
            async function fetchData() {

                const data = await fetch(`http://localhost:5000/api/v1/ranking?keywords=${keywords}&url=${url}&searchEngines=${searchEngines.join(',')}`);
                if(data.status === 200) {
                    const results = await data.json();
                    fetchSuccess(results);
                }else{
                    fetchFailure("opps...")
                }
            }
            fetchData();
        }
    }, [loading])

    const handleCheckboxChange = e => {
        //We make sure at lease 1 option is selected
        // if (searchEngines.includes(e.target.value) && searchEngines.length === 1) return;

        // Toggle the search engine options
        if (searchEngines.includes(e.target.value)) {
            setSearchEngines(searchEngines.filter(v => v !== e.target.value));
        } else {
            setSearchEngines(searchEngines.concat(e.target.value));
        }

    }

    return (
        <>
            <h3>Search Ranking</h3>
            <form onSubmit={onSubmit}>
                <div className="form-control">
                    <label htmlFor="keywords">Keywords</label>
                    <input type="text" id="keywords" placeholder="Enter keywords..."
                        value={keywords}
                        onChange={(e) => setKeywords(e.target.value)} required />
                </div>
                <div className="form-control">
                    <label htmlFor="url">URL</label>
                    <input type="text" id="url" placeholder="Enter URL..."
                        value={url}
                        onChange={(e) => setUrl(e.target.value)} required />
                </div>
                {
                    searchEngineOptions.map(opt =>
                        <div key={opt.id} className="form-check">
                            <input className="form-check-input styled-checkbox" type="checkbox" id={opt.id} value={opt.value}
                                checked={searchEngines.includes(opt.value)}
                                onChange={handleCheckboxChange} />
                            <label className="form-check-label" htmlFor={opt.id}>
                                {opt.text}
                            </label>
                        </div>
                    )
                }
                <button className="btn" disabled={loading}>Search Ranking</button>
            </form>
        </>
    )
}
