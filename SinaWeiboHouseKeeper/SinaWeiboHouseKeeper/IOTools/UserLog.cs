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
        //日志文件存储位置
        private static string logPath;
        private static string LogPath
        {
            get
            {
                if (logPath == null)
                {
                    //取bin目录上两级菜单
                    string[] temp = System.Windows.Forms.Application.StartupPath.Split("\\".ToCharArray());
                    for (int i = 0; i < temp.Length - 2; i++)
                    {
                        logPath += temp[i];
                        logPath += "\\";
                    }
                    //创建默认日志文件夹
                    if (!Directory.Exists(logPath += "LogData"))
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
                if (logName == null)
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
        //记录日志
        public static void WriteNormalLog(string news)
        {
            if (!File.Exists(FullPath))
            {
                File.Create(FullPath).Close();
            }

            StringBuilder strBuilderErrorMessage = new StringBuilder();

            strBuilderErrorMessage.Append("[" + System.DateTime.Now.ToString() + "]" + " [" + news + "]\r\n");

            using (StreamWriter sw = File.AppendText(FullPath))
            {
                sw.Write(strBuilderErrorMessage);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
