<template>
	<div class="firstLogin">
    <h1 style="text-align: center;margin-bottom: -200px">产品管理后台</h1>
    <el-form :model="loginForm" :rules="rules" ref="loginForm" class="login_form">
			<h2 style="text-align: center;">用户登录界面</h2>
			<el-form-item prop="log_name">
				<el-input type="text" placeholder="请输入用户名" v-model="loginForm.log_name"></el-input>
			</el-form-item>
			<el-form-item prop="log_password">
				<el-input placeholder="请输入密码" type="password" v-model="loginForm.log_password" show-password></el-input>
			</el-form-item>
			<el-form-item style="width: 100%;">
				<span style="padding-left: 180px;">
					<el-button round type="primary" style="width: 40%;" @click="login('loginForm')">登录</el-button>
				</span>
				<span style="padding-left: 140px;">
					<router-link to="/register">注册</router-link>
				</span>
			</el-form-item>
		</el-form>
	</div>
</template>

<script>
	export default {
		name : 'Login',
		data(){
			return {
				options : {
					disabledDate(time){
						return time.getTime() > Date.now();
					}
				},
				loginForm: {
					log_name : '',
					log_password : ''
				},
				date : '',
				value1 : '',
				show : true,
				rules:{
          log_name: [{required: true, message: '请输入用户名', trigger: 'blur'}],
          log_password: [{required: true, message: '请输入密码', trigger: 'blur'}]
				}
			}
		},
		computed:{
			Message : function(){
				switch(this.show){
					case true : return '开'
					case false: return '关'
				}
			}
		},
		methods:{
			login(formName){
				var _this = this;
				this.$refs[formName].validate((valid) => {
					if(valid){
						this.$http
						.post("/login",{
              log_name : this.loginForm.log_name,
              log_password : this.loginForm.log_password,
						}).then(response => {
							if(response.data.code == 200){
								this.utils.alertMessage(this,'登陆成功',true);
								_this.$store.commit('login', this.loginForm);
								_this.$router.push('/user');
							}
							else {
								this.utils.alertMessage(this, response.data.desc, false);
							}
						})
					} else {
						this.utils.alertMessage(this,'验证失败',false);
						return;
					}
				})
			}
		}
	}
</script>

<style>
.login_form{
	border: 1px solid #2C3E50;
	border-radius: 15px;
	background-clip: padding-box;
	margin: 300px auto;
	width: 600px;
	padding: 35px 35px 35px 35px;
}
</style>
