package com.zjp.domain;

import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.annotation.TableName;
import java.io.Serializable;
import lombok.Data;

/**
 * 
 * @TableName address_info
 */
@TableName(value ="address_info")
@Data
public class AddressInfo implements Serializable {
    /**
     * 
     */
    @TableId
    private Integer inf_id;

    /**
     * 
     */
    private Integer use_id;

    /**
     * 
     */
    private Integer add_id;

    /**
     * 
     */
    private String inf_relationship;

    @TableField(exist = false)
    private static final long serialVersionUID = 1L;
}