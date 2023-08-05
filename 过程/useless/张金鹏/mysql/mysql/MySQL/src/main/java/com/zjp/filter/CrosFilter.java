package com.zjp.filter;


import javax.servlet.*;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebFilter(filterName = "crosFilter", urlPatterns = "/*")
public class CrosFilter implements Filter {


	@Override
	public void init(FilterConfig filterConfig) throws ServletException {

	}

	@Override
	public void doFilter(ServletRequest servletRequest, ServletResponse servletResponse,
			FilterChain filterChain) throws IOException, ServletException {
		HttpServletRequest resquest = (HttpServletRequest)servletRequest;
		HttpServletResponse response = (HttpServletResponse)servletResponse;
		response.addHeader("Access-Control-Allow-Methods",
				"GET,POST,OPTIONS");
		response.addHeader("Access-Control-Allow-Headers",
				"X-Requested-With,Content-Type");
		response.addHeader("Access-Control-Allow-Credentials", "true");
		response.addHeader("access-control-allow-origin", "*");
		filterChain.doFilter(resquest, response);
	}

	@Override
	public void destroy() {

	}
}