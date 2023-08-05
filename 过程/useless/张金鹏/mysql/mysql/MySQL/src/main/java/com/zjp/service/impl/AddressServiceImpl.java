package com.zjp.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.zjp.domain.Address;
import com.zjp.service.AddressService;
import com.zjp.mapper.AddressMapper;
import org.springframework.stereotype.Service;

/**
* @author 17523
* @description 针对表【address】的数据库操作Service实现
* @createDate 2022-12-03 19:23:13
*/
@Service
public class AddressServiceImpl extends ServiceImpl<AddressMapper, Address>
    implements AddressService{

}




