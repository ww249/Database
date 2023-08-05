import Vue from 'vue'
import App from './App'
import router from './router/index'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import qs from 'qs'
import axios from 'axios'
import VueAxios from 'vue-axios'
import utils from '@/utils/utils'
import moment from 'moment'
import store from './store'
import VCharts from 'v-charts'

Vue.use(VCharts)
Vue.use(ElementUI)
Vue.use(VueAxios, axios)
Vue.prototype.$axios = axios
Vue.prototype.$qs = qs
Vue.prototype.utils = utils
axios.defaults.baseURL = 'http://localhost:8082'


router.beforeEach((to, from, next) => {
	if (to.name == 'Login') {
		next();
		return;
	}
	var username = store.state.user.username;
	if(username == '未登录'){
		if(to.meta.requireAuth || to.name == null){
			next({path: '/'})
		} else {
			next();
		}
	} else {
		next();
	}
		
})
Vue.config.productionTip = false
Vue.filter('moment',function(value,formatString){
	formatString = formatString || 'YYYY-MM-DD';
	return moment(value).format(formatString);
})

new Vue({
	router: router,
	store: store,
	render : h => h(App)
}).$mount("#app")
