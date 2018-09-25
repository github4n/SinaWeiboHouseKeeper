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
    public class SqliteTool
    {
        //微博类型
        public enum WeiboType
        {
            ImageWeibo,
            VideoWeibo,
            None
        }

        //数据库路径
        private static string DataBasePath = Environment.CurrentDirectory + "\\DataBase\\Weibos.db";
        private static SQLiteConnection DataBaseConnection = new SQLiteConnection("data source = " + DataBasePath);

        #region 公开方法
        //创建数据库
        public static void CreateDataBase()
        {
            if (!File.Exists(DataBasePath))
            {
                if (!Directory.Exists(Environment.CurrentDirectory + "\\DataBase"))
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\DataBase");
                }
                File.Create(DataBasePath).Close();
            }
            CreateTables();
        }

        //插入图片微博
        public static void InsertImageWebos(List<ImageWeibo> imageWeibos)
        {
            if (DataBaseConnection.State != System.Data.ConnectionState.Open)
            {
                DataBaseConnection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = DataBaseConnection;

                SQLiteDataReader reader = null;

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
                            //字符串间以“#”间隔
                            picsString += ("#" + pics[i]);
                        }
                    }

                    command.CommandText = String.Format("SELECT COUNT(*) FROM imageweibos WHERE imageids = '{0}'", picsString);
                    command.ExecuteNonQuery();

                    reader = command.ExecuteReader();

                    reader.Read();
                    int count = reader.GetInt32(0);
                    reader.Close();
                    if (count == 0)
                    {
                        command.CommandText = String.Format("INSERT INTO imageweibos VALUES('{0}','{1}',false)", picsString, weiboText);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.CommandText = String.Format( "SELECT rowid,* From imageweibos WHERE imageids = '{0}'",picsString);
                        command.ExecuteNonQuery();
                        reader = command.ExecuteReader();
                        reader.Read();
                        int rowid = reader.GetInt32(0);
                        string dbText = reader.GetString(2);

                        reader.Close();
                        if(dbText.Length < weiboText.Length)
                        {
                            command.CommandText = String.Format("UPDATE imageweibos SET weibotext = '{0}' WHERE rowid = {1}", weiboText, rowid.ToString());
                            command.ExecuteNonQuery();
                        }

                    }
                }
                reader.Close();
                DataBaseConnection.Close();
            }
        }

        //插入视频微博
        public static void InsertVideoWeibos(List<VideoWeibo> videoWeibos)
        {
            //插入视频微博
        }

        //获取随机可发布微博
        public static ImageWeibo GetARandomImageWeiboIsNotPublished(WeiboType type)
        {
            ImageWeibo weibo = new ImageWeibo();

            if (DataBaseConnection.State != System.Data.ConnectionState.Open)
            {
                DataBaseConnection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = DataBaseConnection;

                //获取随机一条未发布的微博
                //根据类型获取剩余微博
                if (type == WeiboType.ImageWeibo)
                {
                    command.CommandText = "SELECT rowid,* FROM imageweibos WHERE ispublished = false ORDER BY RANDOM() limit 1";
                }
                else if (type == WeiboType.VideoWeibo)
                {
                    command.CommandText = "SELECT rowid,* FROM videoweibos WHERE ispublished = false ORDER BY RANDOM() limit 1";
                }
                else
                {
                    DataBaseConnection.Close();
                    return weibo;
                }
                command.ExecuteNonQuery();
                SQLiteDataReader reader = command.ExecuteReader();
 
                reader.Read();
                int rowid = reader.GetInt32(0);
                weibo.SetPicturesFromStr(reader.GetString(1));
                weibo.WeiboMessage = reader.GetString(2);
                
                reader.Close();

                //将微发布微博标注为发布
                command.CommandText = "UPDATE imageweibos SET ispublished = true WHERE rowid = " + rowid;
                command.ExecuteNonQuery();

                DataBaseConnection.Close();
            }

            return weibo;
        }

        /// <summary>
        /// 根据微博类型获取剩余可发布微博数
        /// </summary>
        /// <param name="type">微博类型</param>
        /// <returns></returns>
        public static int GetLaveWeiboCount(WeiboType type)
        {
            int weiboCount = 0;
            if (DataBaseConnection.State != System.Data.ConnectionState.Open)
            {
                DataBaseConnection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = DataBaseConnection;

                //根据类型获取剩余微博
                if (type == WeiboType.ImageWeibo)
                {
                    command.CommandText = "SELECT count(*) FROM imageweibos WHERE ispublished = false";
                }
                else if (type == WeiboType.VideoWeibo)
                {
                    command.CommandText = "SELECT count(*) FROM videoweibos WHERE ispublished = false";
                }
                else
                {
                    DataBaseConnection.Close();
                    return 0;
                }
                    command.ExecuteNonQuery();

                SQLiteDataReader reader = command.ExecuteReader();
                reader.Read();
                weiboCount = reader.GetInt32(0);
                reader.Close();
            }
            DataBaseConnection.Close();

            return weiboCount;
        }

        /// <summary>
        /// 插入被爬取用户的信息
        /// </summary>
        /// <param name="uid">个性域名或id，爬取微博用</param>
        /// <param name="oid">真实id，获取粉丝用</param>
        public static void InsertUidAndOid(string uid,string oid)
        {
            if (DataBaseConnection.State != System.Data.ConnectionState.Open)
            {
                DataBaseConnection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = DataBaseConnection;

                command.CommandText = String.Format("INSERT INTO users VALUES('{0}','{1}',false)", uid, oid);
                command.ExecuteNonQuery();

                DataBaseConnection.Close();
            }
        }

        //获取一个随机用户的oid,用来获取粉丝
        public static string GetRandomOid()
        {
            string uid = "";
            if (DataBaseConnection.State != System.Data.ConnectionState.Open)
            {
                DataBaseConnection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = DataBaseConnection;
                command.CommandText = "SELECT * FROM users WHERE isdeleted = false ORDER BY RANDOM() limit 1";
                command.ExecuteNonQuery();
                SQLiteDataReader reader = command.ExecuteReader();
                reader.Read();
                uid = reader.GetString(1);

                reader.Close();
                DataBaseConnection.Close();
            }
            return uid;
        }

        //获取所有用户uid，用来获取微博
        public static List<string> GetAllUid()
        {
            List<string> uids = new List<string>();
            if (DataBaseConnection.State != System.Data.ConnectionState.Open)
            {
                DataBaseConnection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = DataBaseConnection;
                command.CommandText = "SELECT * FROM users WHERE isdeleted = false ORDER BY RANDOM()";
                command.ExecuteNonQuery();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    uids.Add(reader.GetString(0));
                }
                reader.Close();
                DataBaseConnection.Close();
            }
            return uids;
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

                //判断imageweibos table是否已经存在
                command.CommandText = "SELECT COUNT(*) FROM sqlite_master WHERE TYPE = 'table' AND NAME = 'imageweibos'";
                command.ExecuteNonQuery();
                SQLiteDataReader reader = command.ExecuteReader();
                reader.Read();
                int count = reader.GetInt32(0);
                reader.Close();
                if (count == 0)
                {
                    //图文微博
                    command.CommandText = "Create Table imageweibos (imageids varchar(200),weibotext varchar(300),ispublished bool)";
                    command.ExecuteNonQuery();
                }

                //判断video table是否已经存在
                command.CommandText = "SELECT COUNT(*) FROM sqlite_master WHERE TYPE = 'table' AND NAME = 'videoweibos'";
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                reader.Read();
                count = reader.GetInt32(0);
                reader.Close();
                if (count == 0)
                {
                    //视频微博
                    command.CommandText = "Create Table videoweibos (videoids varchar(200),weibotext varchar(300),ispublished bool)";
                    command.ExecuteNonQuery();
                }

                //判断users table是否已经存在
                command.CommandText = "SELECT COUNT(*) FROM sqlite_master WHERE TYPE = 'table' AND NAME = 'users'";
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                reader.Read();
                count = reader.GetInt32(0);
                reader.Close();
                if (count == 0)
                {
                    //创建users表，用来存储被爬取用户
                    command.CommandText = "Create Table users (uid varchar(20),oid varchar(20),isdeleted bool)";
                    command.ExecuteNonQuery();
                }
            }
            DataBaseConnection.Close();
        }

        #endregion
    }
}
