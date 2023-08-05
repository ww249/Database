package com.zjp.domain;

import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.annotation.TableName;
import java.io.Serializable;
import lombok.Data;

/**
 * 
 * @TableName orderproductaddress
 */
@TableName(value ="orderproductaddress")
@Data
public class Orderproductaddress implements Serializable {
    /**
     * 
     */
    private Integer ord_id;

    /**
     * 
     */
    private String pro_name;

    /**
     * 
     */
    private Integer ord_num;

    /**
     * 
     */
    private String log_name;

    /**
     * 
     */
    private String add_name;

    /**
     * 0-10分
     */
    private Integer ord_score;

    @TableField(exist = false)
    private static final long serialVersionUID = 1L;
}