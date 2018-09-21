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
        #region 存储路径
        //日志文件存储位置
        private static string logPath;
        private static string LogPath
        {
            get
            {
                if (logPath == null)
                {
                    logPath = Environment.CurrentDirectory;

                    //创建默认日志文件夹
                    if (!Directory.Exists(logPath += "\\LogData"))
                    {
                        Directory.CreateDirectory(logPath);
                    }
                }
                return logPath;
            }
            set
            {
                logPath = value;
            }
        }
        //文件名称
        private static string logName;
        private static string LogName
        {
            get
            {
                if (logName == null || !logName.Equals(DateTime.Today.ToString("yyyyMMdd") + ".txt"))
                {
                    logName = DateTime.Today.ToString("yyyyMMdd") + ".txt";
                }
                return logName;
            }
            set
            {
                logName = value;
            }
        }
        //全路径
        public static string FullPath
        {
            get
            {
                return LogPath + "\\" + LogName;
            }
        }
        #endregion

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="news">日志提要</param>
        /// <param name="details">详细信息，可以不写</param>
        public static void WriteNormalLog(string news,string details = "")
        {
            if (!File.Exists(FullPath))
            {
                File.Create(FullPath).Close();
            }

            StringBuilder strBuilderErrorMessage = new StringBuilder();

            strBuilderErrorMessage.Append("[" + System.DateTime.Now.ToString() + "]" + " [" + news + "]\r\n");
            if (!details.Equals(""))
            {
                strBuilderErrorMessage.Append(details + "\r\n");
            }
            using (StreamWriter sw = File.AppendText(FullPath))
            {
                sw.Write(strBuilderErrorMessage);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
