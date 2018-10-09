using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinaWeiboHouseKeeper.IOTools
{
    public class UserLog
    {

        /// <summary>
        /// 创建用户文件夹
        /// </summary>
        /// <param name="userName"></param>
        public static void CreateUserLog(string userName)
        {
            string logPath = Environment.CurrentDirectory + "\\Users\\" + userName + "\\LogData";
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
        }

        //根据用户名的用户日志路径
        private static string UserPath(string userName)
        {
            string path = Environment.CurrentDirectory + "\\Users\\" + userName + "\\LogData";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string txtName = DateTime.Today.ToString("yyyyMMdd") + ".txt";

            return path + "\\" + txtName;
        }

        /// <summary>
        /// 用户日志
        /// </summary>
        /// <param name="userName">用户昵称</param>
        /// <param name="news">日志内容</param>
        /// <param name="details">详细内容</param>
        public static void WriteNormalLog(string userName, string news, string details = "")
        {
            string path = UserPath(userName);

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            StringBuilder strBuilderErrorMessage = new StringBuilder();

            strBuilderErrorMessage.Append("[" + DateTime.Now.ToString() + "]" + " [" + news + "]\r\n");
            if (!details.Equals(""))
            {
                strBuilderErrorMessage.Append(details + "\r\n");
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write(strBuilderErrorMessage);
                sw.Flush();
                sw.Close();
            }
        }

        /// <summary>
        /// 程序总体日志
        /// </summary>
        /// <param name="news">日志内容</param>
        /// <param name="details">详细内容可以为空</param>
        public static void WriteProgramLog(string news, string details = "")
        {
            string path = Environment.CurrentDirectory + "\\LogData";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = path + "\\" + DateTime.Today.ToString("yyyyMMdd") + ".txt";

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            StringBuilder strBuilderErrorMessage = new StringBuilder();

            strBuilderErrorMessage.Append("[" + DateTime.Now.ToString() + "]" + " [" + news + "]\r\n");
            if (!details.Equals(""))
            {
                strBuilderErrorMessage.Append(details + "\r\n");
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write(strBuilderErrorMessage);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
