using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayUtil.Utils
{
    /// <summary>
    /// 微信支付基础配置数据
    /// </summary>
    public class WxPayBasicItem
    {
        /// <summary>
        /// 小程序ID 必填
        /// </summary>
        public static string appid = "";

        /// <summary>
        /// 商户号 必填
        /// </summary>
        public static string mch_id = "";

        /// <summary>
        /// 商户证书序列号 必填
        /// </summary>
        public static string serial_no = "";

        /// <summary>
        /// 商户私钥 必填
        /// </summary>
        public static string private_key = "";

        /// <summary>
        /// 小程序支付请求url
        /// </summary>
        //public static string order_url = "https://api.mch.weixin.qq.com/v3/pay/transactions/jsapi";

        /// <summary>
        /// app支付请求url
        /// </summary>
        public static string app_url = "https://api.mch.weixin.qq.com/v3/pay/transactions/app";

        /// <summary>
        /// 预支付完成后的通知地址
        /// </summary>
        public static string order_notify_url = "https://weixin.qq.com/"; 

        /// <summary>
        /// 交易类型 小程序取值"JSAPI"
        /// </summary>
        //public static string trade_type = "JSAPI";

        /// <summary>
        /// 查询订单请求url
        /// </summary>
        public static string query_url = "https://api.mch.weixin.qq.com/v3/pay/transactions/id";

        /// <summary>
        /// 应用密钥 
        /// </summary>
        //public static string secret = "";

        /// <summary>
        /// 授权登录url
        /// </summary>
        public static string auth_login_url = "https://api.weixin.qq.com/sns/oauth2/access_token";

        /// <summary>
        /// 微信获取用户信息url
        /// </summary>
        public static string wx_user_url = "https://api.weixin.qq.com/sns/userinfo";
    }

    /// <summary>
    /// App预支付参数
    /// </summary>
    public class AppPaymentData
    {
        /// <summary>
        /// 小程序ID
        /// </summary>
        //[Required]
        public string appid { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string mchid { get; set; }

        /// <summary>
        /// 商品描述 商品简单描述，不超过128字节
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string out_trade_no { get; set; }

        /// <summary>
        /// 交易结束时间 yyyyMMddHHmmss，非必填
        /// </summary>
        //public string time_expire { get; set; }

        /// <summary>
        /// 附加数据 非必填
        /// </summary>
        //public string attach { get; set; }

        /// <summary>
        /// 异步通知地址 通知url必须为外网可访问的url，不能携带参数。
        /// </summary>
        public string notify_url { get; set; }

        /// <summary>
        /// 订单优惠标记
        /// </summary>
        //public string goods_tag { get; set; }

        /// <summary>
        /// 订单金额信息
        /// </summary>
        public PaymentDataAmount amount { get; set; }

        /// <summary>
        /// 场景信息
        /// </summary>
        //public PaymentDataScene scene_info { get; set; }

        /// <summary>
        /// 结算信息
        /// </summary>
        //public PaymentDataSettle settle_info { get; set; }
    }

    /// <summary>
    /// 订单金额
    /// </summary>
    public class PaymentDataAmount
    {
        /// <summary>
        /// 总金额 订单总金额，单位为分
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 货币类型 非必填，默认"CNY"
        /// </summary>
        public string currency { get; set; }
    }

    /// <summary>
    /// App调起支付参数
    /// </summary>
    public class AppPayBackItem
    {
        /// <summary>
        /// 应用id
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string partnerid { get; set; }

        /// <summary>
        /// 预支付交易会话ID
        /// </summary>
        public string prepayid { get; set; }

        /// <summary>
        /// 订单详情扩展字符串
        /// </summary>
        public string package { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string noncestr { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }

    }
}
