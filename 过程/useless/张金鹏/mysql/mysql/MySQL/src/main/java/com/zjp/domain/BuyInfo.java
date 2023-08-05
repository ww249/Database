package com.zjp.domain;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

/**
 * @author kingzhang
 * @create 2022-12-09 16:42
 */
@Data
@AllArgsConstructor
@NoArgsConstructor
public class BuyInfo {

    private Integer pro_id;

    private String pro_name;

    private Integer pro_num;

    private Integer value;



}
