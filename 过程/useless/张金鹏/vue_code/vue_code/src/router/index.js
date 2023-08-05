import Vue from 'vue'
import Router from 'vue-router'
import Login from '@/components/login/Login'
import HelloWorld from '@/components/HelloWorld'
import UserInfo from '@/components/user/userInfo'
import Register from '@/components/login/register.vue'

Vue.use(Router)

export default new Router({
	routes:[
		{
			path : '/',
			name : '登录',
			component : Login
		},{
			path : '/login',
			name : '登录',
			component : Login
		},{
			path : '/user',
			name : '用户信息',
			component : UserInfo,
			hidden: true,
			meta:{
				requireAuth:true
			}
		},{
			path : '/register',
			name : '用户注册',
			component : Register
		}
	]
})