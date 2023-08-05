package com.zjp.domain;

import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.annotation.TableName;
import java.io.Serializable;
import lombok.Data;

/**
 * 
 * @TableName orders
 */
@TableName(value ="orders")
@Data
public class Orders implements Serializable {
    /**
     * 
     */
    @TableId(type = IdType.AUTO)
    private Integer ord_id;

    /**
     * 
     */
    private Integer ord_num;

    /**
     * 0-10分
     */
    private Integer ord_score;

    /**
     * 
     */
    private Integer add_id;

    /**
     * 
     */
    private Integer pro_id;

    @TableField(exist = false)
    private static final long serialVersionUID = 1L;
}