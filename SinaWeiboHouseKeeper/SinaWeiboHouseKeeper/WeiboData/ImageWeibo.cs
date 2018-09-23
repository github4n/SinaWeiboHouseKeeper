using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SinaWeiboHouseKeeper.WeiboData
{
    public class ImageWeibo
    {
        private string message;
        
        public string WeiboMessage
        {
            set
            {
                this.message = this.WashMessageData(value);
            }
            get
            {
                return this.message;
            }
        }

        public string[] Pictures { get; set; }

        public ImageWeibo()
        {
        }

        #region
        /// <summary>
        /// 根据获取到的很有%7c形式的数据拆分为id数组
        /// </summary>
        /// <param name="str">pics string</param>
        public void SetPicturesFromStr(string str)
        {
            this.Pictures = str.Split('#');
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 清洗文字微博内容
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string WashMessageData(string input)
        {
            //清除#Tag#内容
            string regexTagString = @"(a )(.|\n)+?\/a";
            MatchCollection matches = Regex.Matches(input, regexTagString);
            foreach (Match match in matches)
            {
                input = input.Replace("<" + match.Value + ">", "");
            }
            //规范表情内容
            string regexFaceString = @"(img class)(.|\n)+? \\/";
            matches = Regex.Matches(input, regexFaceString);
            foreach (Match match in matches)
            {
                string faceName = "";
                if (match.Value.IndexOf('[') > -1)
                {
                    faceName = match.Value.Substring(match.Value.IndexOf('['), match.Value.IndexOf(']') - match.Value.IndexOf('[') + 1);
                }
                input = input.Replace("<" + match.Value + ">", faceName);
            }
            //替换换行 换行标志%0A
            input = input.Replace("<br>", "%0A");
            //替换空格
            input = input.Replace("&nbsp;", " ");
            //替换“回复:”
            input = input.Replace("回复:", "");
            //替换“//:”
            input = input.Replace("\\/\\/:", "");

            return input;
        }
        #endregion
    }
}
