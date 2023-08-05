using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayUtil.Utils;

namespace PayUtil.Controllers
{
    /// <summary>
    /// 支付
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        #region 支付宝支付

        /// <summary>
        /// app支付接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ali/app_pay")]
        public ActionResult<IEnumerable<string>> AppPay()
        {
            IAopClient client = new DefaultAopClient(AliPayBasicItem.url, AliPayBasicItem.app_id, AliPayBasicItem.merchant_private_key, AliPayBasicItem.format, AliPayBasicItem.version, AliPayBasicItem.sign_type, AliPayBasicItem.alipay_public_key, AliPayBasicItem.charset, false);
            AlipayTradeAppPayRequest request = new AlipayTradeAppPayRequest();

            AlipayTradeAppPayModel model = new AlipayTradeAppPayModel();
            model.TotalAmount = "0.01"; // 订单总金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]
            //model.Body = ""; // 商品描述
            model.Subject = "交易标题"; // 商品标题/交易标题/订单标题/订单关键字等
            model.OutTradeNo = ""; // 商户订单号，由商家自定义，需保证商家系统中唯一。仅支持数字、字母、下划线
            model.ProductCode = "QUICK_MSECURITY_PAY"; // 销售产品码，商家和支付宝签约的产品码。QUICK_MSECURITY_PAY：App支付。
            request.SetBizModel(model);  // 将业务model载入到request
            //request.SetNotifyUrl(AliPayBasicItem.pay_notify_url); 

            AlipayTradeAppPayResponse response = client.SdkExecute(request);
            var info = response.Body;

            return Ok(new
            {
                status = true,
                msg = "",
                data = new { info }  // 将这里的info直接返给前端
            });
        }

        #endregion

        #region 微信支付
        
        /// <summary>
        /// App下单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("weixin/app_pay")]
        public ActionResult<IEnumerable<string>> AppOrder()
        {
            var pay_item = new AppPaymentData();
            pay_item.amount = new PaymentDataAmount();
            string url = WxPayBasicItem.app_url;

            pay_item.appid = WxPayBasicItem.appid;
            pay_item.mchid = WxPayBasicItem.mch_id;
            pay_item.description = ""; //交易描述
            pay_item.out_trade_no = ""; //商户订单号，商户系统中唯一
            pay_item.notify_url = WxPayBasicItem.order_notify_url;
            pay_item.amount.total = 1; //这里是int类型，单位为分
            pay_item.amount.currency = "CNY";

            string response = WxPayMethod.PayTest(pay_item);

            if (!string.IsNullOrEmpty(response))
            {
                //处理返回结果
                string prepayid = ((JObject)JsonConvert.DeserializeObject(response))["prepay_id"].ToString();
                var info = new AppPayBackItem();
                info.appid = WxPayBasicItem.appid;
                info.partnerid = WxPayBasicItem.mch_id;
                info.prepayid = prepayid;
                info.package = "Sign=WXPay"; // 照着填
                info.noncestr = WxPayMethod.GetNonceStr();
                info.timestamp = WxPayMethod.GetTimeStamp();
                string to_sign = info.appid + "\n" + info.timestamp + "\n" + info.noncestr + "\n" + info.prepayid + "\n";
                info.sign = WxPayMethod.RsaSign(to_sign, WxPayBasicItem.private_key);

                return Ok(new
                {
                    status = true,
                    msg = "操作完成",
                    data = info  //把这个返回给前端就行
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "操作失败",
                    data = ""
                });
            }

        }

        #endregion

    }
}
