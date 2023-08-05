package com.zjp.domain;

import com.baomidou.mybatisplus.annotation.IdType;
import com.baomidou.mybatisplus.annotation.TableField;
import com.baomidou.mybatisplus.annotation.TableId;
import com.baomidou.mybatisplus.annotation.TableName;
import java.io.Serializable;
import lombok.Data;

/**
 * 
 * @TableName login
 */
@TableName(value ="login")
@Data
public class Login implements Serializable {
    /**
     * 
     */
    @TableId
    private Integer log_id;

    /**
     * 
     */
    private String log_name;

    /**
     * 
     */
    private String log_password;

    /**
     * 0 — 管理员
1 — 顾客
     */
    private Integer log_role;

    @TableField(exist = false)
    private static final long serialVersionUID = 1L;
}