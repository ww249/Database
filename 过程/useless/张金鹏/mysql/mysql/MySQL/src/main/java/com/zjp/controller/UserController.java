package com.zjp.controller;

import com.baomidou.mybatisplus.core.conditions.query.QueryWrapper;
import com.baomidou.mybatisplus.core.toolkit.StringUtils;
import com.zjp.constant.Const;
import com.zjp.domain.*;
import com.zjp.service.*;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;


import javax.annotation.Resource;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

@RestController
public class UserController {

	@Resource
	private LoginService loginService;

	@Resource
	private ProductService productService;

	@Resource
	private AddressService addressService;

	@Resource
	private AddressInfoService addressInfoService;

	@Resource
	private OrdersService ordersService;

	@Resource
	private OrderproductaddressService orderproductaddressService;


	public Integer userLoginId = 0;
	public Integer userLoginRole = 1;


	@RequestMapping("/getUserId")
	public Result<Integer> getUserId() throws Exception {
		Result<Integer> result = new Result<>();
		result.setCode(Const.SUCCESS);
		result.setData(userLoginId);
		return result;
	}

	@RequestMapping("/getUserRole")
	public Result<Integer> getUserROle() throws Exception {
		Result<Integer> result = new Result<>();
		result.setCode(Const.SUCCESS);
		result.setData(userLoginRole);
		return result;
	}

	@RequestMapping("/login")
	public Result<Login> get(@RequestBody Login login){
		Result<Login> result = new Result<>();
		String username = login.getLog_name();
		String password = login.getLog_password();
		System.out.println(username + "---" + password);
		if (StringUtils.isBlank(username)){
			result.setCode(Const.ERROR_CODE);
			result.setDesc("用户名不能为空");
			return result;
		}
		if (StringUtils.isBlank(password)){
			result.setCode(Const.ERROR_CODE);
			result.setDesc("密码不能为空");
			return result;
		}
		QueryWrapper<Login> queryWrapper = new QueryWrapper<>();
		queryWrapper.eq("log_name",username);
		Login loginUser = loginService.getOne(queryWrapper);
		if (Objects.isNull(loginUser)){
			result.setCode(Const.ERROR_CODE);
			result.setDesc("账号不存在");
			return result;
		}
		if (!loginUser.getLog_password().equals(password)){
			result.setCode(Const.ERROR_CODE);
			result.setDesc("密码不正确");
			return result;
		}
		userLoginId = loginUser.getLog_id();
		userLoginRole = loginUser.getLog_role();
		return result;
	}


	@RequestMapping("/register")
	public Result<Void> register(@RequestBody Login login) throws Exception{
		Result<Void> result = new Result<>();
		String username = login.getLog_name();
		String password = login.getLog_password();
		if (StringUtils.isBlank(username)){
			result.setCode(Const.ERROR_CODE);
			result.setDesc("用户名不能为空");
			return result;
		}
		QueryWrapper<Login> queryWrapper = new QueryWrapper<>();
		queryWrapper.eq("log_name",username);
		Login user = loginService.getOne(queryWrapper);
		if (user != null){
			result.setCode(Const.ERROR_CODE);
			result.setDesc("该用户名已经注册过了");
			return result;
		}
		if (StringUtils.isBlank(password)){
			result.setCode(Const.ERROR_CODE);
			result.setDesc("密码不能为空");
			return result;
		}
		loginService.save(login);
		return result;
	}

	@RequestMapping("/getUserAddress")
	public Result<List<Address>> getUserAddress() throws Exception {
		List<Address> addresses = new ArrayList<>();
		Result<List<Address>> result = new Result<>();
		QueryWrapper<AddressInfo> addressInfoQueryWrapper = new QueryWrapper<>();
		addressInfoQueryWrapper.eq("use_id",userLoginId);
		List<AddressInfo> list = addressInfoService.list(addressInfoQueryWrapper);
		QueryWrapper<Address> addressQueryWrapper = null;
		for (AddressInfo addressInfo : list) {
			addressQueryWrapper =  new QueryWrapper<>();
			addressQueryWrapper.eq("add_id",addressInfo.getAdd_id());
			Address address = addressService.getOne(addressQueryWrapper);
			addresses.add(address);
		}
		for (Address address : addresses) {
			System.out.println(address);
		}
		result.setData(addresses);
		return result;
	}

	@RequestMapping("/getInfo")
	public Result<List<Product>> getInfo(){
		Result<List<Product>> result = new Result<>();
		List<Product> list = productService.list();
		for (Product product : list) {
			System.out.println(product);
		}
		result.setData(productService.list());
		return result;
	}

	@RequestMapping("/saveInfo")
	public Result<Void> saveInfo(@RequestBody Product product){
		Result<Void> result = new Result<>();
		productService.save(product);
		return result;
	}


	@RequestMapping("/saveOrder")
	public Result<Void> saveOrder(@RequestBody BuyInfo buyInfo){
		Result<Void> result = new Result<>();
		System.out.println(buyInfo.toString());
		QueryWrapper<Product> productQueryWrapper = new QueryWrapper<>();
		productQueryWrapper.eq("pro_id",buyInfo.getPro_id());
		Product product = productService.getOne(productQueryWrapper);
		if (product.getPro_stock() < buyInfo.getPro_num()) {
			result.setCode(Const.ERROR_CODE);
			result.setDesc("库存不足");
			return result;
		}
		product.setPro_stock(product.getPro_stock() - buyInfo.getPro_num());
		Orders order = new Orders();
		order.setOrd_id(null);
		order.setOrd_num(buyInfo.getPro_num());
		order.setPro_id(buyInfo.getPro_id());
		order.setOrd_score(10);
		order.setAdd_id(buyInfo.getValue());
		System.out.println(order);
		ordersService.save(order);
		productService.updateById(product);
		result.setDesc("购买成功");
		return result;
	}

	@RequestMapping("/update")
	public Result<Void> update(@RequestBody Product product){
		Result<Void> result = new Result<>();
		QueryWrapper<Product> queryWrapper = new QueryWrapper<>();
		queryWrapper.eq("pro_id",product.getPro_id());
		productService.update(product,queryWrapper);
		return result;
	}

	@RequestMapping("/deleteById")
	public Result<Void> deleteById(Integer id){
		System.out.println(id);
		Result<Void> result = new Result<>();
		QueryWrapper<Product> queryWrapper = new QueryWrapper<>();
		queryWrapper.eq("pro_id",id);
		productService.remove(queryWrapper);
		return result;
	}

	@RequestMapping("/getOrderInfo")
	public Result<List<Orderproductaddress>> getOrderInfo(){
		Result<List<Orderproductaddress>> result = new Result<>();
		List<Orderproductaddress> list = null;
		if (userLoginRole == 0){
			list = orderproductaddressService.list();
		}else {
			QueryWrapper<Orderproductaddress> orderproductaddressQueryWrapper = new QueryWrapper<>();
			QueryWrapper<Login> loginQueryWrapper = new QueryWrapper<>();
			loginQueryWrapper.eq("log_id",userLoginId);
			Login login = loginService.getOne(loginQueryWrapper);
			orderproductaddressQueryWrapper.eq("log_name",login.getLog_name());
			list = orderproductaddressService.list(orderproductaddressQueryWrapper);
		}
		for (Orderproductaddress orderproductaddress : list) {
			System.out.println(orderproductaddress);
		}
		result.setData(list);
		return result;
	}

	@RequestMapping("/updateOrder")
	public Result<Void> updateOrder(@RequestBody Orderproductaddress orderproductaddress){
		Result<Void> result = new Result<>();
		QueryWrapper<Orders> queryWrapper = new QueryWrapper<>();
		queryWrapper.eq("ord_id",orderproductaddress.getOrd_id());
		Orders orders = ordersService.getOne(queryWrapper);
		orders.setOrd_score(orderproductaddress.getOrd_score());
		QueryWrapper<Orders> ordersQueryWrapper = new QueryWrapper<>();
		ordersQueryWrapper.eq("ord_id",orderproductaddress.getOrd_id());
		ordersService.update(orders,ordersQueryWrapper);
		return result;
	}

	@RequestMapping("/deleteOrderById")
	public Result<Void> deleteOrderById(Integer id){
		System.out.println(id);
		Result<Void> result = new Result<>();
		QueryWrapper<Orders> queryWrapper = new QueryWrapper<>();
		queryWrapper.eq("ord_id",id);
		ordersService.remove(queryWrapper);
		return result;
	}


}
