package com.zjp.domain;

import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.annotation.TableName;
import java.io.Serializable;
import lombok.Data;

/**
 * 
 * @TableName product
 */
@TableName(value ="product")
@Data
public class Product implements Serializable {
    /**
     * 
     */
    @TableId(type = IdType.AUTO)
    private Integer pro_id;

    /**
     * 
     */
    private String pro_name;

    /**
     * 
     */
    private String pro_introduce;

    /**
     * 
     */
    private Integer pro_stock;

    /**
     * 
     */
    private Integer pro_price;

    /**
     * 
     */
    private String pro_sort;

    @TableField(exist = false)
    private static final long serialVersionUID = 1L;
}