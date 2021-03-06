import C from './constants'
import React from 'react'
import { render } from 'react-dom'
import routes from './routes'
import sampleData from './initialState'
import storeFactory from './store'
import { Provider } from 'react-redux'
import { addError, fetchSkiDays } from './actions'

const initialState = sampleData

const handleError = error => {
	store.dispatch(
		addError(error.message)
	)
}

const loadSkiDays = event => {
	store.dispatch(fetchSkiDays())	
}

const store = storeFactory(initialState)

window.React = React
window.store = store

window.addEventListener("error", handleError)
window.addEventListener("load", loadSkiDays)

render(
	<Provider store={store}>
	   {routes}
	</Provider>,
  document.getElementById('react-container')
)
