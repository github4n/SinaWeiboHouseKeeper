using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SinaWeiboHouseKeeper.IOTools
{
    public  static class EMailTool
    {
        private static string UserName = "";
        private static string Password = "";
        private static string FromName = "";
        private static string Receiver = "";

        /// <summary> 
        /// 发送邮件程序 
        /// </summary> 
        /// <param name="fromname">发送人显示名称</param> 
        /// <param name="to">发送给谁（邮件地址）</param> 
        /// <param name="title">标题</param> 
        /// <param name="body">内容</param> 
        /// <param name="username">邮件登录名</param> 
        /// <param name="password">邮件密码</param> 
        /// <param name="server">邮件服务器</param> 
        /// <returns>send ok</returns> 
        private static void SendMail(string username, string password, string fromname, string to, string title, string body)
        {
            try
            {
                //邮件发送类 
                MailMessage mail = new MailMessage();
                //是谁发送的邮件 
                mail.From = new MailAddress(username, fromname);
                //发送给谁 
                mail.To.Add(to);
                //标题 
                mail.Subject = title;
                //内容编码 
                mail.BodyEncoding = Encoding.Default;
                //发送优先级 
                mail.Priority = MailPriority.High;
                //邮件内容 
                mail.Body = body;
                //是否HTML形式发送 
                mail.IsBodyHtml = true;

                mail.Priority = MailPriority.High;

                //网易邮件服务器和端口 （只支持网易邮箱）
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.qq.com";
                smtp.Port = 587;

                smtp.UseDefaultCredentials = false;

                //指定发送方式 
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                //指定登录名和密码 
                smtp.Credentials = new System.Net.NetworkCredential(username, password);

                smtp.EnableSsl = true;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                //超时时间 
                smtp.Timeout = 30000;
                smtp.Send(mail);
                UserLog.WriteProgramLog("日报告已发送", body);
                mail.Dispose();
            }
            catch (Exception exp)
            {
                UserLog.WriteProgramLog("邮件发送失败", exp.Message);
                UserLog.WriteProgramLog("未发送成功内容", body);
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="title"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static void SendMail(string title, string body)
        {
            if (UserName.Equals("") || Password.Equals("") || FromName.Equals("") || Receiver.Equals(""))
            {
                UserName = AppConfigRWTool.ReadSetting("EMailSenderUserName");
                Password = AppConfigRWTool.ReadSetting("EMailSenderPassword");
                FromName = AppConfigRWTool.ReadSetting("EMailSenderDisplayName");
                Receiver = AppConfigRWTool.ReadSetting("EMailReceiverName");
            }

            SendMail(UserName, Password, FromName, Receiver, title, body);
        }

    }
}
