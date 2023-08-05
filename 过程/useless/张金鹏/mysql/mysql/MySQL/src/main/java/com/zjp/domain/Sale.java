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
 * @TableName sale
 */
@TableName(value ="sale")
@Data
public class Sale implements Serializable {
    /**
     * 
     */
    @TableId
    private Integer sal_id;

    /**
     * 
     */
    private Integer pro_id;

    /**
     * 
     */
    private Integer ord_id;

    /**
     * 
     */
    private Date sal_time;

    @TableField(exist = false)
    private static final long serialVersionUID = 1L;
}