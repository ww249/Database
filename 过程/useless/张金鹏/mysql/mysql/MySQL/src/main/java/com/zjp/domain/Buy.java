package com.zjp.domain;

import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.annotation.TableName;
import java.io.Serializable;
import java.util.Date;
import lombok.Data;

/**
 * 
 * @TableName buy
 */
@TableName(value ="buy")
@Data
public class Buy implements Serializable {
    /**
     * 
     */
    @TableId
    private Integer buy_id;

    /**
     * 
     */
    private Integer ord_id;

    /**
     * 
     */
    private Integer add_id;

    /**
     * 
     */
    private Date buy_time;

    @TableField(exist = false)
    private static final long serialVersionUID = 1L;
}