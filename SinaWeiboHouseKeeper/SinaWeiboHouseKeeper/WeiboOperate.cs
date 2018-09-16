using Sgml;
using SinaWeiboHouseKeeper.WeiboData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SinaWeiboHouseKeeper
{
    public class WeiboOperate
    {

        private static int WeiboPictureMin = 3; //图片微博最少图片数
        private static bool WeiboListIsEnd = false; //微博列表是否到头
        private static WeiboLogin weibo;

        //广告过滤文件路径
        public static string filterADFilePath = "";

        public static WeiboLogin Weibo
        {
            set
            {
                weibo = value;
            }
        }

        #region 公有方法

        /// <summary>
        /// 发布一条图片微博，pics为空或为0时发布文字微博，文字内容不可为空
        /// </summary>
        /// <param name="message">文字内容</param>
        /// <param name="pics">图片id,最多可以发布9张图片</param>
        public static void SendAnImageWeibo(string message, string[] pics)
        {
            if (message.Equals(""))
            {
                return;
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

            string s = HttpHelper.SendDataByPost(url, weibo.MyCookies, data);
        }

        /// <summary>
        /// 根据用户id获取其符合条件的微博
        /// </summary>
        /// <param name="userId">用户id或个性域名</param>
        /// <returns></returns>
        public static List<ImageWeibo> GetImageWeibos(string userId)
        {
            List<ImageWeibo> imageWeibos = new List<ImageWeibo>();

            //判断是否为个性域名
            long x;
            string lastUserId = userId;
            if (Int64.TryParse(userId, out x))
            {
                lastUserId = @"u/" + userId;
            }


            WeiboListIsEnd = false;
            int count = 0;
            while (true)
            {
                if (WeiboListIsEnd)
                {
                    break;
                }
                count++;
                string url = "https://weibo.com/" +
                    lastUserId +
                    "?is_search=0&visible=0&is_all=1&is_tag=0&profile_ftype=1&page=" +
                     count.ToString() +
                     "#feedtop";
                imageWeibos.AddRange(GetImageWeibosFromHtml(url));
            }

            return imageWeibos;
        }

        #endregion

        #region 私有方法
        /// <summary>
        /// 根据用户url获取图片微博内容
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private static List<ImageWeibo> GetImageWeibosFromHtml(string url)
        {
            List<ImageWeibo> imageWeibos = new List<ImageWeibo>();

            string request = HttpHelper.Get(url, weibo.MyCookies, false);

            //匹配微博
            string regexString = "(WB_text W_f14)(.|\n)+?&mid=";
            MatchCollection matches = Regex.Matches(request, regexString);

            //列表是否读完
            if (matches.Count == 0)
            {
                WeiboListIsEnd = true;
            }

            foreach (Match match in matches)
            {
                //防止阻塞
                Application.DoEvents();

                try
                {
                    string message = match.Value.Substring(match.Value.IndexOf("                      "), match.Value.IndexOf(@" <\/div>\n ") - match.Value.IndexOf("                      ")).Trim();

                    //筛除广告
                    if (IsMessageHaveAD(message))
                    {
                        continue;
                    }

                    if (match.Value.IndexOf("pic_ids=") == -1)
                    {
                        continue;
                    }

                    string pics = match.Value.Substring(match.Value.IndexOf("pic_ids=") + 8, match.Value.IndexOf("&mid=") - match.Value.IndexOf("pic_ids=") - 8);

                    string[] pictures;

                    if (!pics.Equals(""))
                    {
                        pictures = pics.Split(',');
                        if (pictures.Length < WeiboPictureMin)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }

                    ImageWeibo imageWeibo = new ImageWeibo();
                    imageWeibo.WeiboMessage = message;
                    imageWeibo.Pictures = pictures;
                    imageWeibos.Add(imageWeibo);
                }
                catch { continue; }
            }

            return imageWeibos;
        }

        /// <summary>
        ///判断微博文字中是否含有广告
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static bool IsMessageHaveAD(string message)
        {
            bool isHave = false;
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
