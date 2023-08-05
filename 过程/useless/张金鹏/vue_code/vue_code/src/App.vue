<!-- <template>
  <div id="app">
	<Login></Login>
  </div>
</template> -->
<template>
	<div id="main" class="app-main">
		<router-view></router-view>
	</div>
</template>

<script>
// import HelloWorld from './components/HelloWorld.vue'
// import Login from './components/login/Login.vue'

export default {
  // name: 'app',
  // components: {
  //   Login
  // }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
.hello{
	margin-left: 200px;
	width: 1000px;
	height: 500px;
}
</style>
