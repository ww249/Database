package com.zjp.domain;

import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.annotation.TableName;
import java.io.Serializable;
import lombok.Data;

/**
 * 
 * @TableName users
 */
@TableName(value ="users")
@Data
public class Users implements Serializable {
    /**
     * 
     */
    @TableId
    private Integer use_id;

    /**
     * 0 - 男
1 - 女

     */
    private Integer use_sex;

    /**
     * 
     */
    private String use_hobby;

    /**
     * 
     */
    private String use_name;

    @TableField(exist = false)
    private static final long serialVersionUID = 1L;
}