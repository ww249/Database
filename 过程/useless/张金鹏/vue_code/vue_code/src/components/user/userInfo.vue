<template>
	<div>
		<el-button type="primary" style="float: right;" @click="logout">退出登录</el-button>
		<h1 style="text-align: center;">网购</h1>
    <el-row>
      <el-col :span="20" :push='2'>
        <div>
          <el-form :inline="true">
            <el-form-item style="float: left">
              <div v-if="userLoginRole == 1">
                <el-button type="primary" size="small" @click="functionState = 1">订单管理</el-button>
                <el-button type="primary" size="small" @click="functionState = 0">购买产品</el-button>
              </div>
              <div v-if="userLoginRole == 0">
                <el-button type="primary" size="small" @click="functionState = 1">订单管理</el-button>
                <el-button type="primary" size="small" @click="functionState = 2">产品管理</el-button>
              </div>
            </el-form-item>
          </el-form>
        </div>
      </el-col>
    </el-row>

    <div v-if="functionState == 0">
      <el-row>
        <el-col :span="20" :push='2'>
          <div>
            <el-form :inline="true">
              <el-form-item style="float: left" label="查询产品信息:">
                <el-input v-model="keyUser" placeholder="查询所需要的内容......"></el-input>
              </el-form-item>
            </el-form>
          </div>
          <div class="table">
            <el-table
                :data="searchUserinfo(keyUser)"
                border
                style="width: 100%">
              <el-table-column
                  type="index"
                  label="产品编号"
                  align="center"
                  prop="pro_id"
                  width="60">
              </el-table-column>
              <el-table-column
                  label="产品名"
                  prop="pro_name"
                  align="center"
                  width="160">
              </el-table-column>
              <el-table-column
                  label="产品介绍"
                  prop="pro_introduce"
                  align="center"
                  width="160">
              </el-table-column>
              <el-table-column
                  label="库存"
                  prop="pro_stock"
                  align="center"
                  width="160">
              </el-table-column>
              <el-table-column
                  label="价格"
                  prop="pro_price"
                  align="center"
                  width="160">
              </el-table-column>
              <el-table-column
                  label="分类"
                  prop="pro_sort"
                  align="center"
                  width="160">
              </el-table-column>
              <el-table-column label="操作" align="center">
                <template slot-scope="scope">
                  <el-button
                      size="mini"
                      @click="handleBuy(scope.$index, scope.row)">购买</el-button>
                </template>
              </el-table-column>
            </el-table>
          </div>
        </el-col>
      </el-row>
    </div>

    <div v-if="functionState == 1">
      <el-row>
        <el-col :span="20" :push='2'>
          <div>
            <el-form :inline="true">
              <el-form-item style="float: left" label="查询产品信息:">
                <el-input v-model="keyOrder" placeholder="查询所需要的内容......"></el-input>
              </el-form-item>
            </el-form>
          </div>
          <div class="table">
            <el-table
                :data="searchOrderInfo(keyOrder)"
                border
                style="width: 100%">
              <el-table-column
                  type="index"
                  label="订单编号"
                  align="center"
                  prop="ord_id"
                  width="60">
              </el-table-column>
              <el-table-column
                  label="产品名"
                  prop="pro_name"
                  align="center"
                  width="160">
              </el-table-column>
              <el-table-column
                  label="产品数量"
                  prop="ord_num"
                  align="center"
                  width="160">
              </el-table-column>
              <el-table-column
                  label="用户名"
                  prop="log_name"
                  align="center"
                  width="160">
              </el-table-column>
              <el-table-column
                  label="地址"
                  prop="add_name"
                  align="center"
                  width="160">
              </el-table-column>
              <el-table-column
                  label="订单评价"
                  prop="ord_score"
                  align="center"
                  width="160">
              </el-table-column>
              <el-table-column label="操作" align="center">
                <template slot-scope="scope">
                  <el-button
                      size="mini"
                      @click="handleOrderEdit(scope.$index, scope.row)">评价</el-button>
                  <el-button
                      size="mini"
                      type="danger"
                      @click="handleOderDelete(scope.$index, scope.row)">删除</el-button>
                </template>
              </el-table-column>
            </el-table>
          </div>
        </el-col>
      </el-row>
    </div>

    <div v-if="functionState == 2">
      <el-row>
        <el-col :span="20" :push='2'>
          <div>
            <el-form :inline="true">
              <el-form-item style="float: left" label="查询产品信息:">
                <el-input v-model="keyUser" placeholder="查询所需要的内容......"></el-input>
              </el-form-item>
              <el-form-item style="float: right">
                <el-button type="primary" size="small" icon="el-icon-picture-outline" @click="showEcharts.show = true">展示</el-button>
                <el-button type="primary" size="small" icon="el-icon-edit-outline" @click="dialogAdd.show = true">添加</el-button>
              </el-form-item>
            </el-form>
          </div>
          <div class="table">
            <el-table
                :data="searchUserinfo(keyUser)"
                border
                style="width: 100%">
              <el-table-column
                  type="index"
                  label="产品编号"
                  align="center"
                  prop="pro_id"
                  width="60">
              </el-table-column>
              <el-table-column
                  label="产品名"
                  prop="pro_name"
                  align="center"
                  width="160">
              </el-table-column>
              <el-table-column
                  label="产品介绍"
                  prop="pro_introduce"
                  align="center"
                  width="160">
              </el-table-column>
              <el-table-column
                  label="库存"
                  prop="pro_stock"
                  align="center"
                  width="160">
              </el-table-column>
              <el-table-column
                  label="价格"
                  prop="pro_price"
                  align="center"
                  width="160">
              </el-table-column>
              <el-table-column
                  label="分类"
                  prop="pro_sort"
                  align="center"
                  width="160">
              </el-table-column>
              <el-table-column label="操作" align="center">
                <template slot-scope="scope">
                  <el-button
                      size="mini"
                      @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
                  <el-button
                      size="mini"
                      type="danger"
                      @click="handleDelete(scope.$index, scope.row)">删除</el-button>
                </template>
              </el-table-column>
            </el-table>
          </div>
        </el-col>
      </el-row>
    </div>

			<el-dialog title="添加产品信息" :visible.sync="dialogAdd.show">
			    <el-form :model="formDate" ref="formdong" label-width="100px">
			        <el-form-item label="产品名" prop="pro_name">
			          <el-input v-model="formDate.pro_name"></el-input>
			        </el-form-item>
			        <el-form-item label="产品介绍" prop="pro_introduce">
			          <el-input v-model="formDate.pro_introduce"></el-input>
			        </el-form-item>
			        <el-form-item label="库存" prop="pro_stock">
			          <el-input v-model="formDate.pro_stock"></el-input>
			        </el-form-item>
			        <el-form-item label="价格" prop="pro_price">
			          <el-input v-model="formDate.pro_price"></el-input>
			        </el-form-item>
			        <el-form-item label="分类" prop="pro_sort">
			          <el-input v-model="formDate.pro_sort"></el-input>
			        </el-form-item>
			    </el-form>
			    <div slot="footer" class="dialog-footer">
			        <el-button @click="dialogAdd.show = false">取 消</el-button>
			        <el-button type="primary" @click="dialogFormAdd('formdong')">确 定</el-button>
				</div>
			</el-dialog>

      <el-dialog title="购买信息" :visible.sync="dialogBuy.show">
      <el-form :model="BuyData" ref="formdong" label-width="100px">
        <el-form-item label="产品名" prop="pro_name">
          <el-input v-model="BuyData.pro_name" disabled></el-input>
        </el-form-item>
        <el-form-item label="购买数量" prop="pro_num">
          <el-input v-model="BuyData.pro_num"></el-input>
        </el-form-item>
        <el-form-item label="购买地址" prop="address">
          <el-select v-model="BuyData.value" placeholder="请选择地址" >
            <el-option
                v-for="item in address"
                :key="item.add_id"
                :label="item.add_name"
                :value="item.add_id">
            </el-option>
          </el-select>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" @click="dialogBuyFormAdd('formdong')">确 定</el-button>
      </div>
    </el-dialog>
			
			<el-dialog title="编辑产品信息" :visible.sync="dialogEdit.show">
			    <el-form :model="formDate" ref="formdong" label-width="100px">
			        <el-form-item label="产品编号" prop="pro_id">
			          <el-input  v-model="formDate.pro_id" disabled></el-input>
			        </el-form-item>
			        <el-form-item label="产品名" prop="pro_name">
			          <el-input v-model="formDate.pro_name" disabled></el-input>
			        </el-form-item>
			        <el-form-item label="产品介绍" prop="pro_introduce">
			          <el-input v-model="formDate.pro_introduce"></el-input>
			        </el-form-item>
			        <el-form-item label="库存" prop="pro_stock">
			          <el-input v-model="formDate.pro_stock"></el-input>
			        </el-form-item>
			        <el-form-item label="价格" prop="pro_price">
			          <el-input v-model="formDate.pro_price"></el-input>
			        </el-form-item>
              <el-form-item label="分类" prop="pro_sort">
               <el-input v-model="formDate.pro_sort"></el-input>
              </el-form-item>
			    </el-form>
			    <div slot="footer" class="dialog-footer">
			        <el-button @click="dialogEdit.show = false">取 消</el-button>
			        <el-button type="primary" @click="dialogFormEidt('formdong')">确 定</el-button>
				</div>
			</el-dialog>

      <el-dialog title="评价订单" :visible.sync="dialogOderEdit.show">
      <el-form :model="formOrderDate" ref="formdong" label-width="100px">
        <el-form-item label="订单编号" prop="ord_id">
          <el-input  v-model="formOrderDate.ord_id" disabled></el-input>
        </el-form-item>
        <el-form-item label="产品名" prop="pro_name">
          <el-input v-model="formOrderDate.pro_name" disabled></el-input>
        </el-form-item>
        <el-form-item label="产品数量" prop="ord_num">
          <el-input v-model="formOrderDate.ord_num" disabled></el-input>
        </el-form-item>
        <el-form-item label="购买人" prop="log_name">
          <el-input v-model="formOrderDate.log_name" disabled></el-input>
        </el-form-item>
        <el-form-item label="地址" prop="add_name">
          <el-input v-model="formOrderDate.add_name" disabled></el-input>
        </el-form-item>
        <el-form-item label="评价" prop="ord_score">
          <el-input v-model="formOrderDate.ord_score"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogOderEdit.show = false">取 消</el-button>
        <el-button type="primary" @click="dialogOrderFormEidt('formdong')">确 定</el-button>
      </div>
    </el-dialog>

      <el-dialog title="产品库存展示" :visible.sync="showEcharts.show">
      <ve-line :data="chartData"></ve-line>
      <div slot="footer" class="dialog-footer">
        <el-button @click="showEcharts.show = false">关闭</el-button>
      </div>
    </el-dialog>
	</div>
</template>

<style>
  .el-table .warning-row {
    background: oldlace;
  }

  .el-table .success-row {
    background: #f0f9eb;
  }
  .chart {
    height: 400px;
  }
</style>

<script>
import { Loading } from 'element-ui';
  export default {
	name:'UserInfo',
	data() {
	  return {
	    tableData: [],
      tableOrderData: [],
      address: [],
      chartData: {
        columns: ['产品', '库存'],
        rows: [
        ]
      },
      keyUser: '',
      keyOrder: '',
      dialogAdd: {
			show: false
		},
      showEcharts: {
      show: false
    },
      dialogEdit:{
			show: false
		},
    dialogOderEdit:{
      show: false
    },
      dialogBuy:{
      show: false
    },
      formDate:{
			pro_id: '',
			pro_name: '',
			pro_introduce: '',
			pro_stock: '',
			pro_price: '',
			pro_sort: '',
		},
    formOrderDate:{
      ord_id: '',
      pro_name: '',
      ord_num: '',
      log_name: '',
      add_name: '',
      ord_score: '',
    },
    userLoginId: 0,
    userLoginRole: 1,
    functionState: 1,
    BuyData: {
	      pro_id: '',
	      pro_name: '',
	      pro_num: '',
        value: '',
    }
	  }
	},
    watch: {
      tableData(newval,oldval){
        // console.log(newval,oldval);
        for (let i=0 ; i<this.tableData.length ; i++){
          console.log("{'产品':'" + this.tableData[i].pro_name + "','库存':" + this.tableData[i].pro_stock + "}");
          this.chartData.rows.push({'产品':this.tableData[i].pro_name ,'库存':this.tableData[i].pro_stock })
        }
      }
    },
    methods: {
    tableRowClassName({row, rowIndex}) {
        if ((rowIndex % 2) === 0) {
          return 'warning-row';
        } else {
          return 'success-row';
        }
        return '';
      },
	  getInfo(){
		  // let loadingInstance = Loading.service({ fullscreen: true });
		  this.$http
		  .post('/getInfo').then(response => {
				if(response.data.code == 200){
					this.tableData = response.data.data;
          console.log(response.data.data);
					loadingInstance.close();
				}
		  })
	  },
    getOrderInfo(){
      this.$http
          .post('/getOrderInfo').then(response => {
        if(response.data.code == 200){
          this.tableOrderData = response.data.data;
          console.log(response.data.data);
          loadingInstance.close();
        }
      })
    },
    getAddress(){
      this.$http
          .post('/getUserAddress').then( response => {
        if(response.data.code == 200){
          this.address = response.data.data;
          console.log(response.data.data);
          loadingInstance.close();
        }
      })
    },
    getUserLoginRole(){
      this.$http
          .post('/getUserRole').then(response => {
        if(response.data.code == 200){
          console.log(response.data.data);
          this.userLoginRole = response.data.data;
        }
      })
    },
    getUserLoginId(){
      this.$http
          .post('/getUserId').then(response => {
          if(response.data.code == 200){
            console.log(response.data.data);
            this.userLoginId = response.data.data;
          }
        })
    },
	  searchUserinfo(keyUser){
		  return this.tableData.filter((stu) => {
			  if(stu.pro_name.includes(keyUser)){
				  return stu;
			  }
		  })
	  },
    searchOrderInfo(keyOrder){
      return this.tableOrderData.filter((order) => {
        if(order.pro_name.includes(keyOrder)){
          return order;
        }
      })
    },
	  dialogFormAdd(formdong){
		  this.$refs[formdong].validate((valid) => {
			  if(valid){
				  this.$http.post('/saveInfo',this.formDate).then((response) => {
					  if(response.data.code ==200){
						  this.utils.alertMessage(this,'保存成功',true);
						  this.dialogAdd.show = false;
						  location.reload();
					  }else{
						  this.utils.alertMessage(this, response.data.desc, false);
					  }
				  })
			  } else{
				 this.utils.alertMessage(this,'请填写必要信息',false);
				 return;
			  }
		  })
	  },
    dialogBuyFormAdd(formdong){
      this.$refs[formdong].validate((valid) => {
        if(valid){
          this.$http.post('/saveOrder',this.BuyData).then((response) => {
            if(response.data.code ==200){
              this.utils.alertMessage(this,'保存成功',true);
              this.dialogBuy.show = false;
              location.reload();
            }else{
              this.utils.alertMessage(this, response.data.desc, false);
            }
          })
        } else{
          this.utils.alertMessage(this,'请填写必要信息',false);
          return;
        }
      })
    },
	  handleDelete(index,row){
      console.log(row.pro_id);
		  this.$http.post('/deleteById?id='+row.pro_id).then((response) => {
			  this.utils.alertMessage(this,'删除成功',true);
			  location.reload();
		  })
	  },
	  handleEdit(index, row){
		  this.dialogEdit.show = true;
		  this.formDate = {
			  pro_id: row.pro_id,
			  pro_name: row.pro_name,
			  pro_introduce: row.pro_introduce,
			  pro_stock: row.pro_stock,
        pro_price: row.pro_price,
        pro_sort: row.pro_sort,
		  }
	  },
    handleOrderEdit(index, row){
      this.dialogOderEdit.show = true;
      this.formOrderDate = {
        ord_id: row.ord_id,
        pro_name: row.pro_name,
        ord_num: row.ord_num,
        log_name: row.log_name,
        add_name: row.add_name,
        ord_score: row.ord_score,
      }
    },
    handleOderDelete(index,row){
        console.log(row.ord_id);
        this.$http.post('/deleteOrderById?id='+row.ord_id).then((response) => {
          this.utils.alertMessage(this,'删除成功',true);
          location.reload();
        })
      },
	  dialogFormEidt(formdong){
		  this.$refs[formdong].validate((valid) => {
			  if(valid){
				  this.$http.post('/update',this.formDate).then(response => {
					  if(response.data.code == 200){
						  this.dialogEdit.show = false;
						  this.utils.alertMessage(this,'修改成功', true);
						  location.reload();
					  } else {
						  this.dialogEdit.show = false;
						  this.utils.alertMessage(this, response.data.desc, true);
					  }
				  })
			  } else {
				  this.utils.alertMessage(this, '请填写必要信息', false);
				  return;
			  }
		  })
    },
    dialogOrderFormEidt(formdong){
      this.$refs[formdong].validate((valid) => {
        if(valid){
          this.$http.post('/updateOrder',this.formOrderDate).then(response => {
            if(response.data.code == 200){
              this.dialogOderEdit.show = false;
              this.utils.alertMessage(this,'修改成功', true);
              location.reload();
            } else {
              this.dialogOderEdit.show = false;
              this.utils.alertMessage(this, response.data.desc, true);
            }
          })
        } else {
          this.utils.alertMessage(this, '请填写必要信息', false);
          return;
        }
      })
    },
    handleBuy(index,row) {
      this.dialogBuy.show = true;
      this.BuyData = {
        pro_id: row.pro_id,
        pro_name: row.pro_name,
        pro_num: 1,
      }
    },
	  logout(){
		this.$store.commit('logout');
		this.utils.alertMessage(this,'退出登录成功',true);
		location.reload();
	  }
    },
	created() {
	  this.getOrderInfo();
    this.getUserLoginId();
    this.getUserLoginRole();
    this.getInfo();
    this.getAddress();
	},
  }
</script>
