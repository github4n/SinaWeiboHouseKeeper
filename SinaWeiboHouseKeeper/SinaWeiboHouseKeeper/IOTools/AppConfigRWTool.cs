using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SinaWeiboHouseKeeper.IOTools
{
    public static class AppConfigRWTool
    {
        private static readonly string ConfigPath = Environment.CurrentDirectory + "\\setting.config";

        //修改配置文件
        public static void WriteSetting(string key, string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(ConfigPath);
            doc.SelectSingleNode("setting").SelectSingleNode(key).InnerText = value;
            doc.Save(ConfigPath);
        }

        //读取key的值
        public static string ReadSetting(string key)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(ConfigPath);         

            return doc.SelectSingleNode("setting").SelectSingleNode(key).InnerText;
        }
        //创建配置文件
        public static void CreateConfigFile()
        {

            if (!File.Exists(ConfigPath))
            {
                XmlDocument doc = new XmlDocument();
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));
                XmlElement rootElement = doc.CreateElement("setting");

                doc.AppendChild(rootElement);

                CreateNode(doc, rootElement, "YunDaMaUserName", "");
                CreateNode(doc, rootElement, "YunDaMaPasswordMd5", "");
                CreateNode(doc, rootElement, "EMailSenderUserName", "");
                CreateNode(doc, rootElement, "EMailSenderDisplayName", "微博管家");
                CreateNode(doc, rootElement, "EMailSenderPassword", "");
                CreateNode(doc, rootElement, "EMailReceiverName", "");
                CreateNode(doc, rootElement, "EmailRportChoose", "false");
                CreateNode(doc, rootElement, "EmailReportTime", "20");
                CreateNode(doc, rootElement, "FilterADPath", "");

                doc.Save(ConfigPath);
            }
        }

        /// <summary>    
        /// 创建节点    
        /// </summary>    
        /// <param name="xmldoc"></param>  xml文档  
        /// <param name="parentnode"></param>父节点    
        /// <param name="name"></param>  节点名  
        /// <param name="value"></param>  节点值  
        ///   
        private static void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            parentNode.AppendChild(node);
        }
    }
}
