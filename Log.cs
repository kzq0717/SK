using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;
using System.Data;

namespace SK
{
    public class Log
    {
        /// <summary>
        /// 记录日志文件  (应用程序当前目录下)
        /// </summary>
        /// <param name="logName">日志描述</param>
        /// <param name="msg">写入信息</param>
        public static void WriteMsg(string logName, string msg)
        {
            try
            {
                //string path = Path.Combine("./log");
                string path = Application.StartupPath + "./log";
                Directory.CreateDirectory(path);
                string logFileName = path + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";//生成日志文件
                if (!File.Exists(logFileName))//判断日志是否为当天
                {
                    FileStream fs;
                    fs = File.Create(logFileName);//创建文件
                    fs.Close();
                }
                StreamWriter write = File.AppendText(logFileName);//文件中添加文件流
                write.WriteLine(DateTime.Now.ToString() + ":\t" + logName + msg);
                //write.WriteLine("----------------分割线--------------------");
                write.Flush();
                write.Close();

            }
            catch (Exception)
            {
                string path = Application.StartupPath + "./log";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    string logFileName = path + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                    if (!File.Exists(logFileName))//判断日志是否为当天
                    {
                        FileStream fs;
                        fs = File.Create(logFileName);//创建文件
                        fs.Close();
                    }

                    StreamWriter write = File.AppendText(logFileName);//文件中添加文件流
                    //write.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "" + logName + "\r\n" + msg);
                    write.WriteLine(DateTime.Now.ToString() + ":\t" + logName + msg);
                    // write.WriteLine("----------------分割线--------------------");
                    write.Flush();
                    write.Close();
                }
            }
        }
    }
}
