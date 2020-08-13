export default (state, action) => {
    switch(action.type) {
        case 'FETCH_REQUEST': 
            return {
                ...state,
                loading: true,
                error: ''
            }
        case 'FETCH_SUCCESS':
            return {
                ...state,
                loading: false,
                results: action.results
            }
        case 'FETCH_FAILURE':
            return {
                ...state,
                loading: false, 
                error: action.error
            }
        default:
            throw new Error();
    }
}