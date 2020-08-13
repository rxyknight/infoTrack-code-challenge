import React, { createContext, useReducer } from 'react';
import AppReducer from './AppReducer';

const initState = {
    loading: true,
    results: { 
        google: [],
        bing: []
    },
    error: ''
}

export const GlobalContext = createContext(initState);

export const GlobalProvider = ({ children }) => {

    const [state, dispatch] = useReducer(AppReducer, initState);

    //action
    const fetchRequest = () => { 
        dispatch({ 
            type: 'FETCH_REQUEST', 
        });
    }

    const fetchSuccess = (results) => {
        dispatch({
            type: 'FETCH_SUCCESS',
            results,
        });
    }

    const fetchFailure = (error) => {
        dispatch({
            type: 'FETCH_FAILURE',
            error,
        });
    }

    return (
    <GlobalContext.Provider value={{
        state,
        fetchRequest,
        fetchSuccess,
        fetchFailure
    }}>
        {children}
    </GlobalContext.Provider>)
}
