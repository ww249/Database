import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
	state:{
		user: {
			username: window.localStorage.getItem('user' || '[]') == null ? '未登录' : JSON.parse(window.localStorage.getItem('user' || '[]')).username
		},
		routes: []
	},
	mutations:{
		login(state, user){
			state.user = user;
			window.localStorage.setItem('user',JSON.stringify(user));
		},
		logout(state){
			window.localStorage.removeItem('user');
			state.routes = [];
		}
	}
})
