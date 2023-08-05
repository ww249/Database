package com.zjp.domain;

import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.annotation.TableName;
import java.io.Serializable;
import lombok.Data;

/**
 * 
 * @TableName address
 */
@TableName(value ="address")
@Data
public class Address implements Serializable {
    /**
     * 
     */
    @TableId
    private Integer add_id;

    /**
     * 
     */
    private String add_name;

    /**
     * 
     */
    private String add_phone;

    /**
     * 
     */
    private String add_info;

    @TableField(exist = false)
    private static final long serialVersionUID = 1L;
}