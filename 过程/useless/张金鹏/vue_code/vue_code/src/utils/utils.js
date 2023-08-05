export default {
	alertMessage : function(vm, msg, flag){
		vm.$message({
			showClose:false,
			message : msg,
			center : true,
			type : flag? 'success':'error'
		});
	}
}