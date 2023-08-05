<template>
	<div>
		<el-form class="register_form">
			<router-link to='/login'>返回登录</router-link>
			<h2 style="text-align: center;">注册</h2>
			<el-form-item>
				<el-input placeholder="请输入用户名" v-model="log_name"></el-input>
			</el-form-item>
			<el-form-item>
				<el-input placeholder="请输入密码" type="password" v-model="log_password" show-log_password></el-input>
			</el-form-item>
			<el-form-item>
				<el-input placeholder="请再次输入密码" type="password" v-model="relog_password" show-log_password></el-input>
			</el-form-item>
			<el-form-item>
				<el-button type="primary" style="width: 100%;" @click="register">注册</el-button>
			</el-form-item>
		</el-form>
	</div>
</template>

<script>
	export default {
		name:'Register',
		data(){
			return{
				log_name : '',
				log_password : '',
				relog_password : ''
			}
		},
		methods:{
			register(){
				var _this = this;
				if(this.log_password != this.relog_password){
					this.utils.alertMessage(this, '密码不一致',false);
					return;
				}
				this.$http
				.post('/register',{
					log_name : this.log_name,
					log_password : this.log_password
				}).then(response => {
					if(response.status == 200 && response.data.code ==200){
						this.utils.alertMessage(this,'注册成功',true);
						var loginData = {'log_name': this.log_name};
						_this.$store.commit('login',loginData);
						this.$router.push('/')
					}else{
						this.utils.alertMessage(this,response.data.desc,false);
					}
				})
			}
		}
	}
	
</script>

<style>
	.register_form{
		border: 1px solid #2C3E50;
		border-radius: 15px;
		background-clip: padding-box;
		margin: 300px auto;
		width: 600px;
		padding: 35px 35px 35px 35px;
	}
</style>
