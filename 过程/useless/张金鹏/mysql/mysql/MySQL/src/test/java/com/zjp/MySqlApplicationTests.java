package com.zjp;


import com.zjp.domain.Login;
import com.zjp.domain.Users;
import com.zjp.mapper.LoginMapper;
import com.zjp.mapper.UsersMapper;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;

import javax.annotation.Resource;
import java.util.Locale;
import java.util.Random;

@SpringBootTest
class MySqlApplicationTests {

    @Resource
    private UsersMapper usersMapper;

    @Resource
    private LoginMapper loginMapper;


    @Test
    void contextLoads() {
        String name = null;
        String password = null;
        int n = 0;
        Random random = new Random();
        for (int i = 0; i < 100000; i++) {
            Login login = new Login();
            login.setLog_name("test54" + n);
            login.setLog_password("123456" + n);
            loginMapper.insert(login);
            n++;
        }

//        Users user = new Users();
//        user.setUse_id(0);
//        user.setUse_sex(0);
//        user.setUse_hobby("衣服");
//        user.setUse_name("zjp");
//
//        usersMapper.insert(user);

    }

}
