package com.zjp;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.web.servlet.ServletComponentScan;

@SpringBootApplication
@MapperScan("com.zjp.mapper")
@ServletComponentScan
public class MySqlApplication {

    public static void main(String[] args) {
        SpringApplication.run(MySqlApplication.class, args);
    }

}
