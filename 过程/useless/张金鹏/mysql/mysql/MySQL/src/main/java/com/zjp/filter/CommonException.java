package com.zjp.filter;

import com.zjp.constant.Const;
import lombok.Data;

@Data
public class CommonException extends Exception {

	private Integer code = Const.ERROR_CODE;

	private String message;

	public CommonException(String message) {
		this.message = message;
	}

	public CommonException(Integer code, String message) {
		this.code = code;
		this.message = message;
	}
}
