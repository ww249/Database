package com.zjp.service.impl;

import com.baomidou.mybatisplus.extension.service.impl.ServiceImpl;
import com.zjp.domain.Login;
import com.zjp.service.LoginService;
import com.zjp.mapper.LoginMapper;
import org.springframework.stereotype.Service;

/**
* @author 17523
* @description 针对表【login】的数据库操作Service实现
* @createDate 2022-12-03 19:23:13
*/
@Service
public class LoginServiceImpl extends ServiceImpl<LoginMapper, Login>
    implements LoginService{

}




