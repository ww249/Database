using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PayUtil.Utils
{
    public static class WxPayMethod
    {
        /// <summary>
        /// 微信app下单
        /// </summary>
        public static string PayTest(AppPaymentData item)
        {
            var param = JsonConvert.SerializeObject(item);

            string sign_url = WxPayBasicItem.app_url.Split(".com")[1].ToString();
            string time_str = GetTimeStamp();
            string nonce_str = GetNonceStr();
            string body_str = param;

            string to_sign_info = "POST" + "\n" + sign_url + "\n" + time_str + "\n" + nonce_str + "\n" + body_str + "\n";
            string sign_info = RsaSign(to_sign_info, WxPayBasicItem.private_key);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(WxPayBasicItem.app_url);
            request.Method = "POST";
            string value = $"WECHATPAY2-SHA256-RSA2048 " + "mchid=\"" + WxPayBasicItem.mch_id + "\",serial_no=\"" + WxPayBasicItem.serial_no + "\",nonce_str=\"" + nonce_str + "\",timestamp=\"" + time_str + "\",signature=\"" + sign_info + "\"";
            request.Headers.Add("Authorization", value);
            request.ContentType = "application/json;charset=utf-8";
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            byte[] bs = Encoding.UTF8.GetBytes(param);
            request.ContentLength = bs.Length;
            if (bs.Length > 0)
            {
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                    reqStream.Close();
                }
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (Stream mystream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(mystream))
                    {
                        var info = reader.ReadToEnd();
                        return info;
                    }
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Rsa签名
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string RsaSign(string str, string key)
        {
            var result = string.Empty;

            byte[] keyData = Convert.FromBase64String(key);
            using (CngKey cngKey = CngKey.Import(keyData, CngKeyBlobFormat.Pkcs8PrivateBlob))
            using (RSACng rsa = new RSACng(cngKey))
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
                result = Convert.ToBase64String(rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
            }

            return result;
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <returns></returns>
        public static string GetNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        /// <summary>
        /// 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
    }
}
