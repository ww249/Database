using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayUtil.Utils
{
    /// <summary>
    /// 支付宝支付基础配置数据 
    /// （必填的一定要是真实的数据，在跟支付宝签约的时候都能拿到）
    /// </summary>
    public class AliPayBasicItem
    {
        /// <summary>
        /// 开发者的应用ID （必填，填你自己的）
        /// </summary>
        public static string app_id = "";

        /// <summary>
        /// 请求使用的编码格式
        /// </summary>
        public static string charset = "utf-8";

        /// <summary>
        /// 仅支持"JSON"，非必填
        /// </summary>
        public static string format = "json";

        /// <summary>
        /// 签名算法，仅支持RSA和RSA2
        /// </summary>
        public static string sign_type = "RSA2";

        /// <summary>
        /// 调用的接口版本 
        /// </summary>
        public static string version = "1.0";

        /// <summary>
        /// 支付宝请求url
        /// </summary>
        public static string url = "https://openapi.alipay.com/gateway.do";

        /// <summary>
        /// 商户私钥 （必填）
        /// </summary>
        public static string merchant_private_key = "";

        /// <summary>
        /// 支付宝公钥 （必填）
        /// </summary>
        public static string alipay_public_key = "";

        /// <summary>
        /// 支付完成后的通知地址 非必填
        /// </summary>
        public static string pay_notify_url = "";

        /// <summary>
        /// 币种
        /// </summary>
        public static string currency = "CNY";

        /// <summary>
        /// 退款完成后的通知地址 非必填
        /// </summary>
        //public static string refund_notify_url = "";

        /// <summary>
        /// 应用名称
        /// </summary>
        public static string app_name = "mc";

        /// <summary>
        /// 签约号 （必填）
        /// </summary>
        public static string pid = "";
    }
}
