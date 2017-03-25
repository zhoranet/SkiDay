import C from './constants'
import fetch from 'isomorphic-fetch'

export const addDay = (resort, date, powder=false, backcountry=false) => dispatch => {

    fetch(window.location.origin + '/home/skidays', {
        credentials: 'same-origin',
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            resort: resort,
            date: date,
            powder: powder,
            backcountry: backcountry
            })
        })        
        .catch(error => {
            dispatch(addError(error.message))
        })
    
    dispatch( {
        type: C.ADD_DAY,
        payload: {resort,date,powder,backcountry}
    })

}

export const fetchSkiDays = () => dispatch => {

    dispatch({
        type: C.FETCH_SKI_DAYS
    })

    fetch(window.location.origin + '/home/skidays', {
        credentials: 'same-origin'})        
        .then(response => response.json())
        .then(skiDays => {

            dispatch({
                type: C.FETCH_SKI_DAYS_COMPLETED,
                payload: skiDays
            })

        })
        .catch(error => {

            dispatch(
                addError(error.message)
            )

            dispatch({
                type: C.CANCEL_FETCHING_SKI_DAYS
            })

        })

}

export const removeDay = function(date) {

    return {
        type: C.REMOVE_DAY,
        payload: date
    }

}

export const setGoal = (goal) => 
    ({
        type: C.SET_GOAL,
        payload: goal
    })

export const addError = (message) => 
   ({
      type: C.ADD_ERROR,
      payload: message
   })

export const clearError = index => 
    ({
        type: C.CLEAR_ERROR,
        payload: index
    })   

export const changeSuggestions = suggestions => 
  ({
    type: C.CHANGE_SUGGESTIONS,
    payload: suggestions
  })

export const clearSuggestions = () => 
    ({
        type: C.CLEAR_SUGGESTIONS
    })

export const suggestResortNames = value => dispatch => {

    dispatch({
        type: C.FETCH_RESORT_NAMES
    })

    fetch(window.location.origin + '/home/resorts/' + value, {
        credentials: 'same-origin'
        })
        .then(response => response.json())
        .then(suggestions => {

            dispatch({
                type: C.CHANGE_SUGGESTIONS,
                payload: suggestions
            })

        })
        .catch(error => {

            dispatch(
                addError(error.message)
            )

            dispatch({
                type: C.CANCEL_FETCHING
            })

        })

}
