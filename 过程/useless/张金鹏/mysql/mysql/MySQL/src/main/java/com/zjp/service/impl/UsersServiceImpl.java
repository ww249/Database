package com.zjp.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.zjp.domain.Users;
import com.zjp.service.UsersService;
import com.zjp.mapper.UsersMapper;
import org.springframework.stereotype.Service;

/**
* @author 17523
* @description 针对表【users】的数据库操作Service实现
* @createDate 2022-12-03 19:23:13
*/
@Service
public class UsersServiceImpl extends ServiceImpl<UsersMapper, Users>
    implements UsersService{

}




