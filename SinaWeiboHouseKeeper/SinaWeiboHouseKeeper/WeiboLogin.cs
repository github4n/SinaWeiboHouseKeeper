using SinaWeiboHouseKeeper.IOTools;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace SinaWeiboHouseKeeper
{
    public class WeiboLogin
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        //微博昵称
        private string displayName = "";
        public string DisplayName
        {
            get
            {
                if (this.myCookies.Count == 0)
                {
                    return "";
                }
                else
                {
                    if (this.displayName.Equals(""))
                    {
                        this.displayName = this.GetDisplayName();
                    }
                    return this.displayName;
                }
            }
        }

        //uid
        public string UserId { get; set; }

        //存放登陆后的cookie
        private CookieContainer myCookies = new CookieContainer();

        public CookieContainer MyCookies
        {
            get { return myCookies; }
        }

        //--> 云打码参数
        private const int YunDaMaAppId = 5826;
        private const string YunDaMaAppKey = "0025c106cd2868a094253c9fb40a8982";
        private const int YunDaMaCodeType = 1005;
        private const int YunDaMaTimeOut = 60;
        private string YunDaMaUserName = "";
        private string YunDaMaPassword = "";
        //<--

        //-->更新cookies定时器
        private Timer updateCookiesTimer = new Timer() { Interval = 60000};
        private int updateCount = 0;
        //<--


        private const string PUBKEY = "EB2A38568661887FA180BDDB5CABD5F21C7BFD59C090CB2D245A87AC253062882729293E5506350508E7F9AA3BB77F4333231490F915F6D63C55FE2F08A49B353F444AD3993CACC02DB784ABBB8E42A9B1BBFFFB38BE18D78E87A0E41B9B8F73A928EE0CCEE1F6739884B9777E4FE9E88A1BBE495927AC4A799B3181D6442443";
        private const string RSAKV = "1330428213";

        private string su; //加密后的用户名
        private string servertime; //预登录参数1（时间戳）
        private string pcid; //预登录参数2
        private string nonce; //预登录参数3（随机数）
        private string showpin; //预登录参数4（是否需要验证码）

        private bool forcedpin = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public WeiboLogin(string username, string password, bool forcedpin)
        {
            this.Username = username;
            this.Password = password;
            this.forcedpin = forcedpin;

            //Base64加密用户名
            Encoding myEncoding = Encoding.GetEncoding("utf-8");
            byte[] suByte = myEncoding.GetBytes(HttpUtility.UrlEncode(username));
            su = Convert.ToBase64String(suByte);

            updateCookiesTimer.Tick += UpdateCookiesTimer_Tick;
            this.updateCookiesTimer.Enabled = true;
        }

        /// <summary>
        /// 开始登陆
        /// </summary>
        /// <returns>验证码图片</returns>
        public Image Start()
        {
            GetParameter();
            if (showpin == "1" || forcedpin)
            {
                return GetPIN();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 结束登陆
        /// </summary>
        /// <param name="door">验证码</param>
        /// <returns>结果码</returns>
        public string End(string door = null)
        {
            myCookies = GetCookie(door, out string retcode);
            return retcode;
        }

        /// <summary>
        /// 使用登陆后得到的 cookie 进行GET （自动跳转）
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Get(string url)
        {
            return HttpHelper.Get(url, myCookies, true);
        }

        //Post
        public string Post(string url, string data)
        {
            return HttpHelper.SendDataByPost(url, myCookies, data);
        }

        /// <summary>
        /// 预登录得到所需的参数
        /// </summary>
        private void GetParameter()
        {
            string url = "http://login.sina.com.cn/sso/prelogin.php?entry=weibo&callback=sinaSSOController.preloginCallBack&su="
                + su + "&rsakt=mod&checkpin=1&client=ssologin.js(v1.4.18)";
            string content = HttpHelper.Get(url);
            int pos;
            pos = content.IndexOf("servertime");
            servertime = content.Substring(pos + 12, 10);
            pos = content.IndexOf("pcid");
            pcid = content.Substring(pos + 7, 39);
            pos = content.IndexOf("nonce");
            nonce = content.Substring(pos + 8, 6);
            pos = content.IndexOf("showpin");
            showpin = content.Substring(pos + 9, 1);
            //showpin = "1"; //验证码测试
        }

        /// <summary>
        /// 获取验证码图片
        /// </summary>
        /// <returns></returns>
        public Image GetPIN()
        {
            string url = "http://login.sina.com.cn/cgi/pin.php?p=" + pcid;
            return HttpHelper.GetImage(url);
        }

        /// <summary>
        /// 得到cookie
        /// </summary>
        /// <param name="door"></param>
        /// <param name="retcode"></param>
        /// <returns></returns>
        private CookieContainer GetCookie(string door, out string retcode)
        {
            CookieContainer myCookieContainer = new CookieContainer();
            string sp = GetSP(Password, servertime, nonce, PUBKEY);//得到加密后的密码
            if(sp == null)
            {
                retcode = "RSA加密失败";
                return null;
            }

            string postData = "entry=weibo&gateway=1&from=&savestate=7&useticket=1&pagerefer=&vsnf=1&su=" + su
                            + "&service=miniblog&servertime=" + servertime
                            + "&nonce=" + nonce
                            + "&pwencode=rsa2&rsakv=" + RSAKV + "&sp=" + sp
                            + "&sr=1366*768&encoding=UTF-8&prelt=104&url=http%3A%2F%2Fweibo.com%2Fajaxlogin.php%3Fframelogin%3D1%26callback%3Dparent.sinaSSOController.feedBackUrlCallBack&returntype=META";
            if ((showpin == "1" || forcedpin) && door != null)
            {
                postData += "&pcid=" + pcid + "&door=" + door;
            }
            string content = HttpHelper.Post("http://login.sina.com.cn/sso/login.php?client=ssologin.js(v1.4.18)", postData);
            int pos = content.IndexOf("retcode=");
            retcode = content.Substring(pos + 8, 1);
            if (retcode == "0")
            {
                pos = content.IndexOf("location.replace");
                string url = content.Substring(pos + 18, 276);//285->276 fuck!! 
                content = HttpHelper.Get(url, myCookieContainer, false);
                return myCookieContainer;
            }
            else
            {
                retcode = content.Substring(pos + 8, 4);
                return null;
            }
        }

        private string GetSP(string pwd, string servertime, string nonce, string pubkey)
        {
            StreamReader sr = new StreamReader("sinaSSOEncoder"); //从文本中读取修改过的JS
            string js = sr.ReadToEnd();
            //自定义function进行加密
            js += "function getpass(pwd,servicetime,nonce,rsaPubkey){var RSAKey=new sinaSSOEncoder.RSAKey();RSAKey.setPublic(rsaPubkey,'10001');var password=RSAKey.encrypt([servicetime,nonce].join('\\t')+'\\n'+pwd);return password;}";
            ScriptEngine se = new ScriptEngine(ScriptLanguage.JavaScript);
            object obj = se.Run("getpass", new object[] { pwd, servertime, nonce, pubkey }, js);
            return obj.ToString();
        }

        #region 自动更新cookie
        //更新Cookies
        public string UpdateCookies(out bool IsSuccess)
        {
            IsSuccess = true;

            this.forcedpin = false;
            string recode = this.End();
            if (recode.Equals("0"))
            {
                return "Cookies更新成功";
            }
            else
            {
                this.forcedpin = true;
                //五次尝试，失败后不再尝试登录
                for (int i = 0; i < 5; i++)
                {
                    Image image = this.Start();
                    //解码
                    string code = this.YUDMDecode(image ,out int resultId);

                    if (code.Equals(""))
                    {
                        continue;
                    }

                    //云打码解码登录
                    string result = this.End(code);
                    if (result.Equals("0"))
                    {
                        return String.Format("云打码解码第{0}次更新Cookies成功", (i + 1).ToString());
                    }
                    else
                    {
                        //登陆失败，验证码解码失败回报
                        YunDaMaTool.YDM_EasyReport(YunDaMaUserName, YunDaMaPassword,YunDaMaAppId, YunDaMaAppKey, resultId, false);
                    }
                }
                IsSuccess = false;
                return "更新Cookies失败";
            }
        }

        //云打码解码
        private string YUDMDecode(Image img , out int resultId)
        {
            StringBuilder pCodeResult = new StringBuilder(new string(' ', 30));

            if (YunDaMaPassword.Equals("") || YunDaMaUserName.Equals(""))
            {
                YunDaMaUserName = ConfigurationManager.AppSettings["YunDaMaUserName"];
                YunDaMaPassword = ConfigurationManager.AppSettings["YunDaMaPasswordMd5"];
            }

            //保存文件到本地
            string jpgPath = System.Environment.CurrentDirectory + "\\Source\\code.jpg";
            if (!Directory.Exists(System.Environment.CurrentDirectory + "\\Source"))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(System.Environment.CurrentDirectory + "\\Source"); //新建文件夹   
            }
            img.Save(jpgPath, img.RawFormat);

            //解码
            resultId = YunDaMaTool.YDM_EasyDecodeByPath(YunDaMaUserName, YunDaMaPassword, YunDaMaAppId, YunDaMaAppKey, jpgPath, YunDaMaCodeType, YunDaMaTimeOut, pCodeResult);

            if (resultId > 0)
            {
                return pCodeResult.ToString();
            }
            else
            {
                return "";
            }
        }

        //更新cookies定时器
        private void UpdateCookiesTimer_Tick(object sender, EventArgs e)
        {
            this.updateCount++;
            if (this.updateCount >= 1200)
            {
                this.updateCount = 0;

                string result = this.UpdateCookies(out bool isSuccess);

                if (!isSuccess)
                {
                    //更新失败，邮件通知
                    EMailTool.SendMail("运行错误", "Cookies更新失败，需要重新登陆！");
                }

                UserLog.WriteNormalLog(this.DisplayName + " " + result);
            }
        }
        #endregion

        #region 获取昵称
        //获取用户名
        private string GetDisplayName()
        {
            var userHomePageTxt = HttpHelper.Get("https://weibo.com", this.myCookies, true);

            //获取用户uid
            int indexStart = userHomePageTxt.IndexOf("$CONFIG['uid']='") + "$CONFIG['uid']='".Length;
            userHomePageTxt = userHomePageTxt.Substring(indexStart);
            this.UserId = userHomePageTxt.Substring(0, userHomePageTxt.IndexOf("';"));

            indexStart = userHomePageTxt.IndexOf("$CONFIG['nick']='") + "$CONFIG['nick']='".Length;

            userHomePageTxt = userHomePageTxt.Substring(indexStart);

            return userHomePageTxt.Substring(0, userHomePageTxt.IndexOf("';"));
        }
        #endregion
    }
}
