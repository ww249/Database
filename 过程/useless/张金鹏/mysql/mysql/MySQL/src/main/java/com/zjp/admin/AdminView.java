package com.zjp.admin;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableModel;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

public class AdminView {
    JFrame jFrame = new JFrame("管理员界面");
    JTabbedPane tabbedPane = new JTabbedPane(SwingConstants.LEFT, JTabbedPane.SCROLL_TAB_LAYOUT);
    
    JPanel frame_1;
    private JTextField textField_1;
	private JTextField textField_2;
	private JTextField textField_3;
	private JTextField textField_4;
	private JTextField textField_5;
	private JTextField textField_6;
	private JTextField textField_7;
	JScrollPane scrollPane_1 ;
	
	private JTable table_1;
	
	
//	AdminLimitRe limit_1 = new AdminLimitRe();
//	int n_1 = limit_1.list.size();
	
	JPanel frame_2;
	private JTextField textField_11;
	private JTextField textField_12;
	private JTextField textField_13;
	private JTextField textField_14;
	private JTextField textField_15;
	private JTextField textField_16;
	private JTextField textField_17;
	JScrollPane scrollPane_2;
	
	private JTable table_2;
	
//	AdminLimitStu limit_2 = new AdminLimitStu();
//	int n_2 = limit_2.list.size();
	
	String s="";
	int row;
	
	
	public void queryRe(){
//		n_1 = limit_1.list.size();
//		String[] thead = new String[]{"维修员用户名","登录密码"};
//		String[][] tbody = new String[n_1][2];
//
//		for(int i = 0; i < n_1; i++){
//			tbody[i][0] = limit_1.list.get(i).getName();
//			tbody[i][1] = limit_1.list.get(i).getPassword();
//		}
//		TableModel data = new DefaultTableModel(tbody,thead);
//		table_1.setModel(data);
	}
	
	public void queryStu(){
//		n_2 = limit_2.list.size();
//		String[] thead = new String[]{"学生用户名","登录密码"};
//		String[][] tbody = new String[n_2][2];
//
//		for(int i = 0; i < n_2; i++){
//			tbody[i][0] = limit_2.list.get(i).getName();
//			tbody[i][1] = limit_2.list.get(i).getPassword();
//		}
//		TableModel data = new DefaultTableModel(tbody,thead);
//		table_2.setModel(data);
	}
 
//    public void init() {
//
//    	frame_1 = new JPanel();
//    	frame_1.setBounds(100, 100, 600, 450);
//    	frame_1.setLayout(null);
//		//queryFruit();
//		JLabel label = new JLabel("product manage");
//		label.setBounds(200, 10, 94, 15);
//		frame_1.add(label);
//
//		JLabel label_1 = new JLabel("product name");
//		label_1.setBounds(32, 277, 94, 15);
//		frame_1.add(label_1);
//
//		JLabel lblNewLabel_1 = new JLabel("product ");
//		lblNewLabel_1.setBounds(200, 277, 94, 15);
//		frame_1.add(lblNewLabel_1);
//
//		textField_1 = new JTextField();
//		textField_1.setBounds(33, 302, 86, 21);
//		frame_1.add(textField_1);
//		textField_1.setColumns(10);
//
//		textField_2 = new JTextField();
//		textField_2.setColumns(10);
//		textField_2.setBounds(200, 302, 86, 21);
//		frame_1.add(textField_2);
//
//		textField_3 = new JTextField();
//		textField_3.setEnabled(false);
//		textField_3.setColumns(10);
//		textField_3.setBounds(33, 333, 86, 21);
//		frame_1.add(textField_3);
//
//		textField_4 = new JTextField();
//		textField_4.setColumns(10);
//		textField_4.setBounds(200, 333, 86, 21);
//		frame_1.add(textField_4);
//
//		textField_5 = new JTextField();
//		textField_5.setEnabled(false);
//		textField_5.setColumns(10);
//		textField_5.setBounds(33, 364, 86, 21);
//		frame_1.add(textField_5);
//
//		textField_6 = new JTextField();
//		textField_6.setColumns(10);
//		textField_6.setBounds(33, 395, 86, 21);
//		frame_1.add(textField_6);
//
//		textField_7 = new JTextField();
//		textField_7.setEnabled(false);
//		textField_7.setColumns(10);
//		textField_7.setBounds(200, 395, 86, 21);
//		frame_1.add(textField_7);
//
//
//
//		JButton button_1 = new JButton("添加");
//		button_1.addActionListener(new ActionListener() {
//			public void actionPerformed(ActionEvent arg0) {
//				try{
//					People people = new People(textField_1.getText(),textField_2.getText());
//					if(!limit_1.isExist(textField_1.getText())){
//						if(textField_1.getText().equals(""))
//							JOptionPane.showMessageDialog(null, "信息不完整！");
//						else
//							limit_1.addPeople(people);
//					}
//					else
//						JOptionPane.showMessageDialog(null, "该编号已存在！");
//				}
//				catch(Exception ex){
//					JOptionPane.showMessageDialog(null, ex.getMessage());
//				}
//				queryRe();
//			}
//		});
//		button_1.setBounds(380, 301, 73, 23);
//		frame_1.add(button_1);
//
//		JButton button_2 = new JButton("修改");
//		button_2.addActionListener(new ActionListener() {
//			public void actionPerformed(ActionEvent arg0) {
//				try{
//					People people = new People(textField_3.getText(),textField_4.getText());
//
//					if(textField_4.getText().equals(""))
//						JOptionPane.showMessageDialog(null, "信息不完整！");
//					else if(limit_1.isExist(textField_3.getText())){
//						limit_1.updataPeople(people, row);
//						table_1.setRowSelectionInterval(row, row);
//					}
//					else
//						JOptionPane.showMessageDialog(null, "编号不存在！");
//				}
//				catch(Exception ex){
//					JOptionPane.showMessageDialog(null, ex.getMessage());
//				}
//				queryRe();
//			}
//		});
//		button_2.setBounds(380, 332, 73, 23);
//		frame_1.add(button_2);
//
//		JButton button_3 = new JButton("删除");
//		button_3.addActionListener(new ActionListener() {
//			public void actionPerformed(ActionEvent arg0) {
//				if(textField_5.getText().equals(""))
//					JOptionPane.showMessageDialog(null, "编号不能为空！");
//				else{
//					if(limit_1.isExist(textField_5.getText()))
//						limit_1.deletePeople(textField_5.getText());
//					else
//						JOptionPane.showMessageDialog(null, "编号不存在！");
//					queryRe();
//				}
//			}
//		});
//		button_3.setBounds(380, 363, 73, 23);
//		frame_1.add(button_3);
//
//		JButton button_4 = new JButton("查询");
//		button_4.addActionListener(new ActionListener() {
//			public void actionPerformed(ActionEvent arg0) {
//				if(limit_1.isExist(textField_6.getText())){
//					String password = limit_1.selectPeople(textField_6.getText()).getPassword();
//					textField_7.setText(password);
//
//			        String value = textField_6.getText();
//			        textField_3.setText(value);
//			        textField_5.setText(value);
//			        textField_4.setText(password);
//				}
//				else
//					JOptionPane.showMessageDialog(null, "该编号不存在！");
//			}
//		});
//		button_4.setBounds(380, 394, 73, 23);
//		frame_1.add(button_4);
//
//		JButton button_5 = new JButton("返回");
//		button_5.addActionListener(new ActionListener() {
//			public void actionPerformed(ActionEvent arg0) {
//				jFrame.dispose();
//				Login login = new Login();
//				login.frame.setVisible(true);
//			}
//		});
//		button_5.setBounds(380, 425, 73, 23);
//		frame_1.add(button_5);
//
//
//
//
//		table_1 = new JTable();
//		table_1.addMouseListener(new MouseAdapter() {
//			@Override
//			public void mouseClicked(MouseEvent arg0) {
//				row = table_1.getSelectedRow();
//		        String value = (String) table_1.getValueAt(row, 0);
//		        textField_3.setText(value);
//		        textField_5.setText(value);
//		        value = (String) table_1.getValueAt(row, 1);
//		        textField_4.setText(value);
//			}
//		});
//		queryRe();
//		scrollPane_1 = new JScrollPane(table_1);
//		scrollPane_1.setHorizontalScrollBarPolicy(ScrollPaneConstants.HORIZONTAL_SCROLLBAR_ALWAYS);
//		scrollPane_1.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS);
//		scrollPane_1.setBounds(32, 43, 418, 232);
//		frame_1.add(scrollPane_1);
//
//
//
//
//
//
//		frame_2 = new JPanel();
//    	frame_2.setBounds(100, 100, 600, 450);
//    	frame_2.setLayout(null);
//
//		JLabel label2 = new JLabel("学生信息列表");
//		label2.setBounds(200, 10, 94, 15);
//		frame_2.add(label2);
//
//		JLabel label_2 = new JLabel("学生用户名");
//		label_2.setBounds(32, 277, 94, 15);
//		frame_2.add(label_2);
//
//		JLabel lblNewLabel_2 = new JLabel("登录密码");
//		lblNewLabel_2.setBounds(200, 277, 94, 15);
//		frame_2.add(lblNewLabel_2);
//
//		textField_11 = new JTextField();
//		textField_11.setBounds(33, 302, 86, 21);
//		textField_11.setColumns(10);
//		frame_2.add(textField_11);
//
//		textField_12 = new JTextField();
//		textField_12.setColumns(10);
//		textField_12.setBounds(200, 302, 86, 21);
//		frame_2.add(textField_12);
//
//		textField_13 = new JTextField();
//		textField_13.setEnabled(false);
//		textField_13.setColumns(10);
//		textField_13.setBounds(33, 333, 86, 21);
//		frame_2.add(textField_13);
//
//		textField_14 = new JTextField();
//		textField_14.setColumns(10);
//		textField_14.setBounds(200, 333, 86, 21);
//		frame_2.add(textField_14);
//
//		textField_15 = new JTextField();
//		textField_15.setEnabled(false);
//		textField_15.setColumns(10);
//		textField_15.setBounds(33, 364, 86, 21);
//		frame_2.add(textField_15);
//
//		textField_16 = new JTextField();
//		textField_16.setColumns(10);
//		textField_16.setBounds(33, 395, 86, 21);
//		frame_2.add(textField_16);
//
//		textField_17 = new JTextField();
//		textField_17.setEnabled(false);
//		textField_17.setColumns(10);
//		textField_17.setBounds(200, 395, 86, 21);
//		frame_2.add(textField_17);
//
//
//
//		JButton button_11 = new JButton("添加");
//		button_11.addActionListener(new ActionListener() {
//			public void actionPerformed(ActionEvent arg0) {
//				try{
//					People people = new People(textField_11.getText(),textField_12.getText());
//					if(!limit_2.isExist(textField_11.getText())){
//						if(textField_11.getText().equals(""))
//							JOptionPane.showMessageDialog(null, "信息不完整！");
//						else
//						limit_2.addPeople(people);
//					}
//					else
//						JOptionPane.showMessageDialog(null, "该编号已存在！");
//				}
//				catch(Exception ex){
//					JOptionPane.showMessageDialog(null, ex.getMessage());
//				}
//				queryStu();
//			}
//		});
//		button_11.setBounds(380, 301, 73, 23);
//		frame_2.add(button_11);
//
//		JButton button_12 = new JButton("修改");
//		button_12.addActionListener(new ActionListener() {
//			public void actionPerformed(ActionEvent arg0) {
//				try{
//					People people = new People(textField_13.getText(),textField_14.getText());
//
//					if(textField_14.getText().equals(""))
//						JOptionPane.showMessageDialog(null, "信息不完整！");
//					else if(limit_2.isExist(textField_13.getText())){
//						limit_2.updataPeople(people, row);
//						table_2.setRowSelectionInterval(row, row);
//					}
//					else
//						JOptionPane.showMessageDialog(null, "编号不存在！");
//				}
//				catch(Exception ex){
//					JOptionPane.showMessageDialog(null, ex.getMessage());
//				}
//				queryStu();
//			}
//		});
//		button_12.setBounds(380, 332, 73, 23);
//		frame_2.add(button_12);
//
//		JButton button_13 = new JButton("删除");
//		button_13.addActionListener(new ActionListener() {
//			public void actionPerformed(ActionEvent arg0) {
//				if(textField_15.getText().equals(""))
//					JOptionPane.showMessageDialog(null, "编号不能为空！");
//				else{
//					if(limit_2.isExist(textField_15.getText()))
//						limit_2.deletePeople(textField_15.getText());
//					else
//						JOptionPane.showMessageDialog(null, "编号不存在！");
//					queryStu();
//				}
//			}
//		});
//		button_13.setBounds(380, 363, 73, 23);
//		frame_2.add(button_13);
//
//		JButton button_14 = new JButton("查询");
//		button_14.addActionListener(new ActionListener() {
//			public void actionPerformed(ActionEvent arg0) {
//				if(limit_2.isExist(textField_16.getText())){
//					String password = limit_2.selectPeople(textField_16.getText()).getPassword();
//					textField_17.setText(password);
//
//			        String value = textField_16.getText();
//			        textField_13.setText(value);
//			        textField_15.setText(value);
//			        textField_14.setText(password);
//				}
//				else
//					JOptionPane.showMessageDialog(null, "该编号不存在！");
//			}
//		});
//		button_14.setBounds(380, 394, 73, 23);
//		frame_2.add(button_14);
//
//		JButton button_15 = new JButton("返回");
//		button_15.addActionListener(new ActionListener() {
//			public void actionPerformed(ActionEvent arg0) {
//				jFrame.dispose();
//				Login login = new Login();
//				login.frame.setVisible(true);
//			}
//		});
//		button_15.setBounds(380, 425, 73, 23);
//		frame_2.add(button_15);
//
//
//
//
//		table_2 = new JTable();
//		table_2.addMouseListener(new MouseAdapter() {
//			@Override
//			public void mouseClicked(MouseEvent arg0) {
//				row = table_2.getSelectedRow();
//		        String value = (String) table_2.getValueAt(row, 0);
//		        textField_13.setText(value);
//		        textField_15.setText(value);
//		        value = (String) table_2.getValueAt(row, 1);
//		        textField_14.setText(value);
//			}
//		});
//		queryStu();
//		scrollPane_2 = new JScrollPane(table_2);
//		scrollPane_2.setHorizontalScrollBarPolicy(ScrollPaneConstants.HORIZONTAL_SCROLLBAR_ALWAYS);
//		scrollPane_2.setVerticalScrollBarPolicy(ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS);
//		scrollPane_2.setBounds(32, 43, 418, 232);
//		frame_2.add(scrollPane_2);
//
//
//
//
//
//		//添加标签
//        tabbedPane.addTab("维修员信息", frame_1);
//        tabbedPane.addTab("学生信息", frame_2);
//
//        //完成设置
//        tabbedPane.setEnabledAt(0, true);
//        tabbedPane.setSelectedIndex(0);
//        jFrame.add(tabbedPane);
//        jFrame.setBounds(100, 100, 640, 500);
//        jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
//        jFrame.setVisible(true);
//
//	}

	public void init(){

	}

    public AdminView() {
        this.init();
    }
    
//    public static void main(String args[]) {
//    	new AdminView();
//    }
}