import React, { useContext } from 'react';
import { GlobalContext } from '../context/GlobalContext';

export const ResultArea = () => {
    const { state: { results, loading, error } } = useContext(GlobalContext);
    return (
        <div className="result">
            {loading && <div className="loader"></div> }
            {!loading && error && <p>{error}</p> }
            {!loading && !error && Object.keys(results).map(k => <p key = {k}>
                {k}: {results[k].join(',')}
            </p>)}
        </div>
    )
}
