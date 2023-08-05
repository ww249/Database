package com.zjp.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.zjp.domain.Product;
import com.zjp.service.ProductService;
import com.zjp.mapper.ProductMapper;
import org.springframework.stereotype.Service;

/**
* @author 17523
* @description 针对表【product】的数据库操作Service实现
* @createDate 2022-12-03 19:23:13
*/
@Service
public class ProductServiceImpl extends ServiceImpl<ProductMapper, Product>
    implements ProductService{

}




