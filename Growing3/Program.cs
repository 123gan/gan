using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Net;
using System.IO;

namespace Growing3
{
    class Program
    {
        static void Main(string[] args)
        {
            string requestUrl = "https://passport.cnblogs.com/user/signin";
            string postData = "input1=haohaoxvexi&input2=630738#*gan","input2":"DZJe6oCVWHZTZRN3m29GwUEnXkARezTZ / cjUps685EyeSO2BxV8M5d / Gycpd0WCLTmQKfHJpEfTdl4vw59mRRQzN8rlu89KbfRxVxA2dzeVPccOhdDPcmAgR / 1vWU0htOHIAorJtt0ny3qUu13x3 / Pkho3KQ53hPDS7YaCfBe3o = ","remember":false,"geetest_challenge":"9167a113fb12ac213682062738e67998k2","geetest_validate":"0b48dba61c2324a5f3c546740625ad3b","geetest_seccode":"0b48dba61c2324a5f3c546740625ad3b | jordan"}"
        }
        public static string PostCommonResponse(string requestUrl, string postData) //处理POST请求信息，并返回请求结果
        {
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bpostData = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bpostData.Length;

            using (Stream newStream = request.GetRequestStream())
            {
                newStream.Write(bpostData, 0, bpostData.Length);
            }

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string Result = "";

            if ((int)response.StatusCode != 200)
            {
                return Result;
            }

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream != null)
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        Result = reader.ReadToEnd();
                    }
                }
            }
            return Result;
        }
    }
}
