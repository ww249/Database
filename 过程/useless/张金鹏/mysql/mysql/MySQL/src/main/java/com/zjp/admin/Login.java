package com.zjp.admin;

import com.zjp.controller.UserController;
import com.zjp.domain.Result;
import org.apache.catalina.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Configuration;

import javax.annotation.Resource;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Login {
	
	JFrame frame;
	Box boxVOne, boxVTwo;		//行型盒式容器
	Box boxH;					//列型盒式容器
	JTextField jText1 = new JTextField(10);		//输入用户名
	JTextField jText2 = new JTextField(10);		//输入密码

	@Resource
	private UserController userController;
	

	public static void main(String[] args) {
		// TODO 自动生成的方法存根
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Login window = new Login();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}
	
	public Login() {
		initialize();
	}
	
	private void initialize() {
		frame = new JFrame();
		frame.setTitle("SHOP");
		frame.setBounds(100, 100, 460, 300);
		frame.setDefaultCloseOperation(JFrame.HIDE_ON_CLOSE);
		frame.getContentPane().setLayout(null);
		
		jText1.setBounds(0, 0, 10, 10);
		boxH = Box.createHorizontalBox();
		boxVOne = Box.createVerticalBox();
		boxVTwo = Box.createVerticalBox();
		boxVOne.add(new JLabel("username:"));
		boxVOne.add(Box.createVerticalStrut(18));
		boxVOne.add(new JLabel("password:"));
		
		boxVTwo.add(jText1);
		boxVTwo.add(Box.createVerticalStrut(10));
		boxVTwo.add(jText2);
		boxVTwo.add(Box.createVerticalStrut(10));
		boxH.add(boxVOne);
		boxH.add(Box.createHorizontalStrut(10));
		boxH.add(boxVTwo);
		
		boxH.setBounds(110, 50, 200, 100);
		frame.getContentPane().add(boxH);
		
		
		JButton btnNewButton = new JButton("login");
		btnNewButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
//				try{
//					Result<com.zjp.domain.Login> login = userController.login(jText1.getText(), jText2.getText());
//					if (login.getCode() != 200){
//						JOptionPane.showMessageDialog(null, "login error");
//					}
//					if (userController.userLoginRole == 0){
//						AdminView admin = new AdminView();
//						admin.jFrame.setVisible(true);
//						frame.dispose();
//					}else {
////						UserView userView = new UserView();
////						userView.jFrame.setVisible(true);
//						frame.dispose();
//					}
//				}
//				catch(Exception ex){
//					JOptionPane.showMessageDialog(null, ex.getMessage());
//				}
			}
		});
		btnNewButton.setBounds(180, 180, 90, 25);
		frame.getContentPane().add(btnNewButton);
	}
	


}