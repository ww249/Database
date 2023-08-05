package com.zjp.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.zjp.domain.Orders;
import com.zjp.service.OrdersService;
import com.zjp.mapper.OrdersMapper;
import org.springframework.stereotype.Service;

/**
* @author 17523
* @description 针对表【orders】的数据库操作Service实现
* @createDate 2022-12-10 13:22:21
*/
@Service
public class OrdersServiceImpl extends ServiceImpl<OrdersMapper, Orders>
    implements OrdersService{

}




