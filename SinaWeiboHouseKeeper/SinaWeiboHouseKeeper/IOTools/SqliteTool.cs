using SinaWeiboHouseKeeper.WeiboData;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinaWeiboHouseKeeper.IOTools
{
    //微博类型
    public enum WeiboType
    {
        ImageWeibo, //图文微博
        VideoWeibo, //视频微博
        None        //未知
    }

    public class SqliteTool
    {
        //数据库路径
        private static string DataBasePath = Environment.CurrentDirectory + "\\DataBase\\Weibos.db";
        private static SQLiteConnection DataBaseConnection = new SQLiteConnection("data source = " + DataBasePath);

        #region 公开方法
        //创建数据库
        public static void CreateDataBase()
        {
            if (!File.Exists(DataBasePath))
            {
                if (Directory.Exists(Environment.CurrentDirectory + "\\DataBase"))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\DataBase");
                }
                File.Create(DataBasePath).Close();
            }
            CreateTables();
        }

        //插入图片微博
        public static void InsertData(List<ImageWeibo> imageWeibos)
        {
            if (DataBaseConnection.State != System.Data.ConnectionState.Open)
            {
                DataBaseConnection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = DataBaseConnection;

                foreach (ImageWeibo weibo in imageWeibos)
                {
                    string weiboText = weibo.WeiboMessage;
                    string[] pics = weibo.Pictures;
                    string picsString = "";
                    if (pics.Length != 0)
                    {
                        picsString += pics[0];
                        for (int i = 1; i < (pics.Length < 9 ? pics.Length : 9); i++)
                        {
                            picsString += ("%7C" + pics[i]);
                        }
                    }
                    command.CommandText = String.Format("INSERT INTO imageweibos VALUES('{0}','{1}',false)", picsString, weiboText);
                    command.ExecuteNonQuery();
                }

                DataBaseConnection.Close();
            }
        }
        #endregion

        #region 私有方法
        //创建table
        public static void CreateTables()
        {
            if (DataBaseConnection.State != System.Data.ConnectionState.Open)
            {
                DataBaseConnection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = DataBaseConnection;

                //图文微博
                command.CommandText = "Create Table imageweibos (imageids varchar(200),weibotext varchar(300),ispublished bool)";
                command.ExecuteNonQuery();

                //视频微博
                command.CommandText = "Create Table videoweibos (videoids varchar(200),weibotext varchar(300),ispublished bool)";
                command.ExecuteNonQuery();
            }
            DataBaseConnection.Close();
        }

        #endregion
    }
}
