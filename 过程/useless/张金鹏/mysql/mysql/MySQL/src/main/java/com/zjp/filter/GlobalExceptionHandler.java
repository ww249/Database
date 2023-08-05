package com.zjp.filter;


import com.zjp.constant.Const;
import com.zjp.domain.Result;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.RestControllerAdvice;
import org.springframework.web.context.request.WebRequest;
import org.springframework.web.servlet.mvc.method.annotation.ResponseEntityExceptionHandler;

@RestControllerAdvice
public class GlobalExceptionHandler extends ResponseEntityExceptionHandler {


//	@Override
//	protected ResponseEntity<Object> handleExceptionInternal
//			(Exception ex, Object body, HttpHeaders headers,
//			 HttpStatus status, WebRequest request) {
//		return new ResponseEntity<>(handlerException(ex), HttpStatus.OK);
//	}
//
//	@ExceptionHandler(CommonException.class)
//	public Result<Void> handlerException(Exception e){
//		Result<Void> result = new Result<>();
//		CommonException ex = (CommonException) e ;
//		result.setCode(ex.getCode() == null ? Const.ERROR_CODE : ex.getCode());
//		result.setDesc(e.getMessage());
//		return result;
//	}
}
