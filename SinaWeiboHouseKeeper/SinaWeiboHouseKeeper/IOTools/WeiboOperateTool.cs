using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SinaWeiboHouseKeeper.IOTools
{
    public class WeiboOperateTool
    {
        //广告过滤文件路径
        public static string filterADFilePath = ConfigurationManager.AppSettings["FilterADPath"];

        /// <summary>
        /// 发布一条图文微博
        /// </summary>
        /// <param name="cookies"></param>
        /// <param name="message"></param>
        /// <param name="pics"></param>
        public static void SendAnImageWeibo(CookieContainer cookies, string message, string[] pics)
        {
            if (message.Equals("") || message.Equals("转发微博"))
            {
                message = "分享图片";
            }

            if (IsMessageHaveAD(message))
            {
                UserLog.WriteNormalLog("发布失败，含广告", "微博内容：" + message);
            }

            string picsString = "";

            if (pics.Length != 0)
            {
                picsString += pics[0];
                for (int i = 1; i < (pics.Length < 9 ? pics.Length : 9); i++)
                {
                    picsString += ("%7C" + pics[i]);
                }
            }

            string data;

            if (pics.Length == 1)
            {
                data = "location=v6_content_home&text=" +
                    message +
                    "&appkey=&style_type=1&pic_id=" +
                    picsString +
                    "&tid=&pdetail=&mid=&isReEdit=false&rank=0&rankid=&module=stissue&pub_source=main_&pub_type=dialog&isPri=0&_t=0";
            }
            else
            {
                data = "location=v6_content_home&text=" +
                    message +
                    "&appkey=&style_type=1&pic_id=" +
                    picsString +
                    "&tid=&pdetail=&mid=&isReEdit=false&gif_ids=&rank=0&rankid=&module=stissue&pub_source=main_&updata_img_num=" +
                    pics.Length +
                    "&pub_type=dialog&isPri=null&_t=0";
            }

            string url = @"https://weibo.com/aj/mblog/add?ajwvr=6&__rnd=" + GetTimeStamp();

            string s = HttpHelper.SendDataByPost(url, cookies, data);
        }

        #region 私有方法
        /// <summary>
        ///判断微博文字中是否含有广告
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static bool IsMessageHaveAD(string message)
        {
            bool isHave = false;
            try
            {
                if (!filterADFilePath.Equals(""))
                {
                    using (StreamReader sr = new StreamReader(filterADFilePath, Encoding.Default))
                    {
                        string line = sr.ReadToEnd();
                        string[] keyWords = line.Split('%');
                        foreach (string keyWord in keyWords)
                        {
                            if (message.IndexOf(keyWord) > -1)
                            {
                                isHave = true;
                                break;
                            }
                        }
                        sr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                UserLog.WriteNormalLog("广告过滤文件无法正常读取", ex.Message);
            }

            return isHave;
        }

        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <returns></returns>
        private static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }
        #endregion
    }
}
